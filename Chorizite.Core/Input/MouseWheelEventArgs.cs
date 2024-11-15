using Chorizite.Core.Lib;

namespace Chorizite.Core.Input {
    public class MouseWheelEventArgs : EatableEventArgs {
        private int Delta { get; }

        public MouseWheelEventArgs(int delta) {
            Delta = delta;
        }
    }
}