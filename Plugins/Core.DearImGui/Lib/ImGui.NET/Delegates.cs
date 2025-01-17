using System;
using System.Numerics;

namespace ImGuiNET
{
    internal delegate void Platform_CreateWindow(ImGuiViewportPtr vp);                    // Create a new platform window for the given viewport
    internal delegate void Platform_DestroyWindow(ImGuiViewportPtr vp);
    internal delegate void Platform_ShowWindow(ImGuiViewportPtr vp);                      // Newly created windows are initially hidden so SetWindowPos/Size/Title can be called on them first
    internal delegate void Platform_SetWindowPos(ImGuiViewportPtr vp, Vector2 pos);
    internal unsafe delegate void Platform_GetWindowPos(ImGuiViewportPtr vp, Vector2* outPos);
    internal delegate void Platform_SetWindowSize(ImGuiViewportPtr vp, Vector2 size);
    internal unsafe delegate void Platform_GetWindowSize(ImGuiViewportPtr vp, Vector2* outSize);
    internal delegate void Platform_SetWindowFocus(ImGuiViewportPtr vp);                  // Move window to front and set input focus
    internal delegate byte Platform_GetWindowFocus(ImGuiViewportPtr vp);
    internal delegate byte Platform_GetWindowMinimized(ImGuiViewportPtr vp);
    internal delegate void Platform_SetWindowTitle(ImGuiViewportPtr vp, IntPtr title);
}
