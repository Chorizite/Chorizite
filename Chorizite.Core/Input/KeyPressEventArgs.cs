using Chorizite.Common;
using Chorizite.Core.Lib;
using System;

namespace Chorizite.Core.Input {
    public class KeyPressEventArgs : EatableEventArgs {
        public string Text { get; }

        public KeyPressEventArgs(string text) {
            Text = text;
        }
    }
}