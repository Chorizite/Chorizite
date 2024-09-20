using MagicHat.Core.Input;

namespace MagicHat.Service.Lib.Input {
    public class MouseDownEventArgs : EatableEvent {
        public MouseButton Button { get; }
        public MouseDownEventArgs(MouseButton button) {
            Button = button;
        }
    }
}