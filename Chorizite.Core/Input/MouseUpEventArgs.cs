using Chorizite.Common;
using Chorizite.Core.Lib;

namespace Chorizite.Core.Input {
    /// <summary>
    /// Event args for a mouse button up
    /// </summary>
    public class MouseUpEventArgs : EatableEventArgs {
        /// <summary>
        /// The mouse button that was released
        /// </summary>
        public MouseButton Button { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="button"></param>
        public MouseUpEventArgs(MouseButton button) {
            Button = button;
        }
    }
}