using Reloaded.Hooks.Definitions;
using Reloaded.Hooks;
using System.Diagnostics.CodeAnalysis;
using System;
using Chorizite.NativeClientBootstrapper.Lib;

namespace Chorizite.NativeClientBootstrapper.Hooks {
    public class HookBase {
        public static IHook<TFunction> CreateHook<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes)] TFunction>(Type type, string name, int address) {
            return ReloadedHooks.Instance.CreateHook<TFunction>(type, name, address).Activate();
        }
        public static IHook<TFunction> CreateHook<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes)] TFunction>(Type type, string name, string pattern) {
            var address = SigScanner.Scan(pattern);
            return ReloadedHooks.Instance.CreateHook<TFunction>(type, name, address).Activate();
        }
    }
}