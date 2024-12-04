using System;

namespace Chorizite.Common {
    public abstract class EatableEventArgs : EventArgs {
        /// <summary>
        /// Set to true to eat this event.
        /// </summary>
        public bool Eat { get; set; } = false;
    }
}