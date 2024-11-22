using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using XLua;

namespace Chorizite.Core.Lua {
    public class LuaContext : LuaEnv {
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

        private void InitGlobals() {
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
            var items = _timeoutQueue.Where(x => x.Expiration <= DateTime.Now).ToArray();
            foreach (var item in items) {
                _timeoutQueue.Remove(item);
                try {
                    item.Callback();
                }
                catch (Exception ex) {
                    _log.LogError(FormatDocumentException(ex));
                }
            }

            Tick();
        }

        public string FormatDocumentException(Exception ex) {
            return FormatStackTraces(ex.Message);
        }

        private string FormatStackTraces(string message) {
            var lines = message?.Split('\n') ?? Array.Empty<string>();
            var strBuilder = new StringBuilder();
            foreach (var line in lines) {
                if (_luaDocExceptionRe.IsMatch(line)) {
                    var m = _luaDocExceptionRe.Match(line);
                    if (int.TryParse(m.Groups[2].Value, out var docLine) && int.TryParse(m.Groups[3].Value, out var luaLine)) {
                        strBuilder.AppendLine(line.Replace(m.Groups[0].Value, $"{m.Groups[1].Value}:{docLine + luaLine - 1}: {m.Groups[4].Value}"));
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

        private object? Require(string module) {
            return module switch {
                "backend" => ChoriziteStatics.Backend,
                _ => _originalRequire.Call(module),
            };
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
            File.AppendAllText(@"D:\projects\Chorizite\bin\net8.0\data\logs\log.txt", $"[LUA] {message}\n");
        }

        /// <summary>
        /// Sleep for a given number of milliseconds
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public async Task Sleep(int ms) {
            try {
                await Task.Delay(ms, cancellationTokenSource.Token);
            }
            catch (TaskCanceledException) {
            }
        }

        public override void Dispose(bool disposing) {
            if (_isDisposed) return;
            _isDisposed = true;

            _timeoutQueue.Clear();
            _contexts.Remove(this);
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
            FullGc();

            for (int i = 0; i < 100; i++) {
                if (i == 50) {
                    DoString("require('xlua.util')[0].print_func_ref_by_csharp()");
                }
                GC();
                Tick();
                System.GC.WaitForPendingFinalizers();
                System.GC.Collect();
            }

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
