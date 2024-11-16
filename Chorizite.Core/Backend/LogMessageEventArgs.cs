using Microsoft.Extensions.Logging;
using System;

namespace Chorizite.Core.Backend {
    public class LogMessageEventArgs : EventArgs {
        public string Message { get; set; }
        public LogLevel LogLevel { get; set; }

        public LogMessageEventArgs(LogLevel logLevel, string message) {
            LogLevel = logLevel;
            Message = message;
        }
    }
}