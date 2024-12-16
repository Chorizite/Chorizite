using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Chorizite.Core;
using ImGuiNET;
using Autofac.Core;
using Core.DearImGui.Lib;
using Chorizite.Core.Backend;
using Chorizite.Common;
using Chorizite.Core.Input;

namespace Core.DearImGui {
    public class CoreImGui : IPluginCore {
        private readonly IChoriziteBackend _backend;
        internal static ILogger Log;
        private IntPtr _context;
        private bool _isResetting;
        private bool _frameStarted;

        /// <summary>
        /// Fired when a new world object is released from the games memory
        /// </summary>
        public event EventHandler<EventArgs> OnRender {
            add => _OnRender.Subscribe(value);
            remove => _OnRender.Unsubscribe(value);
        }
        private WeakEvent<EventArgs> _OnRender = new();

        protected CoreImGui(AssemblyPluginManifest manifest, IChoriziteConfig config, IChoriziteBackend backend, ILogger log) : base(manifest) {
            Log = log;
            _backend = backend;

            //var cimguiNativePath = Path.Combine(AssemblyDirectory, "runtimes", (IntPtr.Size == 8) ? "win-x64" : "win-x86", "native", "cimgui.dll");
            //Log?.LogTrace($"Manually pre-loading {cimguiNativePath}");
            //Native.LoadLibrary(cimguiNativePath);

            try {
                InitImGui();
            }
            catch (Exception ex) {
                Log.LogError(ex, "Failed to initialize ImGui");
            }
        }

        private unsafe void InitImGui() {
            _context = ImGui.CreateContext();
            ImGui.SetCurrentContext(_context);

            ImGui.GetIO().NativePtr->ConfigFlags &= ~ImGuiConfigFlags.ViewportsEnable;
            ImGui.GetIO().NativePtr->IniSavingRate = float.MinValue; // no ini saving

            if (!ImGuiImpl.ImGui_ImplWin32_Init(_backend.Renderer.NativeHwnd)) {
                Log.LogError("ImGui_ImplWin32_Init failed");
                return;
            }
            if (!ImGuiImpl.ImGui_ImplDX9_Init(_backend.Renderer.NativeDevice)) {
                Log.LogError("ImGui_ImplDX11_Init failed");
                return;
            }
            _backend.Renderer.OnRender2D += Renderer_OnRender2D;
            _backend.Renderer.OnGraphicsPreReset += Renderer_OnGraphicsPreReset;
            _backend.Renderer.OnGraphicsPostReset += Renderer_OnGraphicsPostReset;

            _backend.Input.OnMouseDown += Input_OnMouseDown;
            _backend.Input.OnMouseUp += Input_OnMouseUp;
            _backend.Input.OnMouseMove += Input_OnMouseMove;
            _backend.Input.OnMouseWheel += Input_OnMouseWheel;
            _backend.Input.OnKeyDown += Input_OnKeyDown;
            _backend.Input.OnKeyUp += Input_OnKeyUp;
            _backend.Input.OnKeyPress += Input_OnKeyPress;
        }

        private void Input_OnKeyPress(object? sender, KeyPressEventArgs e) {
            ImGui.GetIO().AddInputCharacter(e.Text[0]);
            e.Eat = ImGui.GetIO().WantCaptureKeyboard || e.Eat;
        }

        private void Input_OnKeyUp(object? sender, KeyUpEventArgs e) {
            ImGui.GetIO().AddKeyEvent(ToImGuiKey(e.Key), false);
            e.Eat = ImGui.GetIO().WantCaptureKeyboard || e.Eat;
        }

        private void Input_OnKeyDown(object? sender, KeyDownEventArgs e) {
            ImGui.GetIO().AddKeyEvent(ToImGuiKey(e.Key), true);
            e.Eat = ImGui.GetIO().WantCaptureKeyboard || e.Eat;
        }

        private void Input_OnMouseWheel(object? sender, MouseWheelEventArgs e) {
            ImGui.GetIO().AddMouseWheelEvent(e.DeltaX, e.DeltaY);
            e.Eat = ImGui.GetIO().WantCaptureMouse || e.Eat;
        }

