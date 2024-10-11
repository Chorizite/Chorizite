using System;

namespace MagicHat.Core.Input {
    public class KeyPressEventArgs : EatableEvent {
        public string Text { get; }

        public KeyPressEventArgs(string text) {
            Text = text;
        }
    }
}