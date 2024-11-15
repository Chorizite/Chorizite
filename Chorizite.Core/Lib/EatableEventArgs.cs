using System;

namespace Chorizite.Core.Lib {
    public abstract class EatableEventArgs : EventArgs {
        /// <summary>
        /// Set to true to eat this event.
        /// </summary>
        public bool Eat { get; set; } = false;
    }
}