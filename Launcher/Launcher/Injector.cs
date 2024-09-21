/*
 * Injector code pulled from https://github.com/Mag-nus/Mag-ACClientLauncher
 * https://github.com/Mag-nus/Mag-ACClientLauncher/blob/master/LICENSE
 */


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Launcher
{
    static class Injector
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeLibrary(IntPtr hModule);


        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);



        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            public int nLength;
            public IntPtr lpSecurityDescriptor;
            public int bInheritHandle;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct STARTUPINFO
        {
            public Int32 cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public Int32 dwX;
            public Int32 dwY;
            public Int32 dwXSize;
            public Int32 dwYSize;
            public Int32 dwXCountChars;
            public Int32 dwYCountChars;
            public Int32 dwFillAttribute;
            public Int32 dwFlags;
            public Int16 wShowWindow;
            public Int16 cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public int dwProcessId;
            public int dwThreadId;
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool CreateProcess(
            string lpApplicationName,
            string lpCommandLine,
            ref SECURITY_ATTRIBUTES lpProcessAttributes,
            ref SECURITY_ATTRIBUTES lpThreadAttributes,
            bool bInheritHandles,
            uint dwCreationFlags,
            IntPtr lpEnvironment,
            string lpCurrentDirectory,
            [In] ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInformation);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool CreateProcessA(
            string lpApplicationName,
            string lpCommandLine,
            ref SECURITY_ATTRIBUTES lpProcessAttributes,
            ref SECURITY_ATTRIBUTES lpThreadAttributes,
            bool bInheritHandles,
            uint dwCreationFlags,
            IntPtr lpEnvironment,
            string lpCurrentDirectory,
            [In] ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInformation);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint ResumeThread(IntPtr hThread);


        [Flags]
        public enum AllocationType
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }

        [Flags]
        public enum MemoryProtection
        {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, AllocationType dwFreeType);


        [DllImport("kernel32.dll")]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        public const UInt32 INFINITE = 0xFFFFFFFF;

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int GetExitCodeThread(IntPtr hThread, out uint lpExitCode);

        [DllImport("kernel32.dll", SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);


        /// <summary>
        /// This will start an application using Process.Start() and inject the dll.<para />
        /// If dllFunctionToExecute is defined, it will be called after the dll has been injected.
        /// </summary>
        public static Process RunWithInject(ProcessStartInfo processStartInfo, string pathOfDllToInject, string dllFunctionToExecute = null)
        {
            var process = Process.Start(processStartInfo);

            if (process == null || process.Handle == IntPtr.Zero)
                return null;

            Inject(process, pathOfDllToInject, dllFunctionToExecute);
            return process;
        }

        /// <summary>
        /// This will start an application using kernel32.CreateProcess() suspended, inject the dll and then resume the process.<para />
        /// If dllFunctionToExecute is defined, it will be called after the dll has been injected and before the process is resumed.
        /// </summary>
        /// <remarks>
        /// This function was cleverly named by parad0x, one of the developers of Decal for Asheron's Call.
        /// </remarks>
        public static int RunSuspendedCommaInjectCommaAndResume(string fileName, string arguments, string pathOfDllToInject, string dllFunctionToExecute = null, int PanelHwnd = 0)
        {
            // Reference: https://docs.microsoft.com/en-us/windows/desktop/procthread/process-creation-flags
            const uint CREATE_SUSPENDED = 0x00000004;

            SECURITY_ATTRIBUTES pSec = new SECURITY_ATTRIBUTES();
            pSec.nLength = Marshal.SizeOf(pSec);
            SECURITY_ATTRIBUTES tSec = new SECURITY_ATTRIBUTES();
            tSec.nLength = Marshal.SizeOf(tSec);
            STARTUPINFO sInfo = new STARTUPINFO();

            sInfo.wShowWindow = 4;
            sInfo.dwFlags = 0x00000001 | 0x00000080;

            if (!CreateProcess(null, fileName + " " + arguments, ref pSec, ref tSec, false, CREATE_SUSPENDED, IntPtr.Zero, Path.GetDirectoryName(fileName), ref sInfo, out var pInfo))
                return 0;

            try
            {
                Inject(pInfo.hProcess, pathOfDllToInject, dllFunctionToExecute);
                Inject(pInfo.hProcess, DecalHelpers.GetDecalLocation(), "DecalStartup");

                return pInfo.dwProcessId;
            }
            finally
            {
                //Utils.ShowWindow(pInfo.hProcess, Utils.ShowWindowCommands.ForceMinimize);
                ResumeThread(pInfo.hThread);

                CloseHandle(pInfo.hThread);
                CloseHandle(pInfo.hProcess);
            }
        }

        /// <summary>
        /// This will inject a dll into an existing process defined by process.<para />
        /// If dllFunctionToExecute is defined, it will be called after the dll has been injected.
        /// </summary>
        public static bool Inject(Process process, string pathOfDllToInject, string dllFunctionToExecute = null)
        {
            return Inject(process.Handle, pathOfDllToInject, dllFunctionToExecute);
        }

        /// <summary>
        /// This will inject a dll into an existing process defined by processHandle.<para />
        /// If dllFunctionToExecute is defined, it will be called after the dll has been injected.
        /// </summary>
        public static bool Inject(IntPtr processHandle, string pathOfDllToInject, string dllFunctionToExecute = null)
        {
            // Alocating some memory on the target process - enough to store the name of the dll and storing its address in a pointer
            var dwSize = (uint)((pathOfDllToInject.Length + 1) * Marshal.SizeOf(typeof(char)));

            var allocMemAddress = VirtualAllocEx(processHandle, IntPtr.Zero, dwSize, AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ReadWrite);

            if (allocMemAddress == IntPtr.Zero)
                return false;

            try
            {
                // Writing the name of the dll there
                if (!WriteProcessMemory(processHandle, allocMemAddress, Encoding.Default.GetBytes(pathOfDllToInject), (uint)((pathOfDllToInject.Length + 1) * Marshal.SizeOf(typeof(char))), out _))
                    return false;

                // Searching for the address of LoadLibraryA and storing it in a pointer
                var kernel32Handle = GetModuleHandle("kernel32.dll");
                var loadLibraryAddr = GetProcAddress(kernel32Handle, "LoadLibraryA");

                // Inject the DLL
                var remoteThreadHandle = CreateRemoteThread(processHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

                if (remoteThreadHandle == IntPtr.Zero)
                    return false;

                try
                {
                    WaitForSingleObject(remoteThreadHandle, INFINITE);

                    GetExitCodeThread(remoteThreadHandle, out var injectedDllAddress);

                    if (injectedDllAddress != 0)
                    {
                        // If we have a function to execute, lets do it
                        if (!String.IsNullOrEmpty(dllFunctionToExecute))
                            return Execute(processHandle, injectedDllAddress, pathOfDllToInject, dllFunctionToExecute);

                        return true;
                    }

                    return false;
                }
                finally
                {
                    CloseHandle(remoteThreadHandle);
                }
            }
            finally
            {
                VirtualFreeEx(processHandle, allocMemAddress, dwSize, AllocationType.Release);
            }
        }

        /// <summary>
        /// This will find the address offset of dllFunctionToExecute in pathOfDllToInject, and add that to injectedDllAddress;
        /// It will then use kernel32.CreateRemoteThread() to call that address on processHandle.
        /// </summary>
        public static bool Execute(IntPtr processHandle, uint injectedDllAddress, string pathOfDllToInject, string dllFunctionToExecute)
        {
            var libraryAddress = LoadLibrary(pathOfDllToInject);

            if (libraryAddress == IntPtr.Zero)
                return false;

            try
            {
                var functionAddress = GetProcAddress(libraryAddress, dllFunctionToExecute);

                if (functionAddress == IntPtr.Zero)
                    return false;

                var functionAddressOffset = functionAddress.ToInt64() - libraryAddress.ToInt64();

                var addressToExecute = injectedDllAddress + functionAddressOffset;

                return Execute(processHandle, (IntPtr)addressToExecute);
            }
            finally
            {
                FreeLibrary(libraryAddress);
            }
        }

        /// <summary>
        /// This will use kernel32.CreateRemoteThread() to call addressToExecute on processHandle.
        /// </summary>
        public static bool Execute(IntPtr processHandle, IntPtr addressToExecute)
        {
            var remoteThreadHandle = CreateRemoteThread(processHandle, IntPtr.Zero, 0, addressToExecute, IntPtr.Zero, 0, IntPtr.Zero);

            if (remoteThreadHandle == IntPtr.Zero)
                return false;

            try
            {
                WaitForSingleObject(remoteThreadHandle, INFINITE);

                GetExitCodeThread(remoteThreadHandle, out var exitCode);

                if (exitCode != 0)
                    return true;

                return false;
            }
            finally
            {
                CloseHandle(remoteThreadHandle);
            }
        }
    }
}
