using Chorizite.Core.Backend;
using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace Chorizite.Core.Logging {
    /// <summary>
    /// Logger for Chorizite
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ChoriziteLogger<T> : ChoriziteLogger, ILogger<T> {
        /// <summary>
        /// Creates a new ChoriziteLogger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="logDirectory"></param>
        public ChoriziteLogger(Type type, string logDirectory) : base(type, logDirectory) {

        }

        /// <summary>
        /// Creates a new ChoriziteLogger
        /// </summary>
        /// <param name="name"></param>
        /// <param name="logDirectory"></param>
        public ChoriziteLogger(string name, string logDirectory) : base(name, logDirectory) {

        }
    }

    /// <summary>
    /// Logger for Chorizite
    /// </summary>
    public class ChoriziteLogger : ILogger {
        /// <summary>
        /// The name of the logger
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The directory to log to
        /// </summary>
        public string LogDirectory { get; }

        /// <summary>
        /// Creates a new ChoriziteLogger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="logDirectory"></param>
        public ChoriziteLogger(Type type, string logDirectory) : this(type.Name, logDirectory) {

        }

        /// <summary>
        /// Creates a new ChoriziteLogger
        /// </summary>
        /// <param name="name"></param>
        /// <param name="logDirectory"></param>
        public ChoriziteLogger(string name, string logDirectory) {
            Name = name;
            LogDirectory = logDirectory;
        }

        /// <inheritdoc/>
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull {
            return null;
        }

        /// <inheritdoc/>
        public bool IsEnabled(LogLevel logLevel) { 
            return logLevel > LogLevel.Trace;
        }

        /// <inheritdoc/>
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
