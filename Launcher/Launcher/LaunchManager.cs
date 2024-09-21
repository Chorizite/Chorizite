
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace Launcher
{
    internal class LaunchManager
    {
        private readonly string ACCLIENT_EXE = @"C:\Turbine\Asheron's Call\acclient.exe";

        [DllImport("Reloaded.Mod.Loader.Bootstrapper.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern int LaunchInjected(string command_line, string working_directory, string inject_dll_path, [MarshalAs(UnmanagedType.LPStr)] string initialize_function);

        public LaunchManager()
        {
        }

        internal void Launch(string server, string username, string password)
        {
            var host = server.Split(":").First();
            var port = server.Split(":").Last();
            var args = $"-h {host} -p {port} -a {username} -v {password} -rodat";
            var dll = Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "Reloaded.Mod.Loader.Bootstrapper.dll"); 

            LaunchInjected($"{ACCLIENT_EXE} {args}", Path.GetDirectoryName(ACCLIENT_EXE), dll, "Bootstrap");
            //LaunchInjected($"{ACCLIENT_EXE} {args}", Path.GetDirectoryName(ACCLIENT_EXE), DecalHelpers.GetDecalLocation(), "");
        }
    }
}