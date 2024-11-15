using System;

namespace Core.AC.Lib.Screens {
    /// <summary>
    /// Screen changed
    /// </summary>
    public class ScreenChangedEventArgs : EventArgs {
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