using Reloaded.Hooks.Definitions;
using Reloaded.Hooks;
using System.Diagnostics.CodeAnalysis;
using System;

namespace Chorizite.Loader.Standalone.Hooks {
    public class HookBase {
        public static IHook<TFunction> CreateHook<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes)] TFunction>(Type type, string name, int address) {
            return ReloadedHooks.Instance.CreateHook<TFunction>(type, name, address).Activate();
        }
    }
}