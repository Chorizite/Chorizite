using Chorizite.Core.Render;
using System.Numerics;

namespace Chorizite.DocGen.LuaDefs {
    internal class NullRenderInterface : IRenderer {
        public nint NativeHwnd => throw new NotImplementedException();

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

        public void BindRenderTarget(RenderTarget? renderTarget) {
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

        public void Render() {
            throw new NotImplementedException();
        }

        public void Resize(int width, int height) {
            throw new NotImplementedException();
        }

        public void SetCursor(uint cursorDataId, Vector2 hotspot) {
            throw new NotImplementedException();
        }
    }
}