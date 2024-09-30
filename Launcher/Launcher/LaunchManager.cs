
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Principal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Launcher
{
    internal class LaunchManager
    {
        private readonly string ACCLIENT_EXE = @"C:\Turbine\Asheron's Call\acclient.exe";

        private enum EntryPointFlags : int {
            None = 0
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct EntryPointParameters {
            int version = 8;
            EntryPointFlags flags = EntryPointFlags.None;
            [MarshalAs(UnmanagedType.LPWStr)]
            string dll_path = "";
            [MarshalAs(UnmanagedType.LPWStr)]
            string entry_point = "";

            public EntryPointParameters(int version, EntryPointFlags flags, string dll_path, string entry_point) {
                this.version = version;
                this.flags = flags;
                this.dll_path = dll_path;
                this.entry_point = entry_point;
            }
        };

        [DllImport("MagicHat.Bootstrapper.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern int LaunchInjected(string command_line, string working_directory, IntPtr entryPts, int numEntries);

        public LaunchManager()
        {
        }

        internal unsafe void Launch(string server, string username, string password)
        {
            var host = server.Split(":").First();
            var port = server.Split(":").Last();
            var args = $"-h {host} -p {port} -a {username} -v {password} -rodat off";
            var dll = Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "MagicHat.Bootstrapper.dll");

            var entryPointParams = new EntryPointParameters[] {
                new EntryPointParameters(8, EntryPointFlags.None, dll, "Bootstrap"),
                //new EntryPointParameters(8, EntryPointFlags.None, DecalHelpers.GetDecalLocation(), "DecalStartup"),
            };

            var cbase = Marshal.AllocHGlobal(entryPointParams.Length * sizeof(EntryPointParameters));
            var ccur = cbase;
            for (int i = 0; i < entryPointParams.Length; i++, ccur += sizeof(EntryPointParameters)) {
                Marshal.StructureToPtr(entryPointParams[i], ccur, false);
            }
            
            LaunchInjected($"{ACCLIENT_EXE} {args}", Path.GetDirectoryName(ACCLIENT_EXE), cbase, entryPointParams.Length);
            Marshal.FreeHGlobal(cbase);
        }
    }
}