using Chorizite.Core.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend.Launcher {
    /// <summary>
    /// Interface for the launcher backend
    /// </summary>
    public interface ILauncherBackend : IDisposable {
        /// <summary>
        /// Sets the window size
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void SetWindowSize(int width, int height);

        /// <summary>
        /// Closes the launcher
        /// </summary>
        void Exit();

        /// <summary>
        /// Launches the client
        /// </summary>
        /// <param name="clientPath"></param>
        /// <param name="server"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        void LaunchClient(string clientPath, string server, string username, string password);

        /// <summary>
        /// Minimizes the launcher
        /// </summary>
        void Minimize();

        /// <summary>
        /// Gets the default client path
        /// </summary>
        /// <returns></returns>
        string GetDefaultClientPath();
    }
}
