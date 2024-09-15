using Decal.Adapter.Wrappers;
using Decal.Adapter;
using Microsoft.DirectX.Direct3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Service.Lib {
    /// <summary>
    /// this is a wrapper around all decal stuff so it can easily be swapped out later.
    /// </summary>
    internal class BackendProvider : IBackendProvider {
        Device? D3Ddevice = null; // D3D_device

        public event EventHandler<Lib.Events.WindowMessageEventArgs>? OnWindowMessage;
        public event EventHandler<EventArgs>? OnRender2D;
        public event EventHandler<EventArgs>? OnGraphicsPreReset;
        public event EventHandler<EventArgs>? OnGraphicsPostReset;

        internal void TriggerOnWindowMessage(object sender, Lib.Events.WindowMessageEventArgs e) {
            OnWindowMessage?.Invoke(sender, e);
        }

        internal void TriggerOnRender2D(object sender, EventArgs e) {
            OnRender2D?.Invoke(sender, e);
        }

        internal void TriggerOnGraphicsPreReset(object sender, EventArgs e) {
            OnGraphicsPreReset?.Invoke(sender, e);
        }

        internal void TriggerOnGraphicsPostReset(object sender, EventArgs e) {
            OnGraphicsPostReset?.Invoke(sender, e);
        }

        /// <summary>
        /// Get the D3D device.
        /// </summary>
        /// <returns></returns>
        public Device GetD3DDevice() {
            if (D3Ddevice is null) {
                Guid IID_IDirect3DDevice9 = new Guid("{D0223B96-BF7A-43fd-92BD-A43B0D82B9EB}");
                object a = CoreManager.Current.Decal.Underlying.GetD3DDevice(ref IID_IDirect3DDevice9);
                Marshal.QueryInterface(Marshal.GetIUnknownForObject(a), ref IID_IDirect3DDevice9, out var unmanagedD3dPtr);
                D3Ddevice = new Device(unmanagedD3dPtr);
            }
            return D3Ddevice;
        }

        /// <summary>
        /// Get the HWND.
        /// </summary>
        /// <returns></returns>
        public IntPtr GetHwnd() {
            return CoreManager.Current.Decal.Hwnd;
        }
    }
}
