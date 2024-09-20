using MagicHat.Core.Input;

namespace MagicHat.Service.Lib.Input {
    public class MouseUpEventArgs : EatableEvent {
        public MouseButton Button { get; }
        public MouseUpEventArgs(MouseButton button) {
            Button = button;
        }
    }
}