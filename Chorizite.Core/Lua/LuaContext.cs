using Autofac;
using Chorizite.Core.Backend.Client;
using Chorizite.Core.Net;
using Chorizite.Core.Plugins;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using XLua;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Chorizite.Core.Lua {
    public partial class LuaContext : LuaEnv {
        private static Regex _luaDocExceptionRe = new Regex("""\[string "([^:]+\.rml):(\d+)"\]:(\d+)""", RegexOptions.Singleline);
        private static List<LuaContext> _contexts = new List<LuaContext>();

        private int _nextTimeoutId = 0;
        private int _nextIntervalId = 0;

        private class IntervalEntry {
            public int Id { get; set; }
            public Action Callback { get; set; }
            public Timer Timer { get; set; }
        }

        private class TimeoutEntry {
            public int Id { get; set; }  
            public Action Callback { get; set; }
            public DateTime Expiration { get; set; }
        }

        private readonly string _luaScriptsPath;
        private readonly ILogger _log;
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private LuaFunction _originalRequire;
        private bool _isDisposed;
        private Dictionary<int, IntervalEntry> _intervals = new();
        private readonly Dictionary<int, TimeoutEntry> _timeouts = new();
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
            Global.Set("clearTimeout", ClearTimeout);
            Global.Set("setInterval", SetInterval);
            Global.Set("clearInterval", ClearInterval);

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
            var now = DateTime.Now;
            var expiredTimeouts = _timeouts.Values.Where(x => x.Expiration <= now).ToArray();

            foreach (var timeout in expiredTimeouts) {
                _timeouts.Remove(timeout.Id);
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
                if (modulePath.ToLower() != "debug") {
                    var path = DoString($""""
                        function traceback ()
                          local level = 1
                          while true do
                            local info = debug.getinfo(level, "Sl")
                            if not info then break end
                            if info.what == "C" then   -- is a C function?
                              -- print(level, "C function")
                            else   -- a Lua function
                              if #info.source > 3 and (info.source:find('.rml') or info.source:find('.lua')) then
                                return info.source
                              end
                              --print(string.format("(%d)[%s]:%d", level, info.source, info.currentline))
                            end
                            level = level + 1
                          end
                        end
                        return traceback()
                        """");
                    if (path is not null && path.Length > 0) {
                        var pathStr = RemoveLastNumberSuffix(path[0].ToString()?.Replace("|", ":"));
                        if (!string.IsNullOrEmpty(pathStr) && File.Exists(pathStr)) {
                            var scriptDir = Path.GetDirectoryName(pathStr);

                            var parentDir = Path.GetDirectoryName(scriptDir); 

                            if (File.Exists(Path.Combine(scriptDir, $"{modulePath}.lua")) ||
                                (parentDir != null && File.Exists(Path.Combine(parentDir, $"{modulePath}.lua")))) {

                                var choriziteCorePath = Path.Combine(ChoriziteStatics.Config.BaseDirectory, "Lua", "LuaScripts").Replace("\\", "\\\\") + "\\\\?.lua";
                                scriptDir = scriptDir.Replace("\\", "\\\\") + "\\\\?.lua";

                                if (parentDir != null) {
                                    parentDir = parentDir.Replace("\\", "\\\\") + "\\\\?.lua";
                                    DoString($"package.path = \"{choriziteCorePath};{scriptDir};{parentDir}\"");
                                }
                                else {
                                    DoString($"package.path = \"{choriziteCorePath};{scriptDir}\"");
                                }

                                return _originalRequire.Call($"{modulePath}").FirstOrDefault();
                            }
                        }
                    }
                }
                modulePath = modulePath.ToLower();
                if (modulePath.StartsWith("plugins.") && !modulePath.EndsWith(".lua")) {
                    var lib = modulePath.Substring("plugins.".Length);
                    var pluginManager = ChoriziteStatics.Scope.Resolve<IPluginManager>();
                    return pluginManager?.GetPlugin<IPluginCore>(lib);
                }

                // custom modules, registered with <see cref="IChoriziteBackend.RegisterLuaModule(string, object)" />
                if (ChoriziteStatics.Backend.LuaModules.TryGetValue(modulePath, out var moduleObj)) {
                    return moduleObj;
                }

                return modulePath switch {
                    "Backend" => ChoriziteStatics.Backend,
                    "NetworkParser" => ChoriziteStatics.Scope.Resolve<NetworkParser>(),
                    _ => _originalRequire.Call(modulePath).FirstOrDefault(),
                };
            }

            _log.LogWarning($"Unknown module: [{module?.GetType().Name}] {module}");

            return null;
        }
        private static string RemoveLastNumberSuffix(string? input) {
            if (string.IsNullOrEmpty(input))
                return input ?? "";

            int lastColonIndex = input.LastIndexOf(':');
            if (lastColonIndex == -1)
                return input;

            // Check if everything after the colon is a number
            string numberPart = input.Substring(lastColonIndex + 1);
            if (int.TryParse(numberPart, out _)) {
                return input.Substring(0, lastColonIndex);
            }

            return input;
        }

        private int SetTimeout(Action cb, int timeoutInMilliseconds = 1) {
            if (_isDisposed) return -1;

            var id = Interlocked.Increment(ref _nextTimeoutId);
            var entry = new TimeoutEntry {
                Id = id,
                Callback = cb,
                Expiration = DateTime.Now.AddMilliseconds(timeoutInMilliseconds),
            };

            _timeouts[id] = entry;
            return id;
        }

        private void ClearTimeout(int timeoutId) {
            _timeouts.Remove(timeoutId);
        }

        private int SetInterval(Action cb, int intervalInMilliseconds = 1) {
            if (_isDisposed) return -1;

            var id = Interlocked.Increment(ref _nextIntervalId);

            var entry = new IntervalEntry {
                Id = id,
                Callback = cb,
                Timer = new Timer(CallbackWrapper, id, intervalInMilliseconds, intervalInMilliseconds),
            };

            _intervals[id] = entry;
            return id;
        }

        private void CallbackWrapper(object state) {
            var intervalId = (int)state;

            if (_intervals.TryGetValue(intervalId, out var entry)) {
                entry.Callback.Invoke();
            }
        }

        public void ClearInterval(int intervalId) {
            if (_intervals.TryGetValue(intervalId, out var entry)) {
                entry.Timer?.Dispose();
                _intervals.Remove(intervalId);
            }
        }

        private void Print(params object[] args) {
            var message = string.Join(" ", args.Select(a => FormatStackTraces(FormatLuaResult([a])).TrimEnd()));
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
            _timeouts.Clear();
            _intervals.Clear();
            _contexts.Remove(this);
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
            /*
            PreDispose();

            FullGc();

            for (int i = 0; i < 50; i++) {
                GC();
                Tick();
                System.GC.WaitForPendingFinalizers();
                System.GC.Collect();
            }
            */

            //DoString("require('xlua.util').print_func_ref_by_csharp()");
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
