using Chorizite.Common;
using Chorizite.Core.Lib;
using Microsoft.Extensions.Logging;

namespace Chorizite.Core.Input {
    public class MouseWheelEventArgs : EatableEventArgs {
        public int DeltaX { get; }
        public int DeltaY { get; }

        public MouseWheelEventArgs(int deltaX, int deltaY) {
            DeltaX = deltaX;
            DeltaY = deltaY;
        }
    }
}