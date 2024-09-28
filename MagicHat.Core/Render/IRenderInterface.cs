using ACClientLib.DatReaderWriter.Enums;
using MagicHat.Backends.ACBackend.Render;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace MagicHat.Core.Render {
    public interface IRenderInterface : IDisposable {
        /// <summary>
        /// The size of the viewport (game window)
        /// </summary>
        public Vector2 ViewportSize { get; }

        /// <summary>
        /// The current game screen
        /// </summary>
        GameScreen Screen { get; set; }

        unsafe IntPtr DataPatchUI { get; }

        /// <summary>
        /// Callback for 2D rendering
        /// </summary>
        event EventHandler<EventArgs>? OnRender2D;

        /// <summary>
        /// Callback for graphics reset
        /// </summary>
        event EventHandler<EventArgs>? OnGraphicsPreReset;

        /// <summary>
        /// Callback for graphics reset
        /// </summary>
        event EventHandler<EventArgs>? OnGraphicsPostReset;

        /// <summary>
        /// Callback for screen change
        /// </summary>
        event EventHandler<ScreenChangedEventArgs>? OnScreenChanged;

        /// <summary>
        /// Compile the specified geometry and return a pointer to the compiled geometry
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public IntPtr CompileGeometry(IEnumerable<VertexPositionColorTexture> vertices, IEnumerable<int> indices);

        /// <summary>
        /// Render the specified geometry
        /// </summary>
        /// <param name="geometry"></param>
        /// <param name="translation"></param>
        /// <param name="texture"></param>
        public void RenderGeometry(IntPtr geometry, Matrix4x4 translation, ITexture? texture);

        /// <summary>
        /// Release the specified geometry
        /// </summary>
        /// <param name="geometry"></param>
        public void ReleaseGeometry(IntPtr geometry);

        /// <summary>
        /// Load the specified texture and return a pointer to the texture
        /// </summary>
        /// <param name="source"></param>
        /// <param name="textureDimensions"></param>
        /// <returns></returns>
        public ITexture? LoadTexture(string source, out Vector2 textureDimensions);

        /// <summary>
        /// Generate the specified texture and return a pointer to the texture
        /// </summary>
        /// <param name="source"></param>
        /// <param name="numBytes"></param>
        /// <param name="dimensions"></param>
        /// <returns></returns>
        public ITexture GenerateTexture(byte[] source, Vector2 dimensions);

        /// <summary>
        /// Release the specified texture
        /// </summary>
        /// <param name="textureHandle"></param>
        public void ReleaseTexture(ITexture textureHandle);

        /// <summary>
        /// Enable or disable the scissor region
        /// </summary>
        /// <param name="enable"></param>
        public void EnableScissorRegion(bool enable);

        /// <summary>
        /// Set the scissor region
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetScissorRegion(int x, int y, int width, int height);

        /// <summary>
        /// Show a game screen
        /// </summary>
        /// <param name="screen"></param>
        public void ShowGameScreen(GameScreen screen);
    }
}
