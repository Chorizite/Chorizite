using Chorizite.Common;
using Chorizite.Core.Lib;
using System;

namespace Chorizite.Core.Input {
    /// <summary>
    /// Event arguments for mouse move
    /// </summary>
    public class MouseMoveEventArgs : EatableEventArgs {
        /// <summary>
        /// The mouse x position, relative to the window
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The mouse y position, relative to the window
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Creates a new mouse move event
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public MouseMoveEventArgs(int x, int y) {
            X = x;
            Y = y;
        }
    }
}