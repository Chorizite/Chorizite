using Microsoft.Extensions.Logging;
using System;

namespace Chorizite.Core.Backend {
    /// <summary>
    /// event args for log messages
    /// </summary>
    public class LogMessageEventArgs : EventArgs {
        /// <summary>
        /// The name of the logger
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The log level
        /// </summary>
        public LogLevel Level { get; }

        /// <summary>
        /// The message
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        public LogMessageEventArgs(string name, LogLevel logLevel, string message) {
            Name = name;
            Level = logLevel;
            Message = message;
        }
    }
}