        private void Input_OnMouseMove(object? sender, MouseMoveEventArgs e) {
            
        }

        private void Input_OnMouseUp(object? sender, MouseUpEventArgs e) {
            ImGui.GetIO().AddMouseButtonEvent((int)e.Button, false);
            e.Eat = ImGui.GetIO().WantCaptureMouse || e.Eat;
        }

        private void Input_OnMouseDown(object? sender, MouseDownEventArgs e) {
            ImGui.GetIO().AddMouseButtonEvent((int)e.Button, true);
            e.Eat = ImGui.GetIO().WantCaptureMouse || e.Eat;
        }

        private void Renderer_OnGraphicsPreReset(object? sender, EventArgs e) {
            ImGuiImpl.ImGui_ImplDX9_InvalidateDeviceObjects();
            _isResetting = true;
        }

        private void Renderer_OnGraphicsPostReset(object? sender, EventArgs e) {
            _isResetting = false;
        }


        uint _count = 0;
        private unsafe void Renderer_OnRender2D(object? sender, EventArgs e) {
            try {
                if (_count++ < 1) return;
                ImGuiImpl.ImGui_ImplDX9_NewFrame();
                ImGuiImpl.ImGui_ImplWin32_NewFrame();
                ImGui.NewFrame();

                _OnRender.Invoke(this, EventArgs.Empty);

                ImGui.EndFrame();
                ImGui.Render();
                ImGuiImpl.ImGui_ImplDX9_RenderDrawData((IntPtr)ImGui.GetDrawData().NativePtr);
            }
            catch (Exception ex) {
                Log.LogError(ex, "Failed to render ImGui");
            }
        }

