using Chorizite.Common;
using Chorizite.Core.Lib;
using Microsoft.Extensions.Logging;

namespace Chorizite.Core.Input {
    /// <summary>
    /// Event arguments for mouse wheel events
    /// </summary>
    public class MouseWheelEventArgs : EatableEventArgs {
        /// <summary>
        /// The change in x
        /// </summary>
        public int DeltaX { get; }

        /// <summary>
        /// The change in y
        /// </summary>
        public int DeltaY { get; }

        /// <summary>
        /// Creates a new mouse wheel event
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        public MouseWheelEventArgs(int deltaX, int deltaY) {
            DeltaX = deltaX;
            DeltaY = deltaY;
        }
    }
}