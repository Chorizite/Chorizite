using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Lib {
    public enum LauncherScreen {
        None = 0,
        Simple = 1,
    }

    /// <summary>
    /// GameScreen enum helpers
    /// </summary>
    public static class LauncherScreenHelpers {
        /// <summary>
        /// Create a custom LauncherScreen based on a strings hash code.
        /// Use this to add custom LauncherScreens that are not part of the enum.
        /// </summary>
        /// <returns></returns>
        public static LauncherScreen FromString(string name) {
            return (LauncherScreen)name.GetHashCode();
        }
    }
}
