using System;

namespace Chorizite.Core.Plugins {
    public class PluginLoadedEventArgs : EventArgs {
        public string Name { get; set; }

        public PluginLoadedEventArgs(string name) {
            Name = name;
        }
    }
}