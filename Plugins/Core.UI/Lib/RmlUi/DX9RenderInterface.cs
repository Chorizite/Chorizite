using MagicHat.Service.Lib.Plugins;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ACUI.Lib.RmlUi {
    public unsafe class DX9RenderInterface : RenderInterface {
        private static Regex _datFileRegex = new Regex("0x[0-9a-fA-F]{8}");
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
        private Dictionary<IntPtr, ManagedTexture> _textures = new();
        private int _nextGeometryId = 1;
        private ILogger _log;
        private PluginManager _pluginManager;

        public Device D3Ddevice { get; }

        public DX9RenderInterface(Device D3Ddevice) {
            this.D3Ddevice = D3Ddevice;
        }

        public DX9RenderInterface(Device D3Ddevice, PluginManager pluginManager, ILogger? logger) : this(D3Ddevice) {
            _log = logger;
            _pluginManager = pluginManager;
        }

        public void BeginFrame() {

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
            D3Ddevice.SetTextureStageState(0, TextureStageStates.AlphaOperation, (int)TextureOperation.SelectArg1);
            D3Ddevice.SetTextureStageState(0, TextureStageStates.AlphaArgument1, (int)TextureArgument.TextureColor);

            D3Ddevice.SetSamplerState(0, SamplerStageStates.AddressU, (int)TextureAddress.Clamp);
            D3Ddevice.SetSamplerState(0, SamplerStageStates.AddressV, (int)TextureAddress.Clamp);
            D3Ddevice.SetTransform(TransformType.View, view);
            D3Ddevice.SetTransform(TransformType.Projection, projection);
        }

        public override unsafe IntPtr CompileGeometry(Vertex* vertices, int vertexCount, int* indices, int indexCount) {
            //LoaderCore.Log($"CompileGeometry called with {vertexCount} vertices and {indexCount} indices");

            var verts = new CustomVertex.PositionColoredTextured[vertexCount];
            var inds = new int[indexCount];

            for (var i = 0; i < vertexCount; i++) {
                verts[i] = new CustomVertex.PositionColoredTextured(vertices[i].Position.X, vertices[i].Position.Y, 0, Color.FromArgb(vertices[i].Colour.Alpha, vertices[i].Colour.Red, vertices[i].Colour.Green, vertices[i].Colour.Blue).ToArgb(), vertices[i].TextureCoordinates.X, vertices[i].TextureCoordinates.Y);
            }
            for (var i = 0; i < indexCount; i++) {
                inds[i] = indices[i];
            }

            var gVertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColoredTextured), vertexCount, D3Ddevice, Usage.None, CustomVertex.PositionColoredTextured.Format, Pool.Managed);
            gVertexBuffer.SetData(verts, 0, LockFlags.None);

            var gIndexBuffer = new IndexBuffer(typeof(int), indexCount, D3Ddevice, Usage.None, Pool.Managed);
            gIndexBuffer.SetData(inds, 0, LockFlags.None);

            var id = _nextGeometryId++;
            var geometry = new GeometryBufferRef(gVertexBuffer, gIndexBuffer, verts, inds);
            _geometryBuffers.Add((IntPtr)id, geometry);

            return new IntPtr(id);
        }

        public override void RenderGeometry(IntPtr geometry, Vector2f translation, IntPtr texture) {
            try {
                var geom = _geometryBuffers[geometry];

                if (texture == IntPtr.Zero) {
                    D3Ddevice.SetTexture(0, null);
                }
                else {
                    D3Ddevice.SetTexture(0, _textures[texture].Texture);
                }

                D3Ddevice.SetTransform(TransformType.World, Matrix.Translation(translation.X, translation.Y, 0));
                D3Ddevice.SetStreamSource(0, geom.VertexBuffer, 0);
                D3Ddevice.Indices = geom.IndexBuffer;
                D3Ddevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, geom.IndexBuffer.SizeInBytes / sizeof(int), 0, geom.IndexBuffer.SizeInBytes / sizeof(int) / 3);
            }
            catch (Exception e) {
                //UIPluginCore.Log($"Error rendering geometry: {e}");
            }
        }

        public override void ReleaseGeometry(IntPtr geometry) {
            if (_geometryBuffers.TryGetValue(geometry, out var geom)) {
                _geometryBuffers.Remove(geometry);
                geom.Dispose();
            }
        }

        public override unsafe IntPtr GenerateTexture(byte* source, int numBytes, Vector2i dimensions) {
            Texture d3d9_texture = new Texture(D3Ddevice, dimensions.X, dimensions.Y, 1, 0, Format.A8R8G8B8, Pool.Managed);

            using (var s = d3d9_texture.LockRectangle(0, new Rectangle(0, 0, dimensions.X, dimensions.Y), LockFlags.None, out int pitch)) {
                var bpp = 4;
                for (int y = 0; y < dimensions.Y; ++y) {
                    for (int x = 0; x < dimensions.X; ++x) {
                        var source_pixel = source[dimensions.X * bpp * y + x * bpp];
                        s.Seek(dimensions.X * bpp * y + x * bpp, SeekOrigin.Begin);
                        s.WriteByte(source[dimensions.X * bpp * y + x * bpp + 2]);
                        s.WriteByte(source[dimensions.X * bpp * y + x * bpp + 1]);
                        s.WriteByte(source[dimensions.X * bpp * y + x * bpp + 0]);
                        s.WriteByte(source[dimensions.X * bpp * y + x * bpp + 3]);
                    }
                }
            }
            d3d9_texture.UnlockRectangle(0);

            var mTexture = new ManagedTexture(d3d9_texture);
            _textures.Add(mTexture.TexturePtr, mTexture);
            _log?.LogDebug($"Generated texture: 0x{mTexture.TexturePtr:X8} ({dimensions.X},{dimensions.Y} )");
            return mTexture.TexturePtr;
        }

        public override IntPtr LoadTexture(ref Vector2i textureDimensions, string source) {
            try {
                ManagedTexture texture;

                StackTrace stackTrace = new StackTrace();
                var assembly = stackTrace.GetFrame(0).GetMethod().DeclaringType.Assembly;
                _log?.LogDebug($"Called LoadTexture from {assembly.GetName().Name}");

                if (source.EndsWith(".tga")) {
                    //UIPluginCore.Log($"Loading TGA texture: {source}");
                    texture = new ManagedTexture(TgaDecoder.FromFile(source));
                }
                else if (_datFileRegex.IsMatch(Path.GetFileName(source))) {
                    texture = new ManagedTexture(Convert.ToUInt32(Path.GetFileName(source), 16));
                }
                else {
                    _log.LogDebug($"Loading BITMAP texture: {source}");
                    texture = new ManagedTexture(source);
                }

                _log?.LogTrace($"Loaded texture: 0x{texture.TexturePtr:X8} {source}");

                textureDimensions = new Vector2i(texture.Bitmap.Width, texture.Bitmap.Height);
                _textures.Add(texture.TexturePtr, texture);
                return texture.TexturePtr;
            }
            catch (Exception ex) {
                _log?.LogError($"Error loading texture ({source}): {ex}");
                return IntPtr.Zero;
            }
        }

        public override void ReleaseTexture(IntPtr textureHandle) {
            if (_textures.TryGetValue(textureHandle, out var texture)) {
                _log?.LogTrace($"Disping texture: 0x{texture.TexturePtr:X8}");
                texture.Dispose();;
                _textures.Remove(textureHandle);
            }
        }

        public override void EnableScissorRegion(bool enable) {
            D3Ddevice.SetRenderState(RenderStates.ScissorTestEnable, enable);
        }

        public override void SetScissorRegion(int x, int y, int width, int height) {
            D3Ddevice.ScissorRectangle = new Rectangle(x, y, width, height);
        }

        public override void Dispose() {
            base.Dispose();

            var textures = _textures.Values.ToArray();
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
    }
}
