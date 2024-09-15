using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace MagicHat.Service.Lib.Logging {
    internal class MagicHatLogger<T> : MagicHatLogger, ILogger<T> {
        public MagicHatLogger(Type type) : base(type) {

        }

        public MagicHatLogger(string name) : base(name) {

        }
    }

    internal class MagicHatLogger : ILogger {
        private string Name;

        public MagicHatLogger(Type type) {
            Name = type.Name;
        }

        public MagicHatLogger(string name) {
            Name = name;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel) {
            return logLevel > LogLevel.Trace;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) {
            if (!IsEnabled(logLevel)) {
                return;
            }
            try {
                var logPath = System.IO.Path.Combine(MagicHatService.AssemblyDirectory, $"log.txt");
                System.IO.File.AppendAllText(logPath, $"[{Name}:{logLevel}] {formatter(state, exception)} {exception?.ToString() ?? ""}\n");
            } catch { }
        }
    }
}
