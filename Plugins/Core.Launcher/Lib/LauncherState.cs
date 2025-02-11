﻿namespace Launcher.Lib {
    internal class LauncherState {
        public LauncherScreen CurrentScreen { get; set; } = LauncherScreen.Simple;

        public LauncherState() {
        
        }

        public LauncherState(LauncherScreen currentScreen) {
            CurrentScreen = currentScreen;
        }
    }
}