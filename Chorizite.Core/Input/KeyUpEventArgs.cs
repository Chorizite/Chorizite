using Chorizite.Common;
using Chorizite.Core.Lib;
using System;

namespace Chorizite.Core.Input {
    /// <summary>
    /// Event args for when a key is released
    /// </summary>
    public class KeyUpEventArgs : EatableEventArgs {
        /// <summary>
        /// The key that was released
        /// </summary>
        public Key Key { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key"></param>
        public KeyUpEventArgs(Key key) {
            Key = key;
        }
    }
}