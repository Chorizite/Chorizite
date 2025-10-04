namespace Chorizite.Core.Input {
    /// <summary>
    /// Arguments for the WindowResized event
    /// </summary>
    public class WindowResizedEventArgs {
        /// <summary>
        /// The new width
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// The new height
        /// </summary>
        public int Height { get; }

        public WindowResizedEventArgs(int width, int height) {
            this.Width = width;
            this.Height = height;
        }
    }
}