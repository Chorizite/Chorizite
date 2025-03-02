using AcClient;
using Iced.Intel;
using Chorizite.Core.Render;
using Chorizite.NativeClientBootstrapper.Lib;
using Microsoft.Extensions.Logging;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Chorizite.Core.Logging;
using Chorizite.ACProtocol;
using System.Linq;

namespace Chorizite.NativeClientBootstrapper.Hooks {
    internal unsafe class ACClientDMHooks : HookBase {
        private static IHook<SendTo>? _sendtoHook;
        private static IHook<RecvFrom>? _recvfromHook;
        private static ILogger? _log;
        private static MessageReader? _messageReader;
        private static PacketReader? _packetReader;

        [Function(CallingConventions.Stdcall)]
        private delegate nint SendTo(nint s, byte* buf, int len, int flags, byte* to, int tolen);

        [Function(CallingConventions.Stdcall)]
        private delegate int RecvFrom(nint s, byte* buf, int len, int flags, byte* from, int fromlen);

        internal static double InactiveTimeBeforeLogout {
            get => *(double*)0x007CEB70;
            set => Native.WriteProtected(0x007CEB70, value);
        }
        internal static void Init() {
            _sendtoHook = CreateHook<SendTo>(typeof(ACClientDMHooks), nameof(SendToImpl), *(int*)0x00630644);
            _recvfromHook = CreateHook<RecvFrom>(typeof(ACClientDMHooks), nameof(RecvFromImpl), *(int*)0x0063063C);

            _log = StandaloneLoader.Log;

            _messageReader = new MessageReader();
            _packetReader = new PacketReader(_log, _messageReader);

            _packetReader.OnC2SPacket += C2SPacketHandler;
            _packetReader.OnS2CPacket += S2CPacketHandler;
        }

        private static void S2CPacketHandler(object? sender, PacketEventArgs e) {
            try {
                _log?.LogDebug($"Got packet: {e.Packet.Header.Flags}");
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"packetReader.OnS2CPacket Error: {ex.Message}");
            }
        }

        private static void C2SPacketHandler(object? sender, PacketEventArgs e) {
            try {
                _log?.LogDebug($"Sent packet: {e.Packet.Header.Flags}");
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"packetReader.C2SPacketHandler Error: {ex.Message}");
            }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static nint SendToImpl(nint s, byte* buf, int len, int flags, byte* to, int tolen) {
            try {
                var bytes = new byte[len];
                Marshal.Copy((nint)buf, bytes, 0, len);
                _log?.LogDebug($"Sending packet: {FormatBytes(bytes)}");
                _packetReader?.HandleC2SPacket(bytes);
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"SendTo Error: {ex.Message}");
            }
            return _sendtoHook!.OriginalFunction(s, buf, len, flags, to, tolen);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static int RecvFromImpl(nint s, byte* buf, int len, int flags, byte* from, int fromlen) {
            var bytesRead = _recvfromHook!.OriginalFunction(s, buf, len, flags, from, fromlen);
            if (bytesRead > 0) {
                try {
                    var bytes = new byte[bytesRead];
                    Marshal.Copy((nint)buf, bytes, 0, bytesRead);
                    _log?.LogDebug($"Recv packet: {FormatBytes(bytes)}");
                    _packetReader?.HandleS2CPacket(bytes);
                }
                catch (Exception ex) {
                    _log?.LogError(ex, $"RecvFrom Error: {ex.Message}");
                }
            }
            return bytesRead;
        }

        private static string FormatBytes(byte[] bytes) {
            return string.Join(" ", bytes.Select(x => x.ToString("X2")));
        }

        void Destroy() {

        }
    }
}