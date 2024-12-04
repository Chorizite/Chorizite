using Chorizite.Common;
using Chorizite.Core.Lib;

namespace Chorizite.Core.Input {
    public class MouseDownEventArgs : EatableEventArgs {
        public MouseButton Button { get; }
        public MouseDownEventArgs(MouseButton button) {
            Button = button;
        }
    }
}