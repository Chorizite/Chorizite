using MagicHat.Backends.ACBackend.Extensions;
using MagicHat.Core.Dats;
using MagicHat.Core.Render;
using Microsoft.Extensions.Logging;
using SharpDX.Direct3D9;
using SharpDX.Mathematics.Interop;
using SharpDX.Multimedia;
using System.Drawing.Imaging;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using AcClient;

namespace MagicHat.Backends.ACBackend.Render {
    public unsafe class DX9RenderInterface : IRenderInterface {
        private static Regex _datFileRegex = new Regex(@"^dat:\/\/");
        private struct GeometryBufferRef : IDisposable {
            public VertexBuffer VertexBuffer;
            public IndexBuffer IndexBuffer;
            public VertexDeclaration VertexDecl;

            public GeometryBufferRef(VertexBuffer vertexBuffer, IndexBuffer indexBuffer, VertexDeclaration vertexDecl) {
                VertexBuffer = vertexBuffer;
                IndexBuffer = indexBuffer;
                VertexDecl = vertexDecl;
            }

            public void Dispose() {
                VertexBuffer?.Dispose();
                IndexBuffer?.Dispose();
                VertexDecl?.Dispose();
            }
        }

        private Dictionary<IntPtr, GeometryBufferRef> _geometryBuffers = new();
        private List<ManagedDXTexture> _textures = new();
        private int _nextGeometryId = 1;
        private ILogger _log;
        private readonly IDatReaderInterface _datReader;
        private GameScreen _currentScreen = GameScreen.None;

        public event EventHandler<EventArgs>? OnRender2D;
        public event EventHandler<EventArgs>? OnGraphicsPreReset;
        public event EventHandler<EventArgs>? OnGraphicsPostReset;
        public event EventHandler<ScreenChangedEventArgs>? OnScreenChanged;

        public static Device D3Ddevice { get; private set; }

        public System.Numerics.Vector2 ViewportSize => new(D3Ddevice.Viewport.Width, D3Ddevice.Viewport.Height);

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

        public IntPtr DataPatchUI { get; private set; }

        public DX9RenderInterface(IntPtr unmanagedD3dPtr, ILogger logger, IDatReaderInterface datReader) {
            _log = logger;
            _datReader = datReader;
            D3Ddevice = new Device(unmanagedD3dPtr);
            _log.LogDebug($"DX Device 2: {((int)unmanagedD3dPtr):X8} // {D3Ddevice.Viewport.Width}x{D3Ddevice.Viewport.Height}");
        }

        public void Render2D() {
            using (var stateBlock = new StateBlock(D3Ddevice, StateBlockType.All)) {
                stateBlock.Capture();
                var hp = 0.5f;
                var projection = Matrix4x4.CreateOrthographicOffCenterLeftHanded(hp, D3Ddevice.Viewport.Width + hp, D3Ddevice.Viewport.Height + hp, hp, -1, 1).ToDX();
                var view = Matrix4x4.Identity.ToDX();

                D3Ddevice.SetRenderState(RenderState.CullMode, Cull.Clockwise);
                D3Ddevice.SetRenderState(RenderState.Lighting, false);
                D3Ddevice.SetRenderState(RenderState.FogEnable, false);
                D3Ddevice.SetRenderState(RenderState.AntialiasedLineEnable, true);
                D3Ddevice.SetRenderState(RenderState.MultisampleAntialias, true);

                D3Ddevice.SetRenderState(RenderState.AlphaBlendEnable, true);
                D3Ddevice.SetRenderState(RenderState.SourceBlend, Blend.SourceAlpha);
                D3Ddevice.SetRenderState(RenderState.DestinationBlend, Blend.InverseSourceAlpha);

                D3Ddevice.SetRenderState(RenderState.ColorVertex, true);

                D3Ddevice.SetTextureStageState(0, TextureStage.ColorOperation, TextureOperation.Modulate);
                D3Ddevice.SetTextureStageState(0, TextureStage.ColorArg1, TextureArgument.Texture);
                D3Ddevice.SetTextureStageState(0, TextureStage.ColorArg2, TextureArgument.Diffuse);
                D3Ddevice.SetTextureStageState(0, TextureStage.AlphaOperation, TextureOperation.Modulate);
                D3Ddevice.SetTextureStageState(0, TextureStage.AlphaArg1, TextureArgument.Diffuse);
                D3Ddevice.SetTextureStageState(0, TextureStage.AlphaArg2, TextureArgument.Texture);

                D3Ddevice.SetSamplerState(0, SamplerState.AddressU, TextureAddress.Border);
                D3Ddevice.SetSamplerState(0, SamplerState.AddressV, TextureAddress.Border);
                D3Ddevice.SetTransform(TransformState.View, view);
                D3Ddevice.SetTransform(TransformState.Projection, projection);

                try {
                    OnRender2D?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception ex) {
                    _log?.LogError(ex, $"Error in OnRender2D: {ex.Message}");
                }

                stateBlock.Apply();
            }
        }


