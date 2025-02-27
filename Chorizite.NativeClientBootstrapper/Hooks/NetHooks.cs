using Microsoft.Extensions.Logging;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Chorizite.NativeClientBootstrapper.Hooks {
    internal unsafe class NetHooks : HookBase {
        private static IHook<SendTo> _sendtoHook;
        private static IHook<RecvFrom> _recvfromHook;

        [Function(CallingConventions.Stdcall)]
        private delegate nint SendTo(nint s, byte* buf, int len, int flags, byte* to, int tolen);

        [Function(CallingConventions.Stdcall)]
        private delegate int RecvFrom(nint s, byte* buf, int len, int flags, byte* from, int fromlen);

        internal static void Init() {
            _sendtoHook = CreateHook<SendTo>(typeof(NetHooks), nameof(SendToImpl), *(int*)0x007935A4);
            _recvfromHook = CreateHook<RecvFrom>(typeof(NetHooks), nameof(RecvFromImpl), *(int*)0x007935AC);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static nint SendToImpl(nint s, byte* buf, int len, int flags, byte* to, int tolen) {
            try {
                var bytes = new byte[len];
                Marshal.Copy((nint)buf, bytes, 0, len);
                StandaloneLoader.Backend?.HandleC2SPacketData(bytes);
            }
            catch (Exception ex) {
                StandaloneLoader.Log.LogError(ex, $"SendTo Error: {ex.Message}");
            }
            return _sendtoHook.OriginalFunction(s, buf, len, flags, to, tolen);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static int RecvFromImpl(nint s, byte* buf, int len, int flags, byte* from, int fromlen) {
            var bytesRead = _recvfromHook.OriginalFunction(s, buf, len, flags, from, fromlen);
            if (bytesRead > 0) {
                try {
                    var bytes = new byte[bytesRead];
                    Marshal.Copy((nint)buf, bytes, 0, bytesRead);
                    StandaloneLoader.Backend?.HandleS2CPacketData(bytes);
                }
                catch (Exception ex) {
                    StandaloneLoader.Log.LogError(ex, $"RecvFrom Error: {ex.Message}");
                }
            }
            return bytesRead;
        }
    }
}