        private ImGuiKey ToImGuiKey(Key key) {
            switch ((int)key) {
                case (int)Key.KEY_A: return ImGuiKey.A;
                case (int)Key.KEY_B: return ImGuiKey.B;
                case (int)Key.KEY_C: return ImGuiKey.C;
                case (int)Key.KEY_D: return ImGuiKey.D;
                case (int)Key.KEY_E: return ImGuiKey.E;
                case (int)Key.KEY_F: return ImGuiKey.F;
                case (int)Key.KEY_G: return ImGuiKey.G;
                case (int)Key.KEY_H: return ImGuiKey.H;
                case (int)Key.KEY_I: return ImGuiKey.I;
                case (int)Key.KEY_J: return ImGuiKey.J;
                case (int)Key.KEY_K: return ImGuiKey.K;
                case (int)Key.KEY_L: return ImGuiKey.L;
                case (int)Key.KEY_M: return ImGuiKey.M;
                case (int)Key.KEY_N: return ImGuiKey.N;
                case (int)Key.KEY_O: return ImGuiKey.O;
                case (int)Key.KEY_P: return ImGuiKey.P;
                case (int)Key.KEY_Q: return ImGuiKey.Q;
                case (int)Key.KEY_R: return ImGuiKey.R;
                case (int)Key.KEY_S: return ImGuiKey.S;
                case (int)Key.KEY_T: return ImGuiKey.T;
                case (int)Key.KEY_U: return ImGuiKey.U;
                case (int)Key.KEY_V: return ImGuiKey.V;
                case (int)Key.KEY_W: return ImGuiKey.W;
                case (int)Key.KEY_X: return ImGuiKey.X;
                case (int)Key.KEY_Y: return ImGuiKey.Y;
                case (int)Key.KEY_Z: return ImGuiKey.Z;

                case (int)Key.KEY_0: return ImGuiKey._0;
                case (int)Key.KEY_1: return ImGuiKey._1;
                case (int)Key.KEY_2: return ImGuiKey._2;
                case (int)Key.KEY_3: return ImGuiKey._3;
                case (int)Key.KEY_4: return ImGuiKey._4;
                case (int)Key.KEY_5: return ImGuiKey._5;
                case (int)Key.KEY_6: return ImGuiKey._6;
                case (int)Key.KEY_7: return ImGuiKey._7;
                case (int)Key.KEY_8: return ImGuiKey._8;
                case (int)Key.KEY_9: return ImGuiKey._9;

                case (int)Key.BACK: return ImGuiKey.GamepadBack;
                case (int)Key.TAB: return ImGuiKey.Tab;

                case (int)Key.RETURN: return ImGuiKey.Enter;

                case (int)Key.PAUSE: return ImGuiKey.Pause;
                case (int)Key.CAPITAL: return ImGuiKey.CapsLock;

                case (int)Key.ESCAPE: return ImGuiKey.Escape;

                case (int)Key.SPACE: return ImGuiKey.Space;
                case (int)Key.END: return ImGuiKey.End;
                case (int)Key.HOME: return ImGuiKey.Home;
                case (int)Key.LEFT: return ImGuiKey.LeftArrow;
                case (int)Key.UP: return ImGuiKey.UpArrow;
                case (int)Key.RIGHT: return ImGuiKey.RightArrow;
                case (int)Key.DOWN: return ImGuiKey.DownArrow;
                case (int)Key.PRINT: return ImGuiKey.PrintScreen;
                case (int)Key.INSERT: return ImGuiKey.Insert;
                case (int)Key.DELETE: return ImGuiKey.Delete;

                case (int)Key.LWIN: return ImGuiKey.LeftSuper;
                case (int)Key.RWIN: return ImGuiKey.RightSuper;

                case (int)Key.NUMPAD0: return ImGuiKey.Keypad0;
                case (int)Key.NUMPAD1: return ImGuiKey.Keypad1;
                case (int)Key.NUMPAD2: return ImGuiKey.Keypad2;
                case (int)Key.NUMPAD3: return ImGuiKey.Keypad3;
                case (int)Key.NUMPAD4: return ImGuiKey.Keypad4;
                case (int)Key.NUMPAD5: return ImGuiKey.Keypad5;
                case (int)Key.NUMPAD6: return ImGuiKey.Keypad6;
                case (int)Key.NUMPAD7: return ImGuiKey.Keypad7;
                case (int)Key.NUMPAD8: return ImGuiKey.Keypad8;
                case (int)Key.NUMPAD9: return ImGuiKey.Keypad9;
                case (int)Key.MULTIPLY: return ImGuiKey.KeypadMultiply;
                case (int)Key.ADD: return ImGuiKey.KeypadAdd;
                case (int)Key.SUBTRACT: return ImGuiKey.KeypadSubtract;
                case (int)Key.DECIMAL: return ImGuiKey.KeypadDecimal;
                case (int)Key.DIVIDE: return ImGuiKey.KeypadDivide;
                case (int)Key.F1: return ImGuiKey.F1;
                case (int)Key.F2: return ImGuiKey.F2;
                case (int)Key.F3: return ImGuiKey.F3;
                case (int)Key.F4: return ImGuiKey.F4;
                case (int)Key.F5: return ImGuiKey.F5;
                case (int)Key.F6: return ImGuiKey.F6;
                case (int)Key.F7: return ImGuiKey.F7;
                case (int)Key.F8: return ImGuiKey.F8;
                case (int)Key.F9: return ImGuiKey.F9;
                case (int)Key.F10: return ImGuiKey.F10;
                case (int)Key.F11: return ImGuiKey.F11;
                case (int)Key.F12: return ImGuiKey.F12;

                case (int)Key.NUMLOCK: return ImGuiKey.NumLock;
                case (int)Key.SCROLL: return ImGuiKey.ScrollLock;

                case (int)Key.SHIFT: return ImGuiKey.LeftShift;
                case (int)Key.CONTROL: return ImGuiKey.LeftCtrl;
            }

            return ImGuiKey.None;
        }

        protected override void Dispose() {
            _backend.Renderer.OnRender2D -= Renderer_OnRender2D;
            _backend.Renderer.OnGraphicsPreReset -= Renderer_OnGraphicsPreReset;
            _backend.Renderer.OnGraphicsPostReset -= Renderer_OnGraphicsPostReset;
            ImGui.DestroyContext();
        }
    }
}
