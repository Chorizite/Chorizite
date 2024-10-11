using MagicHat.Core.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core.Backend {

    public interface ILauncherBackend : IDisposable {
        void SetWindowSize(int width, int height);
        void Exit();
        void LaunchClient(string clientPath, string server, string username, string password);
    }
}
