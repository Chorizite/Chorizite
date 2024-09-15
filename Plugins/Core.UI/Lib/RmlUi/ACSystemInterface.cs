using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;

namespace ACUI.Lib.RmlUi {
    public class ACSystemInterface : SystemInterface {
        private readonly DateTime _start;
        private readonly ILogger? _log;

        public override double ElapsedTime => (DateTime.UtcNow - _start).TotalSeconds;

        public ACSystemInterface(ILogger? logger) {
            _start = DateTime.UtcNow;
            _log = logger;

        }

        public override string TranslateString(out int changeCount, string input) {
            //UIPluginCore.Log($"TranslateString called with {input}");
            return base.TranslateString(out changeCount, input);
        }

        public override bool LogMessage(LogType type, string message) {
            _log?.LogInformation($"[RmlUi] {message}");
            return true;
        }

        public override string JoinPath(string path, string file) {
            string newPath;
            if (System.IO.Path.DirectorySeparatorChar == '\\') {
                newPath = base.JoinPath(path.Replace(@"/", @"\"), file.Replace(@"/", @"\"));
            }
            else {
                newPath = base.JoinPath(path, file);
            }
            _log?.LogDebug($"JOIN PATH: {path} WITH {file} INTO {newPath}");
            return newPath;
        }
    }
}
