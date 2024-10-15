namespace Chorizite.Core.Input {
    public class MouseWheelEventArgs : EatableEvent {
        private int Delta { get; }

        public MouseWheelEventArgs(int delta) {
            Delta = delta;
        }
    }
}