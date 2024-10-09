using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Injector {
    internal enum EntryPointFlags : int {
        None = 0
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct EntryPointParameters {
        public int version = 8;
        public EntryPointFlags flags = EntryPointFlags.None;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string dll_path = "";
        [MarshalAs(UnmanagedType.LPWStr)]
        public string entry_point = "";

        public EntryPointParameters(string dll_path, string entry_point) {
            this.version = 1;
            this.flags = EntryPointFlags.None;
            this.dll_path = dll_path;
            this.entry_point = entry_point;
        }

        public EntryPointParameters(int version, EntryPointFlags flags, string dll_path, string entry_point) {
            this.version = version;
            this.flags = flags;
            this.dll_path = dll_path;
            this.entry_point = entry_point;
        }
    };
}
