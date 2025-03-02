using Chorizite.Common;
using Chorizite.Core.Lib;
using System;

namespace Chorizite.Core.Input {
    /// <summary>
    /// Event args for when a key is pressed
    /// </summary>
    public class KeyDownEventArgs : EatableEventArgs {
        /// <summary>
        /// The key that was pressed
        /// </summary>
        public Key Key { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key"></param>
        public KeyDownEventArgs(Key key) {
            Key = key;
        }
    }
}