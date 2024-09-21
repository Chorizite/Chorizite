using MagicHat.Core.Input;

namespace MagicHat.DecalService.Lib.Input {
    public class MouseWheelEventArgs : EatableEvent {
        private int Delta { get; }

        public MouseWheelEventArgs(int delta) {
            Delta = delta;
        }
    }
}