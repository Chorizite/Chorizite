namespace Chorizite.Core.Input {
    public class MouseDownEventArgs : EatableEvent {
        public MouseButton Button { get; }
        public MouseDownEventArgs(MouseButton button) {
            Button = button;
        }
    }
}