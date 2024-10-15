using System;

namespace Chorizite.Core.Input {
    public class KeyDownEventArgs : EatableEvent {
        /// <summary>
        /// The key that was pressed
        /// </summary>
        public Key Key { get; }

        public KeyDownEventArgs(Key key) {
            Key = key;
        }
    }
}