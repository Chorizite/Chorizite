using MagicHat.Backends.ACBackend.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core.Render {
    internal class NullRenderInterface : IRenderInterface {
        internal class NullTexture : ITexture {
            public IntPtr TexturePtr { get; }

            public NullTexture(uint textureId) {
                TexturePtr = (IntPtr)textureId;
            }

            public void Dispose() {
            }
        }

        private uint _nextGeometryId = 1;
        private uint _nextTextureId = 1;
        private GameScreen _currentScreen = GameScreen.None;

        public Vector2 ViewportSize => Vector2.Zero;

        public GameScreen Screen {
            get => _currentScreen;
            set {
                if (_currentScreen != value) {
                    var oldScreen = _currentScreen;
                    _currentScreen = value;
                    OnScreenChanged?.Invoke(this, new ScreenChangedEventArgs(oldScreen, _currentScreen));
                }
            }
        }

        public event EventHandler<EventArgs>? OnRender2D;
        public event EventHandler<EventArgs>? OnGraphicsPreReset;
        public event EventHandler<EventArgs>? OnGraphicsPostReset;
        public event EventHandler<ScreenChangedEventArgs>? OnScreenChanged;

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

        public void Dispose() {
        }

        public void ShowGameScreen(GameScreen screen) {
            Screen = screen;
        }
    }
}
