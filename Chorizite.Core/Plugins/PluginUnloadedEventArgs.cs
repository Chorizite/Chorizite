using System;

namespace Chorizite.Core.Plugins {
    public class PluginUnloadedEventArgs : EventArgs {
        public string Name { get; set; }

        public PluginUnloadedEventArgs(string name) {
            Name = name;
        }
    }
}