using System.Diagnostics;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.Extensions.Logging;

namespace AcClient {
    public class MultiHook {
        internal IntPtr Entrypoint;
        internal Delegate? Del;

        internal List<int> CallLocations = new List<int>();
        internal List<Hook> Hooks = new List<Hook>();

        public MultiHook(int entrypoint, params int[] callLocations) {
            Entrypoint = (IntPtr)entrypoint;
            CallLocations.AddRange(callLocations);
            Hooks.AddRange(callLocations.Select(c => new Hook((int)Entrypoint, c)));
        }

        public bool Setup(Delegate del) {
            Del = del;
            return !Hooks.Any(h => !h.Setup(del));
        }

        public bool Remove() {
            return !Hooks.Any(h => !h.Remove());
        }
    }

    /// <summary>
    /// New improved Hooker
    /// </summary>
    public class Hook {
        internal IntPtr Entrypoint;
        internal Delegate? Del;
        internal int call;

        public Hook(int entrypoint, int call_location) {
            Entrypoint = (IntPtr)entrypoint;
            call = call_location;
        }
        public bool Setup(Delegate del) {
            if (!hookers.Contains(this)) {
                Del = del;
                if (ReadCall(call) != (int)Entrypoint) {
                    return false;
                }
                if (!PatchCall(call, Marshal.GetFunctionPointerForDelegate(Del))) {
                    return false;
                }
                else {
                    hookers.Add(this);
                    return true;
                }
            }
            return false;
        }
        public bool Remove() {
            if (hookers.Contains(this)) {
                hookers.Remove(this);
                if (PatchCall(call, Entrypoint)) {
                    return true;
                }
            }
            return false;
        }


        // static half
        internal static System.Collections.Generic.List<Hook> hookers = new System.Collections.Generic.List<Hook>();
        [DllImport("kernel32.dll")] internal static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, int flNewProtect, out int lpflOldProtect);

        internal static void Write(IntPtr address, int newValue) {
            unsafe {
                VirtualProtectEx(Process.GetCurrentProcess().Handle, address, (UIntPtr)4, 0x40, out int b);
                *(int*)address = newValue;
                VirtualProtectEx(Process.GetCurrentProcess().Handle, address, (UIntPtr)4, b, out b);
            }
        }
        internal static bool PatchCall(int callLocation, IntPtr newPointer) {
            unsafe {
                if (((*(byte*)callLocation) & 0xFE) != 0xE8)
                    return false;
                int previousOffset = *(int*)(callLocation + 1);
                int previousPointer = previousOffset + (callLocation + 5);
                int newOffset = (int)newPointer - (callLocation + 5);
                Write((IntPtr)(callLocation + 1), newOffset);
                return true;
            }
        }
        internal static int ReadCall(int callLocation) {
            unsafe {
                if (((*(byte*)callLocation) & 0xFE) != 0xE8)
                    return 0;
                int previousOffset = *(int*)(callLocation + 1);
                int previousPointer = previousOffset + (callLocation + 5);
                return previousPointer;
            }
        }
        internal static void Cleanup() {
            for (int i = hookers.Count - 1; i > -1; i--)
                hookers[i].Remove();
        }
    }

    /// <summary>
    /// New improved Hooker (Virtual edition, brought to you by Carls Jr.)
    /// </summary>
    public class VHook {
        internal int Entrypoint;
        internal Delegate? Del;
        internal int call;

        public VHook(int entrypoint, int vtbl_address) {
            Entrypoint = entrypoint;
            call = vtbl_address;
        }
        public bool Setup(Delegate del) {
            if (!hookers.Contains(this)) {
                Del = del;
                if (ReadVCall(call) != Entrypoint || Del == null) return false;
                if (PatchVCall(call, (int)Marshal.GetFunctionPointerForDelegate(Del))) {
                    hookers.Add(this);
                    return true;
                }
            }
            return false;
        }
        public bool Remove() {
            if (hookers.Contains(this)) {
                hookers.Remove(this);
                return PatchVCall(call, Entrypoint);
            }
            return false;
        }

        // static half
        internal static System.Collections.Generic.List<VHook> hookers = new System.Collections.Generic.List<VHook>();
        internal static bool PatchVCall(int callLocation, int newPointer) {
            unsafe {
                Hook.Write((IntPtr)(callLocation), newPointer);
                return *(int*)callLocation == newPointer;
            }
        }
        internal unsafe static int ReadVCall(int callLocation) => *(int*)callLocation;
        internal static void Cleanup() {
            for (int i = hookers.Count - 1; i > -1; i--)
                hookers[i].Remove();
        }
    }
}
