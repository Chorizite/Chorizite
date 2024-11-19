using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XLua;

namespace Core.Lua.Lib {
    public class LuaContext : LuaEnv {
        private readonly ILogger _log;
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        internal LuaContext(string luaScriptsPath, ILogger log) : base() {
            _log = log;
            AddLoader((ref string filename) => {
                if (filename.StartsWith("framework.") && !filename.EndsWith(".lua")) {
                    var lib = filename.Substring("framework.".Length);
                    var libPath = Path.Combine(luaScriptsPath, Path.Combine("framework", $"{lib}.lua"));
                    if (File.Exists(libPath)) {
                        return File.ReadAllBytes(libPath);
                    }
                }
                return null!;
            });

            Global.Set("__sleep", Sleep);
            Global.Set("print", Print);

            var initPath = Path.Combine(luaScriptsPath, "init.lua");
            if (File.Exists(initPath)) {
                var lua_init = File.ReadAllText(initPath);
                DoString(lua_init, "Init");
            }
        }

        public string FormatLuaResult(object[]? result, int maxDepth = 2, int depth = 0) {
            return (result?.Length > 0 ? string.Join(", ", result.Select(x => LuaTypeToFriendlyString(x, maxDepth, depth))) : "nil");
        }

        public string LuaTypeToFriendlyString(object obj, int maxDepth = 2, int depth = 0) {
            if (obj is null) return "nil";

            if (obj is LuaTable luaTable) {
                var tableStr = new StringBuilder();

                luaTable.ForEach<object, object>((key, value) => {
                    tableStr.AppendLine($"[{key}] = {value}");
                });
                return string.IsNullOrEmpty(tableStr.ToString()) ? "empty table" : tableStr.ToString();
            }

            return $"({obj.GetType().Name}) {obj}";
        }

        private void Print(params object[] args) {
            _log?.LogDebug($"[Lua] {FormatLuaResult(args)}");
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
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();

            Global.Set<string, object>("__sleep", null!);
            Global.Set<string, object>("print", null!);
            Global.Set<string, object>("CS", null!);
            FullGc();

            for (int i = 0; i < 100; i++) {
                GC();
                Tick();
                System.GC.WaitForPendingFinalizers();
                System.GC.Collect();
            }

            try {
                base.Dispose(disposing);
            }
            catch (Exception ex) {
                _log?.LogError(ex.Message);
            }
        }
    }
}
