using Chorizite.Core.Dats;
using Chorizite.Core.Render;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Globalization;
using System.Runtime.InteropServices;
using WaveEngine.Bindings.OpenGL;
using Color = SixLabors.ImageSharp.Color;
using Image = SixLabors.ImageSharp.Image;
using PixelFormat = WaveEngine.Bindings.OpenGL.PixelFormat;

namespace Launcher.Render {
    internal unsafe class ManagedGLTexture : BitmapTexture {
        private static readonly PixelType GL_UNSIGNED_BYTE = (PixelType)0x1401;
        private uint _texture;

        /// <inheritdoc/>
        public override IntPtr TexturePtr => (IntPtr)_texture;

        /// <inheritdoc/>
        public override int Width => Bitmap?.Width ?? 0;

        /// <inheritdoc/>
        public override int Height => Bitmap?.Height ?? 0;

        /// <inheritdoc/>
        public ManagedGLTexture(byte[] source, int width, int height) : base(source, width, height) {

        }

        /// <inheritdoc/>
        public ManagedGLTexture(string file) : base(file) {

        }

        /// <inheritdoc/>
        protected ManagedGLTexture(Image bitmap) : base(bitmap) {

        }

        protected override unsafe void CreateTexture(bool premultiplyAlpha) {
            if (Bitmap != null) {
                uint texture = 0;
                GL.glGenTextures(1, &texture);
                GL.glBindTexture(TextureTarget.Texture2d, texture);
                _texture = texture;

                // Get the pixel data from the ImageSharp bitmap
                byte[] pixelData = new byte[Bitmap.Width * Bitmap.Height * 4];
                Bitmap.CopyPixelDataTo(pixelData);

                // pre-multiply alpha
                if (premultiplyAlpha) {
                    for (int i = 0; i < pixelData.Length; i += 4) {
                        pixelData[i] = (byte)(pixelData[i] * pixelData[i + 3] / 255f);
                        pixelData[i + 1] = (byte)(pixelData[i + 1] * pixelData[i + 3] / 255f);
                        pixelData[i + 2] = (byte)(pixelData[i + 2] * pixelData[i + 3] / 255f);
                    }
                }

                fixed (byte* data = &pixelData[0]) {
                    GL.glTexImage2D(TextureTarget.Texture2d, 0, 0x8058, Bitmap.Width, Bitmap.Height, 0, PixelFormat.Rgba, (PixelType)0x1401, data);
                }

                GL.glTexParameteri(TextureTarget.Texture2d, TextureParameterName.TextureMinFilter, 0x2601);
                GL.glTexParameteri(TextureTarget.Texture2d, TextureParameterName.TextureMagFilter, 0x2601);

                GL.glTexParameteri(TextureTarget.Texture2d, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
                GL.glTexParameteri(TextureTarget.Texture2d, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

                GL.glGenerateMipmap(TextureTarget.Texture2d);
            }
        }

        protected override void ReleaseTexture() {
            uint texture = _texture;
            GL.glDeleteTextures(1, &texture);
        }
    }
}