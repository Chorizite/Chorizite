using System;

namespace MagicHat.Core.Input {
    public abstract class EatableEvent : EventArgs {
        /// <summary>
        /// Set to true to eat this event.
        /// </summary>
        public bool Eat { get; set; } = false;
    }
}