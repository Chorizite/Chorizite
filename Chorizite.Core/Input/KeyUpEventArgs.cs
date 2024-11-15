using Chorizite.Core.Lib;
using System;

namespace Chorizite.Core.Input {
    public class KeyUpEventArgs : EatableEventArgs {
        /// <summary>
        /// The key that was released
        /// </summary>
        public Key Key { get; }

        public KeyUpEventArgs(Key key) {
            Key = key;
        }
    }
}