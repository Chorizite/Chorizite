using Chorizite.Common;
using Chorizite.Core.Lib;

namespace Chorizite.Core.Input {
    /// <summary>
    /// Args for when a mouse button is pressed
    /// </summary>
    public class MouseDownEventArgs : EatableEventArgs {
        /// <summary>
        /// The mouse button that was pressed
        /// </summary>
        public MouseButton Button { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="button"></param>
        public MouseDownEventArgs(MouseButton button) {
            Button = button;
        }
    }
}