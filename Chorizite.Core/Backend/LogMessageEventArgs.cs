using Microsoft.Extensions.Logging;
using System;

namespace Chorizite.Core.Backend {
    public class LogMessageEventArgs : EventArgs {
        public string Name { get; }
        public LogLevel Level { get; }
        public string Message { get; }

        public LogMessageEventArgs(string name, LogLevel logLevel, string v) {
            Name = name;
            Level = logLevel;
            Message = v;
        }
    }
}