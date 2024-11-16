using Chorizite.Core.Lib;

namespace Chorizite.Core.Input {
    public class MouseUpEventArgs : EatableEventArgs {
        public MouseButton Button { get; }
        public MouseUpEventArgs(MouseButton button) {
            Button = button;
        }
    }
}