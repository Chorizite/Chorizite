using System;

namespace MagicHat.Core.Input {
    public class KeyPressEventArgs : EventArgs {
        /// <summary>
        /// The key that was pressed
        /// </summary>
        public Key Key { get; }

        public KeyPressEventArgs(Key key) {
            Key = key;
        }
    }
}