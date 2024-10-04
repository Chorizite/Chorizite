using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace MagicHat.Core.Logging {
    public class MagicHatLogger<T> : MagicHatLogger, ILogger<T> {
        public MagicHatLogger(Type type, string logDirectory) : base(type, logDirectory) {

        }

        public MagicHatLogger(string name, string logDirectory) : base(name, logDirectory) {

        }
    }

    public class MagicHatLogger : ILogger {
        public string Name { get; }

        public string LogDirectory { get; }

        public MagicHatLogger(Type type, string logDirectory) : this(type.Name, logDirectory) {

        }

        public MagicHatLogger(string name, string logDirectory) {
            Name = name;
            LogDirectory = logDirectory;
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
                var logPath = System.IO.Path.Combine(LogDirectory, $"log.txt");
                System.IO.File.AppendAllText(logPath, $"[{Name}:{logLevel}] {formatter(state, exception)} {exception?.ToString() ?? ""}\n");
            } catch { }
        }
    }
}
