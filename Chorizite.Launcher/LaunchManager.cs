
using LauncherApp.Lib;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace LauncherApp {
    internal class LaunchManager {
        private readonly ILogger _log;


        [DllImport("Chorizite.Injector.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern int LaunchInjected(string command_line, string working_directory, IntPtr entryPts, int numEntries);

        public LaunchManager(ILogger log) {
            _log = log;
        }

        internal unsafe void Launch(string clientPath, string server, string username, string password) {
            Task.Run(() => {
                var host = server.Split(":").First();
                var port = server.Split(":").Last();
                var clientArgs = $"-h {host} -p {port} -a {username} -v {password} -rodat off";

                var choriziteDll = Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location)!, "Chorizite.Injector.dll");
                var decalDll = DecalHelpers.GetDecalLocation();

                List<EntryPointParameters> dllsToInject = [];

                if (File.Exists(choriziteDll)) {
                    dllsToInject.Add(new EntryPointParameters(choriziteDll, "Bootstrap"));
                }
                else {
                    _log.LogError($"Failed to find Chorizite.Injector.dll at {choriziteDll}");
                }

                if (!string.IsNullOrEmpty(decalDll) && File.Exists(decalDll)) {
                    //dllsToInject.Add(new EntryPointParameters(decalDll, "DecalStartup"));
                }

                LaunchClientWithInjected(clientPath, clientArgs, dllsToInject.ToArray());
            });
        }

        private unsafe static void LaunchClientWithInjected(string clientPath, string clientArgs, EntryPointParameters[] entryPointParams) {
            var dir = Path.GetDirectoryName(typeof(Program).Assembly.Location) ?? Environment.CurrentDirectory;

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
            var cbase = Marshal.AllocHGlobal(entryPointParams.Length * sizeof(EntryPointParameters));
            var ccur = cbase;
            for (int i = 0; i < entryPointParams.Length; i++, ccur += sizeof(EntryPointParameters)) {
                LauncherApp.Program.Log.LogDebug($"Injecting: {entryPointParams[i].dll_path} {entryPointParams[i].entry_point}");
                Marshal.StructureToPtr(entryPointParams[i], ccur, false);
            }
#pragma warning restore CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type

            LaunchInjected($"{clientPath} {clientArgs}", Path.GetDirectoryName(clientPath)!, cbase, entryPointParams.Length);
            Marshal.FreeHGlobal(cbase);
        }
    }
}