        public IntPtr CompileGeometry(IEnumerable<VertexPositionColorTexture> vertices, IEnumerable<int> indices) {
            _log?.LogTrace($"CompileGeometry: verts: {vertices.Count()} inds: {indices.Count()}");
            var verts = vertices.ToArray();
            var inds = indices.ToArray();

            var vSize = Marshal.SizeOf<VertexPositionColorTexture>();
            var gVertexBuffer = new VertexBuffer(D3Ddevice, vSize * verts.Length, Usage.None, VertexFormat.Position | VertexFormat.Diffuse | VertexFormat.Texture1, Pool.Managed);
            gVertexBuffer.Lock(0, 0, LockFlags.None).WriteRange(verts);
            gVertexBuffer.Unlock();

            var gIndexBuffer = new IndexBuffer(D3Ddevice, sizeof(int) * inds.Length, Usage.None, Pool.Managed, false);
            gIndexBuffer.Lock(0, 0, LockFlags.None).WriteRange(inds);
            gIndexBuffer.Unlock();

            var vertexElems = new[] {
                new VertexElement(0, 0, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position, 0),
                new VertexElement(0, 12, DeclarationType.Float4, DeclarationMethod.Default, DeclarationUsage.Color, 0),
                new VertexElement(0, 28, DeclarationType.Float2, DeclarationMethod.Default, DeclarationUsage.TextureCoordinate, 0),
                VertexElement.VertexDeclarationEnd
            };

            var id = _nextGeometryId++;
            var geometry = new GeometryBufferRef(gVertexBuffer, gIndexBuffer, new VertexDeclaration(D3Ddevice, vertexElems));
            _geometryBuffers.Add((IntPtr)id, geometry);

            return new IntPtr(id);
        }



        public void RenderGeometry(IntPtr geometry, Matrix4x4 transform, ITexture? texture) {
            _log?.LogTrace($"RenderGeometry: 0x{geometry:X8}");
            var geom = _geometryBuffers[geometry];


            if (texture is ManagedDXTexture dxTexture && dxTexture is not null) {
                D3Ddevice.SetTexture(0, dxTexture.Texture);
            }
            else {
                D3Ddevice.SetTexture(0, null);
            }

            D3Ddevice.VertexDeclaration = geom.VertexDecl;
            D3Ddevice.SetTransform(TransformState.World, transform.ToDX());
            D3Ddevice.SetStreamSource(0, geom.VertexBuffer, 0, sizeof(VertexPositionColorTexture));
            D3Ddevice.Indices = geom.IndexBuffer;
            D3Ddevice.DrawIndexedPrimitive(PrimitiveType.TriangleList, 0, 0, geom.IndexBuffer.Description.Size / sizeof(int), 0, geom.IndexBuffer.Description.Size / sizeof(int) / 3);
        }

