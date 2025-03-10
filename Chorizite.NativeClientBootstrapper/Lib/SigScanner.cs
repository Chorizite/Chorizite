using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.NativeClientBootstrapper.Lib {
    internal class SigScanner {
        [DllImport("SigScan.dll", EntryPoint = "InitializeSigScan")]
        private static extern void InitializeSigScan(uint iPID, [MarshalAs(UnmanagedType.LPStr)] string szModule);
        [DllImport("SigScan.dll", EntryPoint = "SigScan")]
        private static extern UInt32 SigScan([MarshalAs(UnmanagedType.LPStr)] string Pattern, int Offset);
        [DllImport("SigScan.dll", EntryPoint = "FinalizeSigScan")]
        private static extern void FinalizeSigScan();


        public static unsafe uint Scan(string pattern) {
            var thisProcess = Process.GetCurrentProcess();
            var baseAddress = thisProcess.MainModule.BaseAddress;
            var exeSize = thisProcess.MainModule.ModuleMemorySize;

            InitializeSigScan((uint)thisProcess.Id, "acclient.exe");
            uint memloc = SigScan(pattern.Replace(" ", ""), 0);
            FinalizeSigScan();

            return memloc;
        }
    }
}
