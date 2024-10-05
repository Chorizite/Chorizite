using System;

namespace MagicHat.Core.Input {
    public class KeyPressEventArgs : EatableEvent {
        /// <summary>
        /// The key that was pressed
        /// </summary>
        public Key Key { get; }
        public string Text { get; }

        public KeyPressEventArgs(Key key, string text) {
            Key = key;
            Text = text;
        }
    }
}