﻿using System;

namespace MagicHat.Core.Input {
    public class KeyUpEventArgs : EventArgs {
        /// <summary>
        /// The key that was released
        /// </summary>
        public Key Key { get; }

        public KeyUpEventArgs(Key key) {
            Key = key;
        }
    }
}