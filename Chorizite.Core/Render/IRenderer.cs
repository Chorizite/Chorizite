using FontStashSharp.Interfaces;
using System;
using System.Numerics;

namespace Chorizite.Core.Render {
    /// <summary>
    /// The render interface
    /// </summary>
    public interface IRenderer : IDisposable {
        /// <summary>
        /// The native window
        /// </summary>
        public IntPtr NativeHwnd { get; }

        /// <summary>
        /// The graphics device
        /// </summary>
        public IGraphicsDevice GraphicsDevice { get; }

        /// <summary>
        /// A draw list for rendering 2D elements to the screen
        /// </summary>
        public IDrawList DrawList { get; }

        /// <summary>
        /// The UI shader
        /// </summary>
        public IShader UIShader { get; }

        /// <summary>
        /// The text shader
        /// </summary>
        public IShader TextShader { get; }

        /// <summary>
        /// The font manager
        /// </summary>
        public IFontManager FontManager { get; }

        /// <summary>
        /// Callback for before 3D rendering
        /// </summary>
        public event EventHandler<EventArgs> OnBeforeRender3D;

        /// <summary>
        /// Callback for 3D rendering
        /// </summary>
        public event EventHandler<EventArgs> OnRender3D;

        /// <summary>
        /// Callback for after 3D rendering
        /// </summary>
        public event EventHandler<EventArgs> OnAfterRender3D;

        /// <summary>
        /// Callback for before 2D rendering of the UI
        /// </summary>
        public event EventHandler<EventArgs> OnBeforeRenderUI;

        /// <summary>
        /// Callback for UI rendering
        /// </summary>
        public event EventHandler<EventArgs> OnRenderUI;

        /// <summary>
        /// Callback for after 2D rendering of the UI
        /// </summary>
        public event EventHandler<EventArgs> OnAfterRenderUI;

        /// <summary>
        /// Render
        /// </summary>
        public void Render();

        /// <summary>
        /// Create a scoped graphics device state, disposing of it will return the device to its original state.
        /// Make sure to use the returned object instead of the device directly.
        /// </summary>
        ScopedDeviceState CreateScopedState();

        /// <summary>
        /// Create a render target, that will render to a texture
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        RenderTarget CreateRenderTarget(int width, int height);


        /// <summary>
        /// Bind a render target, or set to null to render to the screen
        /// </summary>
        /// <param name="renderTarget"></param>
        void BindRenderTarget(RenderTarget? renderTarget);

        /// <summary>
        /// Set the cursor
        /// </summary>
        /// <param name="cursorDataId"></param>
        /// <param name="hotspot"></param>
        void SetCursor(uint cursorDataId, Vector2 hotspot);

        /// <summary>
        /// Resize the window
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void Resize(int width, int height);
    }
}
