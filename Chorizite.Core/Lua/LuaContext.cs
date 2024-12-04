using Autofac;
using Chorizite.Core.Backend;
using Chorizite.Core.Plugins;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using XLua;

namespace Chorizite.Core.Lua {
    public partial class LuaContext : LuaEnv {
        private static Regex _luaDocExceptionRe = new Regex("""\[string "([^:]+\.rml):(\d+)"\]:(\d+)""", RegexOptions.Singleline);
        private static List<LuaContext> _contexts = new List<LuaContext>();
        private class TimeoutEntry {
            public Action Callback;
            public DateTime Expiration;
        }

        private readonly string _luaScriptsPath;
        private readonly ILogger _log;
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private LuaFunction _originalRequire;
        private bool _isDisposed;
        private List<TimeoutEntry> _timeoutQueue = new();
        private List<LuaCoroutine> _luaThreads = new();

        public LuaContext() : base() {
            _contexts.Add(this);
            _luaScriptsPath = Path.Combine(ChoriziteStatics.AssemblyDirectory, "Lua", "LuaScripts");
            _log = ChoriziteStatics.MakeLogger("Lua");

            AddLoader(BuiltinModuleLoader);
            InitGlobals();

            var initPath = Path.Combine(_luaScriptsPath, "init.lua");
            if (File.Exists(initPath)) {
                var lua_init = File.ReadAllText(initPath);
                DoString(lua_init, "Init");
            }
        }

        private byte[] BuiltinModuleLoader(ref string filename) {
            // TODO: this is hacky
            if (filename.StartsWith("framework.") && !filename.EndsWith(".lua")) {
                var lib = filename.Substring("framework.".Length);
                var libPath = Path.Combine(_luaScriptsPath, Path.Combine("framework", $"{lib}.lua"));
                if (File.Exists(libPath)) {
                    return File.ReadAllBytes(libPath);
                }
            }
            if (filename.StartsWith("xlua.") && !filename.EndsWith(".lua")) {
                var lib = filename.Substring("xlua.".Length);
                var libPath = Path.Combine(_luaScriptsPath, Path.Combine("xlua", $"{lib}.lua"));
                if (File.Exists(libPath)) {
                    return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(libPath));
                }
            }

            return null!;
        }

        public void SetGlobal(string name, object? value) {
            Global.Set(name, value);
        }

        private void InitGlobals() {
            Global.Set("context", this);
            Global.Set("__sleep", Sleep);
            Global.Set("print", Print);
            Global.Set("setTimeout", SetTimeout);

            _originalRequire = Global.Get<LuaFunction>("require");
            Global.Set("require", Require);
        }

        internal static void UpdateAll() {
            var envs = _contexts.ToArray();
            foreach (var env in envs) {
                env.Update();
            }
        }

        protected void Update() {
            // coroutines (threads)
            var threads = _luaThreads.ToArray();
            foreach (var thread in threads) {
                try {
                    if (!thread.Update()) {
                        _luaThreads.Remove(thread);
                    }
                }
                catch (LuaException ex) {
                    _luaThreads.Remove(thread);
                    _log.LogError(FormatDocumentException(ex));
                }
                catch (Exception ex) {
                    _luaThreads.Remove(thread);
                    _log.LogError(ex, "Error resuming coroutine");
                }
            }

            // timeouts
            var timeouts = _timeoutQueue.Where(x => x.Expiration <= DateTime.Now).ToArray();
            foreach (var timeout in timeouts) {
                _timeoutQueue.Remove(timeout);
                try {
                    timeout.Callback();
                }
                catch (LuaException ex) {
                    _log.LogError(FormatDocumentException(ex));
                }
                catch (Exception ex) {
                    _log.LogError(ex, "Error running timeout callback");
                }
            }

            Tick();
        }

        public Task ThreadToTask(LuaThread thread, params object[] args) {
            var co = new LuaCoroutine(thread, this, _log);
            return co.Task;
        }

        public Task AddManagedCoroutine(LuaThread thread) {
            var co = new LuaCoroutine(thread, this, _log);
            if (co.Update()) {
                _luaThreads.Add(co);
            }
            return co.Task;
        }

