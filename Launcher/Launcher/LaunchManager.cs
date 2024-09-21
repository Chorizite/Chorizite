
using System.Security.Principal;

namespace Launcher
{
    internal class LaunchManager
    {
        private readonly string ACCLIENT_EXE = @"C:\Turbine\Asheron's Call\acclient.exe";

        public LaunchManager()
        {
        }

        internal void Launch(string server, string username, string password)
        {
            var host = server.Split(":").First();
            var port = server.Split(":").Last();
            var args = $"-h {host} -p {port} -a {username} -v {password} -rodat";
            var dll = "D:\\projects\\ACUI\\bin\\Reloaded.Mod.Loader.Bootstrapper.dll";

            Injector.RunSuspendedCommaInjectCommaAndResume(ACCLIENT_EXE, args, dll, "", 0);
        }
    }
}