using MagicHat.Core.Render;

namespace MagicHat.Backends.ACBackend.Render {
    /// <summary>
    /// Screen changed
    /// </summary>
    public class ScreenChangedEventArgs {
        /// <summary>
        /// The previous screen
        /// </summary>
        public GameScreen OldScreen { get; }

        /// <summary>
        /// The new screen
        /// </summary>
        public GameScreen NewScreen { get; }

        public ScreenChangedEventArgs(GameScreen oldScreen, GameScreen newScreen) {
            OldScreen = oldScreen;
            NewScreen = newScreen;
        }
    }
}