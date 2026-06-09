using Chorizite.Core.Render;
using System.Numerics;

namespace Chorizite.DocGen.LuaDefs {
    internal class NullRenderInterface : IRenderInterface {
        public nint NativeHwnd => throw new NotImplementedException();
        public Vector2 ViewportSize => Vector2.Zero;

        public IGraphicsDevice GraphicsDevice => throw new NotImplementedException();

        public IDrawList DrawList => throw new NotImplementedException();

        public IShader UIShader => throw new NotImplementedException();

        public IShader TextShader => throw new NotImplementedException();

        public IFontManager FontManager => throw new NotImplementedException();

        public event EventHandler<EventArgs> OnBeforeRender3D;
        public event EventHandler<EventArgs> OnRender3D;
        public event EventHandler<EventArgs> OnAfterRender3D;
        public event EventHandler<EventArgs> OnBeforeRenderUI;
        public event EventHandler<EventArgs> OnRenderUI;
        public event EventHandler<EventArgs> OnAfterRenderUI;
        public event EventHandler<EventArgs> OnRender2D;
        public event EventHandler<EventArgs> OnGraphicsPreReset;
        public event EventHandler<EventArgs> OnGraphicsPostReset;

        public void BindRenderTarget(RenderTarget? renderTarget) {
            throw new NotImplementedException();
        }

        public IntPtr CompileGeometry(IEnumerable<VertexPositionColorTexture> vertices, IEnumerable<int> indices) {
            throw new NotImplementedException();
        }

        public RenderTarget CreateRenderTarget(int width, int height) {
            throw new NotImplementedException();
        }

        public ScopedDeviceState CreateScopedState() {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public void EnableScissorRegion(bool enable) {
            throw new NotImplementedException();
        }

        public ITexture GenerateTexture(byte[] source, Vector2 dimensions) {
            throw new NotImplementedException();
        }

        public ITexture? LoadTexture(string source, out Vector2 textureDimensions) {
            throw new NotImplementedException();
        }

        public void Render() {
            throw new NotImplementedException();
        }

        public void ReleaseGeometry(IntPtr geometry) {
            throw new NotImplementedException();
        }

        public void ReleaseTexture(ITexture texture) {
            throw new NotImplementedException();
        }

        public void RenderGeometry(IntPtr geometry, Matrix4x4 transform, ITexture? texture) {
            throw new NotImplementedException();
        }

        public void Resize(int width, int height) {
            throw new NotImplementedException();
        }

        public void SetScissorRegion(int left, int top, int right, int bottom) {
            throw new NotImplementedException();
        }

        public void SetCursor(uint cursorDataId, Vector2 hotspot) {
            throw new NotImplementedException();
        }

        public void SetTransform(Matrix4x4 transform) {
            throw new NotImplementedException();
        }
    }
}
