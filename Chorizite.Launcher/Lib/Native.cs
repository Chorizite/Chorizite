using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Bindings.OpenGL;

namespace LauncherApp.Lib {
    internal static class Native {
        public enum GWL {
            GWL_WNDPROC = (-4),
            GWL_HINSTANCE = (-6),
            GWL_HWNDPARENT = (-8),
            GWL_STYLE = (-16),
            GWL_EXSTYLE = (-20),
            GWL_USERDATA = (-21),
            GWL_ID = (-12),
            WS_EX_LAYERED = 0x80000,
            WS_EX_TRANSPARENT = 0x00000020
        }

        internal enum AccentState {
            ACCENT_DISABLED = 0,
            ACCENT_ENABLE_GRADIENT = 1,
            ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
            ACCENT_ENABLE_BLURBEHIND = 3,
            ACCENT_INVALID_STATE = 4
        }

        internal enum WindowCompositionAttribute {
            WCA_ACCENT_POLICY = 19
        }

        internal static IntPtr GetForegroundWindow() {
            return SDL2.SDL.SDL_GL_GetCurrentWindow();
        }

        public static void SetClipboardText(string text) {
            SDL2.SDL.SDL_SetClipboardText(text);
            SDL2.SDL.SDL_GL_GetCurrentWindow();
        }

        public static string? GetClipboardText() {
            return SDL2.SDL.SDL_GetClipboardText();
        }
    }
}
