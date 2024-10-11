using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Lib {
    public interface ScreenProvider<T> where T : Enum {
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
    }
}
