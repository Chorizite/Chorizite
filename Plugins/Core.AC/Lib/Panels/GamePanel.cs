using Core.AC.Lib.Screens;

namespace Core.AC.Lib.Panels {
    public enum GamePanel {
        Logs,
        Chat,
        Tooltip
    }

    /// <summary>
    /// GamePanel enum helpers
    /// </summary>
    public static class GamePanelHelpers {
        /// <summary>
        /// Create a custom GamePanel based on a strings hash code.
        /// Use this to add custom GamePanels that are not part of the enum.
        /// </summary>
        /// <returns></returns>
        public static GamePanel FromString(string name) {
            return (GamePanel)name.GetHashCode();
        }
    }
}