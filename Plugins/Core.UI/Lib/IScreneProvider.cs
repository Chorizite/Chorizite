using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Lib {
    /// <summary>
    /// Interface for a screen provider. Plugins that provide screens to Core.UI should implement this interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IScreenProvider<T> where T : Enum {
        /// <summary>
        /// The current screen
        /// </summary>
        public T CurrentScreen { get; set; }

        /// <summary>
        /// Registers a screen with the core UI.
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="rmlPath"></param>
        /// <returns></returns>
        public bool RegisterScreen(T screen, string rmlPath);

        /// <summary>
        /// Unregisters a screen with the core UI.
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="rmlPath"></param>
        public void UnregisterScreen(T screen, string rmlPath);

        /// <summary>
        /// Create a custom T enum entry from a string name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T CustomScreenFromName(string name);
    }
}