        public void ReleaseGeometry(IntPtr geometry) {
            _log?.LogTrace($"ReleaseGeometry: 0x{geometry:X8}");
            if (_geometryBuffers.TryGetValue(geometry, out var geom)) {
                _geometryBuffers.Remove(geometry);
                geom.Dispose();
            }
        }

        private static int iii = 0;
        public ITexture GenerateTexture(byte[] source, System.Numerics.Vector2 dimensions) {
            _log?.LogTrace($"Generate texture: {dimensions.X}x{dimensions.Y}");
            var dx = (int)dimensions.X;
            var dy = (int)dimensions.Y;

            var d3d9_texture = new Texture(D3Ddevice, dx, dy, 1, Usage.None, Format.A8R8G8B8, Pool.Managed);
            var s = d3d9_texture.LockRectangle(0, LockFlags.None);
            Marshal.Copy(source, 0, s.DataPointer, source.Length);
            d3d9_texture.UnlockRectangle(0);
            
            var mTexture = new ManagedDXTexture(d3d9_texture);
            _textures.Add(mTexture);
            return mTexture;
        }



        public ITexture? LoadTexture(string source, out System.Numerics.Vector2 textureDimensions) {
            try {
                _log?.LogTrace($"LoadTexture: {source}");
                ManagedDXTexture texture;

                //StackTrace stackTrace = new StackTrace();
                //var assembly = stackTrace.GetFrame(0).GetMethod().DeclaringType.Assembly;
                //_log?.LogDebug($"Called LoadTexture from {assembly.GetName().Name}");

                if (source.EndsWith(".tga")) {
                    texture = new ManagedDXTexture(TgaDecoder.FromFile(source));
                }
                else if (_datFileRegex.IsMatch(source)) {
                    texture = ManagedDXTexture.FromDatUrl(source, _log, _datReader);
                }
                else {
                    texture = new ManagedDXTexture(source);
                }

                if (texture is null) {
                    _log.LogError($"Failed to load texture: {source}");
                    textureDimensions = System.Numerics.Vector2.Zero;
                    return default;
                }

                _log?.LogTrace($"Loaded texture: 0x{texture.TexturePtr:X8} {source}");

                textureDimensions = new System.Numerics.Vector2(texture.Bitmap.Width, texture.Bitmap.Height);
                _textures.Add(texture);
                return texture;
            }
            catch (Exception ex) {
                _log?.LogError($"Error loading texture ({source}): {ex}");
                textureDimensions = System.Numerics.Vector2.Zero;
                return default;
            }
        }

        public void ReleaseTexture(ITexture texture) {
            _log?.LogTrace($"Disping texture: 0x{texture.TexturePtr:X8}");
            texture.Dispose();
        }

        public void EnableScissorRegion(bool enable) {
            _log?.LogTrace($"EnableScissorRegion: {enable}");
            D3Ddevice.SetRenderState(RenderState.ScissorTestEnable, enable);
        }

        public void SetScissorRegion(int x, int y, int width, int height) {
            _log?.LogTrace($"EnableScissorRegion: {x},{y} {width}x{height}");
            D3Ddevice.ScissorRect = new RawRectangle(x, y, x + width, y + height);
        }

        public void ShowGameScreen(GameScreen screen) {
            Screen = screen;
        }

        public void TriggerGraphicsPreReset(object sender, EventArgs e) {
            OnGraphicsPreReset?.Invoke(sender, e);
        }

        public void TriggerGraphicsPostReset(object sender, EventArgs e) {
            OnGraphicsPostReset?.Invoke(sender, e);
        }

        public void Dispose() {
            var textures = _textures.ToArray();
            foreach (var texture in textures) {
                texture.Dispose();
            }
            _textures.Clear();

            var geoms = _geometryBuffers.Keys.ToArray();
            foreach (var geom in geoms) {
                ReleaseGeometry(geom);
            }
            _geometryBuffers.Clear();
        }

        public void SetDataPatchData(gmDataPatchUI* dataPatchUI) {
            DataPatchUI = (IntPtr)dataPatchUI;
        }
    }
}
