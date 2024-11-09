using Core.DatService;
using Chorizite.Core.Render;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ACUI.Lib.RmlUi {
    public unsafe class RmlUIRenderInterface : RenderInterface {
        private readonly IRenderInterface _renderer;
        private readonly Dictionary<IntPtr, ITexture> _textures = new Dictionary<IntPtr, ITexture>();

        public RmlUIRenderInterface(IRenderInterface renderer) {
            _renderer = renderer;
        }

        public override unsafe IntPtr CompileGeometry(Vertex* vertices, int vertexCount, int* indices, int indexCount) {
            var verts = new VertexPositionColorTexture[vertexCount];
            for (int i = 0; i < vertexCount; i++) {
                var v = vertices[i];
                verts[i] = new VertexPositionColorTexture(new Vector3(v.Position.X, v.Position.Y, 0), new ColorVec(v.Colour.Alpha / 255f, v.Colour.Red / 255f, v.Colour.Green / 255f, v.Colour.Blue / 255f), new Vector2(v.TextureCoordinates.X, v.TextureCoordinates.Y));
            }
            var inds = new int[indexCount];
            for (int i = 0; i < indexCount; i++) {
                inds[i] = indices[i];
            }
            return _renderer.CompileGeometry(verts, inds);
        }

        public override void RenderGeometry(IntPtr geometry, Vector2f translation, IntPtr texture) {
            var transform = Matrix4x4.CreateTranslation(translation.X, translation.Y, 0);
            var tex = _textures.TryGetValue(texture, out var tex1) ? tex1 : null;
            _renderer.RenderGeometry(geometry, transform, tex);
        }

        public override void ReleaseGeometry(IntPtr geometry) {
            _renderer.ReleaseGeometry(geometry);
        }

        public override unsafe IntPtr GenerateTexture(byte* source, int numBytes, Vector2i dimensions) {
            var sourceBytes = new byte[numBytes];
            Marshal.Copy((IntPtr)source, sourceBytes, 0, numBytes);
            var texture = _renderer.GenerateTexture(sourceBytes, new Vector2(dimensions.X, dimensions.Y));

            _textures.Add(texture.TexturePtr, texture);
            return texture.TexturePtr;
        }

        public override IntPtr LoadTexture(ref Vector2i textureDimensions, string source) {
            var texture = _renderer.LoadTexture(source, out var dim);
            textureDimensions = new Vector2i((int)dim.X, (int)dim.Y);

            _textures.Add(texture.TexturePtr, texture);
            return texture.TexturePtr;
        }

        public override void ReleaseTexture(IntPtr textureHandle) {
            if (_textures.TryGetValue(textureHandle, out var texture)) {
                _textures.Remove(textureHandle);
                _renderer.ReleaseTexture(texture);
            }
        }

        public override void EnableScissorRegion(bool enable) {
            _renderer.EnableScissorRegion(enable);
        }

        public override void SetScissorRegion(int x, int y, int width, int height) {
            _renderer.SetScissorRegion(x, y, width, height);
        }

        public override void Dispose() {
            var textures = _textures.Values.ToArray();
            foreach (var texture in textures) {
                texture.Dispose();
            }
            _textures.Clear();
            base.Dispose();
        }
    }
}
