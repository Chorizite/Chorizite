using Decal.Adapter;
using MagicHat.Core.Dats;
using MagicHat.Core.Render;
using MagicHat.Service.Lib.Extensions;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace MagicHat.Service.Lib.Render {
    internal unsafe class DX9RenderInterface : IRenderInterface {
        private static Regex _datFileRegex = new Regex(@"^dat:\/\/");
        private struct GeometryBufferRef : IDisposable {
            public VertexBuffer VertexBuffer;
            public IndexBuffer IndexBuffer;
            public CustomVertex.PositionColoredTextured[] verts;
            public int[] inds;

            public GeometryBufferRef(VertexBuffer vertexBuffer, IndexBuffer indexBuffer, CustomVertex.PositionColoredTextured[] verts, int[] inds) {
                VertexBuffer = vertexBuffer;
                IndexBuffer = indexBuffer;
                this.verts = verts;
                this.inds = inds;
            }

            public void Dispose() {
                VertexBuffer?.Dispose();
                IndexBuffer?.Dispose();
                verts = null;
                inds = null;
            }
        }

        private Dictionary<IntPtr, GeometryBufferRef> _geometryBuffers = new();
        private List<ManagedDXTexture> _textures = new();
        private int _nextGeometryId = 1;
        private ILogger _log;
        private readonly IDatReaderInterface _datReader;

        public event EventHandler<EventArgs>? OnRender2D;
        public event EventHandler<EventArgs>? OnGraphicsPreReset;
        public event EventHandler<EventArgs>? OnGraphicsPostReset;

        public static Device D3Ddevice { get; private set; }

        public System.Numerics.Vector2 ViewportSize => new(D3Ddevice.Viewport.Width, D3Ddevice.Viewport.Height);

        public DX9RenderInterface(ILogger logger, IDatReaderInterface datReader) {
            _log = logger;
            _datReader = datReader;

            Guid IID_IDirect3DDevice9 = new Guid("{D0223B96-BF7A-43fd-92BD-A43B0D82B9EB}");
            object a = CoreManager.Current.Decal.Underlying.GetD3DDevice(ref IID_IDirect3DDevice9);
            Marshal.QueryInterface(Marshal.GetIUnknownForObject(a), ref IID_IDirect3DDevice9, out var unmanagedD3dPtr);
            D3Ddevice = new Device(unmanagedD3dPtr);
        }

        public void Render2D() {
            using (var stateBlock = new StateBlock(D3Ddevice, StateBlockType.All)) {
                stateBlock.Capture();

                var projection = Matrix.OrthoOffCenterLH(0, D3Ddevice.Viewport.Width, D3Ddevice.Viewport.Height, 0, -1, 1);
                var view = Matrix.Identity;

                D3Ddevice.RenderState.Lighting = false;
                D3Ddevice.RenderState.FogEnable = false;
                D3Ddevice.RenderState.CullMode = Cull.Clockwise;
                D3Ddevice.RenderState.MultiSampleAntiAlias = true;
                D3Ddevice.RenderState.AntiAliasedLineEnable = true;

                D3Ddevice.RenderState.AlphaBlendEnable = true;
                D3Ddevice.RenderState.SourceBlend = Blend.SourceAlpha;
                D3Ddevice.RenderState.DestinationBlend = Blend.InvSourceAlpha;

                D3Ddevice.RenderState.ColorVertex = true;
                D3Ddevice.VertexFormat = CustomVertex.PositionColoredTextured.Format;

                D3Ddevice.SetTextureStageState(0, TextureStageStates.ColorOperation, (int)TextureOperation.Modulate);
                D3Ddevice.SetTextureStageState(0, TextureStageStates.ColorArgument1, (int)TextureArgument.TextureColor);
                D3Ddevice.SetTextureStageState(0, TextureStageStates.ColorArgument2, (int)TextureArgument.Diffuse);
                D3Ddevice.SetTextureStageState(0, TextureStageStates.AlphaOperation, (int)TextureOperation.Modulate);
                D3Ddevice.SetTextureStageState(0, TextureStageStates.AlphaArgument1, (int)TextureArgument.Diffuse);
                D3Ddevice.SetTextureStageState(0, TextureStageStates.AlphaArgument2, (int)TextureArgument.TextureColor);

                D3Ddevice.SetSamplerState(0, SamplerStageStates.AddressU, (int)TextureAddress.Clamp);
                D3Ddevice.SetSamplerState(0, SamplerStageStates.AddressV, (int)TextureAddress.Clamp);
                D3Ddevice.SetTransform(TransformType.View, view);
                D3Ddevice.SetTransform(TransformType.Projection, projection);

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
            var verts = vertices.Select(v => {
                return new CustomVertex.PositionColoredTextured(v.Position.X, v.Position.Y, v.Position.Z, v.Color.ToArgb(), v.TexCoords.X, v.TexCoords.Y);
            }).ToArray();
            var inds = indices.ToArray();

            var gVertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColoredTextured), verts.Length, D3Ddevice, Usage.None, CustomVertex.PositionColoredTextured.Format, Pool.Managed);
            gVertexBuffer.SetData(verts, 0, LockFlags.None);

            var gIndexBuffer = new IndexBuffer(typeof(int), inds.Length, D3Ddevice, Usage.None, Pool.Managed);
            gIndexBuffer.SetData(inds, 0, LockFlags.None);

            var id = _nextGeometryId++;
            var geometry = new GeometryBufferRef(gVertexBuffer, gIndexBuffer, verts, inds);
            _geometryBuffers.Add((IntPtr)id, geometry);

            return new IntPtr(id);
        }



        public void RenderGeometry(IntPtr geometry, Matrix4x4 transform, ITexture? texture) {
            var geom = _geometryBuffers[geometry];


            if (texture is ManagedDXTexture dxTexture && dxTexture is not null) {
                D3Ddevice.SetTexture(0, dxTexture.Texture);
            }
            else {
                D3Ddevice.SetTexture(0, null);
            }

            D3Ddevice.SetTransform(TransformType.World, transform.ToDX());
            D3Ddevice.SetStreamSource(0, geom.VertexBuffer, 0);
            D3Ddevice.Indices = geom.IndexBuffer;
            D3Ddevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, geom.IndexBuffer.SizeInBytes / sizeof(int), 0, geom.IndexBuffer.SizeInBytes / sizeof(int) / 3);
        }

        public void ReleaseGeometry(IntPtr geometry) {
            if (_geometryBuffers.TryGetValue(geometry, out var geom)) {
                _geometryBuffers.Remove(geometry);
                geom.Dispose();
            }
        }

        public ITexture GenerateTexture(byte[] source, System.Numerics.Vector2 dimensions) {
            var dx = (int)dimensions.X;
            var dy = (int)dimensions.Y;
            var d3d9_texture = new Microsoft.DirectX.Direct3D.Texture(D3Ddevice, dx, dy, 1, 0, Format.A8R8G8B8, Pool.Managed);

            using (var s = d3d9_texture.LockRectangle(0, new Rectangle(0, 0, dx, dy), LockFlags.None, out int pitch)) {
                var bpp = 4;
                for (int y = 0; y < dy; ++y) {
                    for (int x = 0; x < dx; ++x) {
                        var source_pixel = source[dx * bpp * y + x * bpp];
                        s.Seek(dx * bpp * y + x * bpp, SeekOrigin.Begin);
                        s.WriteByte(source[dx * bpp * y + x * bpp + 2]);
                        s.WriteByte(source[dx * bpp * y + x * bpp + 1]);
                        s.WriteByte(source[dx * bpp * y + x * bpp + 0]);
                        s.WriteByte(source[dx * bpp * y + x * bpp + 3]);
                    }
                }
            }
            d3d9_texture.UnlockRectangle(0);

            var mTexture = new ManagedDXTexture(d3d9_texture);
            _textures.Add(mTexture);
            _log?.LogDebug($"Generated texture: 0x{mTexture.TexturePtr:X8} ({dx},{dy} )");
            return mTexture;
        }



        public ITexture? LoadTexture(string source, out System.Numerics.Vector2 textureDimensions) {
            try {
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
            D3Ddevice.SetRenderState(RenderStates.ScissorTestEnable, enable);
        }

        public void SetScissorRegion(int x, int y, int width, int height) {
            D3Ddevice.ScissorRectangle = new Rectangle(x, y, width, height);
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

        internal void TriggerOnGraphicsPostReset(MagicHatService magicHatService, EventArgs empty) {
            OnGraphicsPostReset?.Invoke(magicHatService, empty);
        }

        internal void TriggerOnGraphicsPreReset(MagicHatService magicHatService, EventArgs empty) {
            OnGraphicsPreReset?.Invoke(magicHatService, empty);
        }
    }
}
