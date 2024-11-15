using Chorizite.Core.Lib;
using System;

namespace Chorizite.Core.Input {
    public class MouseMoveEventArgs : EatableEventArgs {
        public int X { get; set; }
        public int Y { get; set; }

        public MouseMoveEventArgs(int x, int y) {
            X = x;
            Y = y;
        }
    }
}