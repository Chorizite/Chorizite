using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiWindowClass
    {
        public uint ClassId;
        public uint ParentViewportId;
        public ImGuiViewportFlags ViewportFlagsOverrideSet;
        public ImGuiViewportFlags ViewportFlagsOverrideClear;
        public ImGuiTabItemFlags TabItemFlagsOverrideSet;
        public ImGuiDockNodeFlags DockNodeFlagsOverrideSet;
        public byte DockingAlwaysTabBar;
        public byte DockingAllowUnclassed;
    }
    public unsafe partial struct ImGuiWindowClassPtr
    {
        public ImGuiWindowClass* NativePtr { get; }
        public ImGuiWindowClassPtr(ImGuiWindowClass* nativePtr) => NativePtr = nativePtr;
        public ImGuiWindowClassPtr(IntPtr nativePtr) => NativePtr = (ImGuiWindowClass*)nativePtr;
        public static implicit operator ImGuiWindowClassPtr(ImGuiWindowClass* nativePtr) => new ImGuiWindowClassPtr(nativePtr);
        public static implicit operator ImGuiWindowClass* (ImGuiWindowClassPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiWindowClassPtr(IntPtr nativePtr) => new ImGuiWindowClassPtr(nativePtr);
        public uint ClassId { get { return NativePtr->ClassId; } set { NativePtr->ClassId = value; } }
        public uint ParentViewportId { get { return NativePtr->ParentViewportId; } set { NativePtr->ParentViewportId = value; } }
        public ImGuiViewportFlags ViewportFlagsOverrideSet { get { return NativePtr->ViewportFlagsOverrideSet; } set { NativePtr->ViewportFlagsOverrideSet = value; } }
        public ImGuiViewportFlags ViewportFlagsOverrideClear { get { return NativePtr->ViewportFlagsOverrideClear; } set { NativePtr->ViewportFlagsOverrideClear = value; } }
        public ImGuiTabItemFlags TabItemFlagsOverrideSet { get { return NativePtr->TabItemFlagsOverrideSet; } set { NativePtr->TabItemFlagsOverrideSet = value; } }
        public ImGuiDockNodeFlags DockNodeFlagsOverrideSet { get { return NativePtr->DockNodeFlagsOverrideSet; } set { NativePtr->DockNodeFlagsOverrideSet = value; } }
        public bool DockingAlwaysTabBar { get { return NativePtr->DockingAlwaysTabBar == 1; } set { NativePtr->DockingAlwaysTabBar = value ? (byte)1 : (byte)0; } }
        public bool DockingAllowUnclassed { get { return NativePtr->DockingAllowUnclassed == 1; } set { NativePtr->DockingAllowUnclassed = value ? (byte)1 : (byte)0; } }
        public void Destroy()
        {
            ImGuiNative.ImGuiWindowClass_destroy((ImGuiWindowClass*)(NativePtr));
        }
    }
}
