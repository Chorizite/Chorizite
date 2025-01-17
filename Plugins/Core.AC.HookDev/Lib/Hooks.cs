using AcClient;
using Chorizite.Common.Enums;
using Chorizite.Core.Backend.Client;
using Chorizite.Loader.Standalone.Hooks;
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

namespace Core.AC.HookDev.Lib {
    unsafe internal class Hooks : HookBase, IDisposable {
        private static ILogger _log;
        private static IClientBackend _client;

        private static IHook<UIElementManager_SetFocusElement> _UIElementManager_SetFocusElement;

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate void UIElementManager_SetFocusElement(UIElementManager* thisPtr, UIElement* element);

        public Hooks(ILogger log, IClientBackend clientBackend) {
            _log = log;
            _client = clientBackend;

            _UIElementManager_SetFocusElement = CreateHook<UIElementManager_SetFocusElement>(typeof(Hooks), nameof(UIElementManager_SetFocusElement_Impl), 0x0045B970);

        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static void UIElementManager_SetFocusElement_Impl(UIElementManager* thisPtr, UIElement* element) {
            //_client.AddChatText($"UIElementManager_SetFocusElement({(int)element:X8})");
            _UIElementManager_SetFocusElement!.OriginalFunction(thisPtr, element);
        }

        public void Dispose() {
            _UIElementManager_SetFocusElement.Disable();
        }
    }
}
