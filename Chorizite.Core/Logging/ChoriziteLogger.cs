using Chorizite.Core.Backend;
using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace Chorizite.Core.Logging {
    public class ChoriziteLogger<T> : ChoriziteLogger, ILogger<T> {
        public ChoriziteLogger(Type type, string logDirectory) : base(type, logDirectory) {

        }

        public ChoriziteLogger(string name, string logDirectory) : base(name, logDirectory) {

        }
    }

    public class ChoriziteLogger : ILogger {
        public string Name { get; }

        public string LogDirectory { get; }

        public ChoriziteLogger(Type type, string logDirectory) : this(type.Name, logDirectory) {

        }

        public ChoriziteLogger(string name, string logDirectory) {
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
            ChoriziteStatics.HandleLogMessage(new LogMessageEventArgs(Name, logLevel, $"{formatter(state, exception)} {exception?.ToString() ?? ""}"));
            if (!IsEnabled(logLevel)) {
                return;
            }
            try {
                var msg = $"[{Name}:{logLevel}] {formatter(state, exception)} {exception?.ToString() ?? ""}\n";
                Console.Write(msg);
                if (!System.IO.Directory.Exists(LogDirectory)) {
                    System.IO.Directory.CreateDirectory(LogDirectory);
                }
                var logPath = System.IO.Path.Combine(LogDirectory, $"log.txt");
                System.IO.File.AppendAllText(logPath, msg);
            } catch { }
        }
    }
}
