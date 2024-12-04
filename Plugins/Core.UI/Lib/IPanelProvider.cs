using ACUI.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Lib {
    /// <summary>
    /// Interface for a panel provider. Plugins that provide panels to Core.UI should implement this interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPanelProvider<T> where T : Enum {
        /// <summary>
        /// Registers a panel with the core UI.
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="rmlPath"></param>
        /// <returns></returns>
        public Panel? RegisterPanel(T panel, string rmlPath);

        /// <summary>
        /// Unregisters a panel with the core UI.
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="rmlPath"></param>
        public void UnregisterPanel(T panel, string rmlPath);

        /// <summary>
        /// Create a custom T enum entry from a string name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T CustomPanelFromName(string name);

        /// <summary>
        /// Checks if a panel is visible.
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        public bool IsPanelVisible(T panel);

        /// <summary>
        /// Toggles the visibility of a panel.
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="visible"></param>
        public void TogglePanelVisibility(T panel, bool visible);
    }
}
