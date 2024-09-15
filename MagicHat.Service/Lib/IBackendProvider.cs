using Microsoft.DirectX.Direct3D;
using System;

namespace MagicHat.Service.Lib {
    public interface IBackendProvider {
        event EventHandler<Lib.Events.WindowMessageEventArgs>? OnWindowMessage;
        event EventHandler<EventArgs>? OnRender2D;
        event EventHandler<EventArgs>? OnGraphicsPreReset;
        event EventHandler<EventArgs>? OnGraphicsPostReset;

        Device GetD3DDevice();
        IntPtr GetHwnd();
    }
}