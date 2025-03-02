using Chorizite.Common;
using Chorizite.Core.Lib;
using System;

namespace Chorizite.Core.Input {
    /// <summary>
    /// Event args for when a key is pressed
    /// </summary>
    public class KeyPressEventArgs : EatableEventArgs {
        /// <summary>
        /// The text of the key
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text"></param>
        public KeyPressEventArgs(string text) {
            Text = text;
        }
    }
}