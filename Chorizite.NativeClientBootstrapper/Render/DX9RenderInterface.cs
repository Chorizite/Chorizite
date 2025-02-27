using Chorizite.Backends.ACBackend.Extensions;
using Chorizite.Core.Dats;
using Chorizite.Core.Render;
using Microsoft.Extensions.Logging;
using SharpDX.Direct3D9;
using SharpDX.Mathematics.Interop;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using Chorizite.Common;
using Chorizite.NativeClientBootstrapper.Lib;
using Chorizite.NativeClientBootstrapper.Hooks;

namespace Chorizite.NativeClientBootstrapper.Render {
    public unsafe class DX9RenderInterface : IRenderInterface {
        private static Regex _datFileRegex = new Regex(@"^dat:\/\/");
        private static int iii = 0;
        private Matrix4x4 _transform = Matrix4x4.Identity;
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


        /// <inheritdoc/>
        public event EventHandler<EventArgs> OnRender2D {
            add { _OnRender2D.Subscribe(value); }
            remove { _OnRender2D.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnRender2D = new();

        /// <inheritdoc/>
        public event EventHandler<EventArgs> OnGraphicsPreReset {
            add { _OnGraphicsPreReset.Subscribe(value); }
            remove { _OnGraphicsPreReset.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnGraphicsPreReset = new();

        /// <inheritdoc/>
        public event EventHandler<EventArgs> OnGraphicsPostReset {
            add { _OnGraphicsPostReset.Subscribe(value); }
            remove { _OnGraphicsPostReset.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnGraphicsPostReset = new();

        public static Device D3Ddevice { get; private set; }

        public Vector2 ViewportSize {
            get {
                return new (D3Ddevice.Viewport.Width + D3Ddevice.Viewport.X, D3Ddevice.Viewport.Height + D3Ddevice.Viewport.Y);
            }
        }

        public IntPtr DataPatchUI { get; private set; }
        internal HLSLShader BasicShader { get; }

        public IntPtr NativeDevice => D3Ddevice.NativePointer;
        public IntPtr NativeHwnd => DirectXHooks.HWND;

        public DX9RenderInterface(IntPtr unmanagedD3dPtr, ILogger logger, IDatReaderInterface datReader) {
            _log = logger;
            _datReader = datReader;
            D3Ddevice = new Device(unmanagedD3dPtr);

            var shaderDir = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), $"./../../Launcher/Chorizite.NativeClientBootstrapper/Render/Shaders"));

            BasicShader = new HLSLShader(D3Ddevice, "Basic", GetEmbeddedResource("Render.Shaders.Basic.fx"), null, _log, shaderDir);
        }

        internal void SetDevice(Device device) {
            D3Ddevice = device;
        }

        private string GetEmbeddedResource(string filename) {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Chorizite.NativeClientBootstrapper." + filename;

            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);
            string result = reader.ReadToEnd();
            return result;
        }

        public void Render2D() {
            var oldViewport = D3Ddevice.Viewport;
            using (var stateBlock = new StateBlock(D3Ddevice, StateBlockType.All)) {
                stateBlock.Capture();

                D3Ddevice.SetRenderState(RenderState.CullMode, Cull.Clockwise);
                D3Ddevice.SetRenderState(RenderState.Lighting, false);
                D3Ddevice.SetRenderState(RenderState.FogEnable, false);
                D3Ddevice.SetRenderState(RenderState.AntialiasedLineEnable, true);
                D3Ddevice.SetRenderState(RenderState.MultisampleAntialias, true);

                D3Ddevice.SetRenderState(RenderState.AlphaBlendEnable, true);
                D3Ddevice.SetRenderState(RenderState.SourceBlend, Blend.BlendFactor);
                D3Ddevice.SetRenderState(RenderState.DestinationBlend, Blend.Zero);
                D3Ddevice.SetRenderState(RenderState.BlendOperation, BlendOperation.Add);
                D3Ddevice.SetRenderState(RenderState.SourceBlendAlpha, Blend.BlendFactor);
                D3Ddevice.SetRenderState(RenderState.DestinationBlendAlpha, Blend.Zero);
                D3Ddevice.SetRenderState(RenderState.BlendOperationAlpha, BlendOperation.Add);

                D3Ddevice.SetTextureStageState(0, TextureStage.AlphaOperation, TextureOperation.Add);
                D3Ddevice.SetTextureStageState(0, TextureStage.AlphaArg1, TextureArgument.Texture);
                D3Ddevice.SetTextureStageState(0, TextureStage.AlphaArg2, TextureArgument.Diffuse);

                D3Ddevice.SetSamplerState(0, SamplerState.AddressU, TextureAddress.Clamp);
                D3Ddevice.SetSamplerState(0, SamplerState.AddressV, TextureAddress.Clamp);

                D3Ddevice.SetRenderState(RenderState.ColorVertex, true);

                D3Ddevice.Viewport = new RawViewport() {
                    X = 0,
                    Y = 0,
                    Width = (int)ViewportSize.X,
                    Height = (int)ViewportSize.Y,
                    MinDepth = -1000,
                    MaxDepth = 1000
                };

                try {
                    _OnRender2D?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception ex) {
                    _log?.LogError(ex, $"Error in OnRender2D: {ex.Message}");
                }

                stateBlock.Apply();
            }
            D3Ddevice.Viewport = oldViewport;
        }


        public IntPtr CompileGeometry(IEnumerable<VertexPositionColorTexture> vertices, IEnumerable<int> indices) {
            //_log?.LogTrace($"CompileGeometry: verts: {vertices.Count()} inds: {indices.Count()}");
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
            try {
                var geom = _geometryBuffers[geometry];
                var hp = 0.5f;
                var projection = Matrix4x4.CreateOrthographicOffCenterLeftHanded(hp, ViewportSize.X + hp, ViewportSize.Y + hp, hp, -1000, 1000);

                BasicShader.SetActive();

                if (texture is ManagedDXTexture dxTexture && dxTexture is not null) {
                    D3Ddevice.SetTexture(0, dxTexture.Texture);
                    BasicShader.Effect.Technique = BasicShader.Effect.GetTechnique("PositionColorTexture");

                    if (dxTexture.PreMultipliedAlpha) {
                        D3Ddevice.SetRenderState(RenderState.BlendOperation, BlendOperation.Add);
                        D3Ddevice.SetRenderState(RenderState.SourceBlend, Blend.SourceAlpha);
                        D3Ddevice.SetRenderState(RenderState.DestinationBlend, Blend.InverseSourceAlpha);
                    }
                    else {
                        D3Ddevice.SetRenderState(RenderState.SourceBlend, Blend.BlendFactor);
                        D3Ddevice.SetRenderState(RenderState.DestinationBlend, Blend.Zero);
                        D3Ddevice.SetRenderState(RenderState.BlendOperation, BlendOperation.Add);
                    }
                }
                else {
                    D3Ddevice.SetTexture(0, null);
                    BasicShader.Effect.Technique = BasicShader.Effect.GetTechnique("PositionColor");
                }
                BasicShader.SetUniform("xWorld", transform * _transform);
                BasicShader.SetUniform("xProjection", projection);

                var numPasses = BasicShader.Effect.Begin();

                for (var p = 0; p < numPasses; p++) {
                    BasicShader.Effect.BeginPass(p);

                    D3Ddevice.VertexDeclaration = geom.VertexDecl;
                    D3Ddevice.SetStreamSource(0, geom.VertexBuffer, 0, sizeof(VertexPositionColorTexture));
                    D3Ddevice.Indices = geom.IndexBuffer;
                    D3Ddevice.DrawIndexedPrimitive(PrimitiveType.TriangleList, 0, 0, geom.IndexBuffer.Description.Size / sizeof(int), 0, geom.IndexBuffer.Description.Size / sizeof(int) / 3);

                    BasicShader.Effect.EndPass();
                }
                BasicShader.Effect.End();
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error in RenderGeometry: {ex.Message}");
            }
        }

        public void ReleaseGeometry(IntPtr geometry) {
            //_log?.LogTrace($"ReleaseGeometry: 0x{geometry:X8}");
            if (_geometryBuffers.TryGetValue(geometry, out var geom)) {
                _geometryBuffers.Remove(geometry);
                geom.Dispose();
            }
        }

        public ITexture GenerateTexture(byte[] source, Vector2 dimensions) {
            //_log?.LogTrace($"Generate texture: {dimensions.X}x{dimensions.Y}");
            var dx = (int)dimensions.X;
            var dy = (int)dimensions.Y;

            var mTexture = new ManagedDXTexture(source, dx, dy);
            _textures.Add(mTexture);
            return mTexture;
        }



        public ITexture? LoadTexture(string source, out Vector2 textureDimensions) {
            try {
                //_log?.LogTrace($"LoadTexture: {source}");
                ManagedDXTexture texture;

                //StackTrace stackTrace = new StackTrace();
                //var assembly = stackTrace.GetFrame(0).GetMethod().DeclaringType.Assembly;
                //_log?.LogDebug($"Called LoadTexture from {assembly.GetName().Name}");

                if (_datFileRegex.IsMatch(source)) {
                    texture = new ManagedDXTexture(source, _datReader);
                }
                else {
                    texture = new ManagedDXTexture(source);
                }

                if (texture is null) {
                    _log.LogError($"Failed to load texture: {source}");
                    textureDimensions = Vector2.Zero;
                    return default;
                }

                _log?.LogTrace($"Loaded texture: 0x{texture.TexturePtr:X8} {source}");

                textureDimensions = new Vector2(texture.Width, texture.Height);
                _textures.Add(texture);
                return texture;
            }
            catch (Exception ex) {
                _log?.LogError($"Error loading texture ({source}): {ex}");
                textureDimensions = Vector2.Zero;
                return default;
            }
        }

        public void ReleaseTexture(ITexture texture) {
            //_log?.LogTrace($"Disping texture: 0x{texture.TexturePtr:X8}");
            texture.Dispose();
        }

        public void EnableScissorRegion(bool enable) {
            D3Ddevice.SetRenderState(RenderState.ScissorTestEnable, enable);
        }

        public void SetTransform(Matrix4x4 transform) {
            _transform = transform;
        }

        public void SetScissorRegion(int x, int y, int right, int bottom) {
            D3Ddevice.ScissorRect = new RawRectangle(x, y, right, bottom);
        }

        public void TriggerGraphicsPreReset(object sender, EventArgs e) {
            BasicShader.Reload();
            _OnGraphicsPreReset?.Invoke(sender, e);
        }

        public void TriggerGraphicsPostReset(object sender, EventArgs e) {
            _OnGraphicsPostReset?.Invoke(sender, e);
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

            BasicShader?.Dispose();
        }
    }
}
