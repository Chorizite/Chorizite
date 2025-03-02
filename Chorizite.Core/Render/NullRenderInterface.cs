using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Chorizite.Common;

namespace Chorizite.Core.Render {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class NullRenderInterface : IRenderInterface {
        internal class NullTexture : ITexture {
            public IntPtr TexturePtr { get; }

            public int Width => 0;

            public int Height => 0;

            public bool PreMultipliedAlpha => true;

            public NullTexture(uint textureId) {
                TexturePtr = (IntPtr)textureId;
            }

            public void Dispose() {
            }
        }

        private uint _nextGeometryId = 1;
        private uint _nextTextureId = 1;

        public Vector2 ViewportSize => Vector2.Zero;

        public unsafe IntPtr DataPatchUI { get; set; }

        public IntPtr NativeDevice => IntPtr.Zero;

        public IntPtr NativeHwnd => IntPtr.Zero;

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? OnRender2D {
            add { _OnRender2D.Subscribe(value); }
            remove { _OnRender2D.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnRender2D = new();

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? OnGraphicsPreReset {
            add { _OnGraphicsPreReset.Subscribe(value); }
            remove { _OnGraphicsPreReset.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnGraphicsPreReset = new();

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? OnGraphicsPostReset {
            add { _OnGraphicsPostReset.Subscribe(value); }
            remove { _OnGraphicsPostReset.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnGraphicsPostReset = new();

        public IntPtr CompileGeometry(IEnumerable<VertexPositionColorTexture> vertices, IEnumerable<int> indices) {
            return (IntPtr)_nextGeometryId++;
        }

        public void EnableScissorRegion(bool enable) {

        }

        public ITexture GenerateTexture(byte[] source, Vector2 dimensions) {
            return new NullTexture(_nextTextureId++);
        }

        public ITexture? LoadDatTexture(uint textureId, out Vector2 textureDimensions) {
            textureDimensions = Vector2.Zero;
            return new NullTexture(_nextTextureId++);
        }

        public ITexture? LoadTexture(string source, out Vector2 textureDimensions) {
            textureDimensions = Vector2.Zero;
            return new NullTexture(_nextTextureId++);
        }

        public void ReleaseGeometry(IntPtr geometry) {

        }

        public void ReleaseTexture(ITexture textureHandle) {

        }

        public void RenderGeometry(IntPtr geometry, Matrix4x4 translation, ITexture? texture) {

        }

        public void SetScissorRegion(int x, int y, int width, int height) {

        }

        public void SetTransform(Matrix4x4 transform) {

        }

        public void Dispose() {
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
