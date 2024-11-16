using Chorizite.Core.Lib;
using System;

namespace Chorizite.Core.Input {
    public class KeyDownEventArgs : EatableEventArgs {
        /// <summary>
        /// The key that was pressed
        /// </summary>
        public Key Key { get; }

        public KeyDownEventArgs(Key key) {
            Key = key;
        }
    }
}