        public string FormatDocumentException(Exception ex, int lineOffset = 0) {
            return FormatStackTraces(ex.Message, lineOffset).TrimEnd();
        }

        private string FormatStackTraces(string message, int lineOffset = 0) {
            var lines = message?.Split('\n') ?? Array.Empty<string>();
            var strBuilder = new StringBuilder();
            foreach (var line in lines) {
                if (_luaDocExceptionRe.IsMatch(line)) {
                    var m = _luaDocExceptionRe.Match(line);
                    if (int.TryParse(m.Groups[2].Value, out var docLine) && int.TryParse(m.Groups[3].Value, out var luaLine)) {
                        strBuilder.AppendLine(line.Replace(m.Groups[0].Value, $"{m.Groups[1].Value}:{docLine + luaLine - 1 + lineOffset}: {m.Groups[4].Value}"));
                        continue;
                    }
                }

                strBuilder.AppendLine(line);
            }
            return strBuilder.ToString();
        }

        public string FormatLuaResult(object[]? result, int maxDepth = 2, int depth = 0) {
            return result?.Length > 0 ? string.Join(" ", result.Select(x => LuaTypeToFriendlyString(x, maxDepth, depth))) : "nil";
        }

        public string LuaTypeToFriendlyString(object obj, int maxDepth = 2, int depth = 0) {
            if (obj is null) return "nil";

            if (obj is LuaTable luaTable) {
                var tableStr = new StringBuilder();

                luaTable.ForEach<object, object>((key, value) => {
                    tableStr.AppendLine($"[{key}] = {value}");
                });
                return string.IsNullOrEmpty(tableStr.ToString()) ? "[]" : tableStr.ToString();
            }

            return $"{obj}";
        }

        private object? Require(object module) {
            if (module is null) {
                return null;
            }
            else if (module is Type moduleType) {
                return ChoriziteStatics.Scope.Resolve(moduleType);
            }
            else if (module is string modulePath) {
                if (modulePath.StartsWith("plugins.") && !modulePath.EndsWith(".lua")) {
                    var lib = modulePath.Substring("plugins.".Length);
                    var pluginManager = ChoriziteStatics.Scope.Resolve<IPluginManager>();
                    return pluginManager?.GetPlugin<IPluginCore>(lib);
                }

                return modulePath switch {
                    "backend" => ChoriziteStatics.Backend,
                    _ => _originalRequire.Call(modulePath).FirstOrDefault(),
                };
            }

            _log.LogWarning($"Unknown module: [{module?.GetType().Name}] {module}");

            return null;
        }

        private void SetTimeout(Action cb, int timeoutInMilliseconds = 1) {
            if (_isDisposed) return;
            _timeoutQueue.Add(new TimeoutEntry {
                Callback = cb,
                Expiration = DateTime.Now.AddMilliseconds(timeoutInMilliseconds),
            });
        }

        private void Print(params object[] args) {
            var message = string.Join(" ", args.Select(a => FormatStackTraces(FormatLuaResult([ a ])).TrimEnd()));
            _log.LogDebug(message);
            if (ChoriziteStatics.Backend.Environment == ChoriziteEnvironment.Client) {
                try {
                    (ChoriziteStatics.Backend as IClientBackend)?.AddChatText(message, ChatType.WorldBroadcast);
                }
                catch { }
            }
        }

        /// <summary>
        /// Sleep for a given number of milliseconds
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public async Task Sleep(int ms) {
            await Task.Delay(ms, cancellationTokenSource.Token);
        }

        public override void Dispose(bool disposing) {
            if (_isDisposed) return;
            _isDisposed = true;

            _luaThreads.Clear();
            _timeoutQueue.Clear();
            _contexts.Remove(this);
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
            PreDispose();
            
            FullGc();

            for (int i = 0; i < 10; i++) {
                GC();
                Tick();
                System.GC.WaitForPendingFinalizers();
                System.GC.Collect();
            }
            
            DoString("require('xlua.util').print_func_ref_by_csharp()");
            _originalRequire = null!;

            try {
                base.Dispose(disposing);
            }
            catch (Exception ex) {
                _log?.LogError(ex.Message);
            }
        }
    }
}
