using AcClient;
using Chorizite.Core.Backend.Client;
using Microsoft.Extensions.Logging;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.NativeClientBootstrapper.Hooks {
    internal unsafe class ChatHooks : HookBase {
        private static IHook<Del_ClientSystem_AddTextToScroll>? _ClientSystem_AddTextToScrollHook;
        private static IHook<Del_ClientCommunicationSystem_OnChatCommand>? _ClientCommunicationSystem_OnChatCommandHook;
        private static IHook<Del_ClientCommunicationSystem_InitializeCommands>? _ClientCommunicationSystem_InitializeCommandsHook;

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate int Del_ClientSystem_AddTextToScroll(IntPtr This, PStringBase<ushort>* text, eChatTypes type, byte unknown, StringInfo* info);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate int Del_ClientCommunicationSystem_OnChatCommand(ClientCommunicationSystem* This, PStringBase<ushort>* text, int chatWindowId);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate void Del_ClientCommunicationSystem_InitializeCommands(ClientCommunicationSystem* This);

        public static ClientCommunicationSystem* ClientCommunicationSystem { get; private set; }

        internal static void Init() {
            _ClientSystem_AddTextToScrollHook = CreateHook<Del_ClientSystem_AddTextToScroll>(typeof(ChatHooks), nameof(ClientSystem_AddTextToScroll_Impl), 0x005649F0);
            _ClientCommunicationSystem_OnChatCommandHook = CreateHook<Del_ClientCommunicationSystem_OnChatCommand>(typeof(ChatHooks), nameof(ClientCommunicationSystem_OnChatCommand_Impl), 0x005821A0);
            _ClientCommunicationSystem_InitializeCommandsHook = CreateHook<Del_ClientCommunicationSystem_InitializeCommands>(typeof(ChatHooks), nameof(ClientCommunicationSystem_InitializeCommands_Impl), 0x005827F0);
        }

        internal static void AddChatText(string text, eChatTypes type) {
            if (ClientCommunicationSystem is null) {
                return;
            }

            using var pString = (PStringBase<ushort>)text;
            ClientCommunicationSystem->clientSystem.AddTextToScroll(&pString, type, 0, null);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static int ClientSystem_AddTextToScroll_Impl(IntPtr This, PStringBase<ushort>* text, eChatTypes type, byte unknown, StringInfo* info) {
            var eventArgs = new ChatTextAddedEventArgs(text->ToString().TrimEnd('\r', '\n'), (ChatType)type);
            StandaloneLoader.Backend?.HandleChatTextAdded(eventArgs);

            if (eventArgs.Eat) {
                return 0;
            }

            return _ClientSystem_AddTextToScrollHook!.OriginalFunction(This, text, type, unknown, info);
        }


        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static int ClientCommunicationSystem_OnChatCommand_Impl(ClientCommunicationSystem* This, PStringBase<ushort>* text, int chatWindowId) {
            try {
                var eventArgs = new ChatInputEventArgs(text->ToString(), (ChatWindowId)chatWindowId);
                StandaloneLoader.Backend?.HandleChatTextInput(eventArgs);

                if (eventArgs.Eat) {
                    return 0;
                }
            }
            catch (Exception ex) {
                StandaloneLoader.Log.LogError(ex, $"ClientCommunicationSystem_OnChatCommand Error: {ex.Message}");
            }

            return _ClientCommunicationSystem_OnChatCommandHook!.OriginalFunction(This, text, chatWindowId);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static void ClientCommunicationSystem_InitializeCommands_Impl(ClientCommunicationSystem* This) {
            ClientCommunicationSystem = This;
            _ClientCommunicationSystem_InitializeCommandsHook!.OriginalFunction(This);
        }
    }
}
