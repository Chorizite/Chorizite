namespace MagicHat.Core.Input {
    public class MouseUpEventArgs : EatableEvent {
        public MouseButton Button { get; }
        public MouseUpEventArgs(MouseButton button) {
            Button = button;
        }
    }
}