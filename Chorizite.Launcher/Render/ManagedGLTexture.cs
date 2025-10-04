using Chorizite.Core.Dats;
using Chorizite.Core.Render;
using Chorizite.Core.Render.Enums;
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

namespace LauncherApp.Render {
    internal unsafe class ManagedGLTexture : BitmapTexture {
        private uint _texture;

        public ManagedGLTexture(IGraphicsDevice device) : base(device) {
        }

        /// <inheritdoc/>
        public  IntPtr TexturePtr => (IntPtr)_texture;

        /// <inheritdoc/>
        public override int Width => Bitmap?.Width ?? 0;

        /// <inheritdoc/>
        public override int Height => Bitmap?.Height ?? 0;

        public override nint NativePtr => throw new NotImplementedException();

        public override TextureFormat Format => throw new NotImplementedException();

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
                GL.glTexParameteri(TextureTarget.Texture2d, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapNearest);
                GL.glTexParameteri(TextureTarget.Texture2d, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);


                GL.glTexParameteri(TextureTarget.Texture2d, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
                GL.glTexParameteri(TextureTarget.Texture2d, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

                GL.glGenerateMipmap(TextureTarget.Texture2d);
            }
        }

        protected override void ReleaseTexture() {
            uint texture = _texture;
            GL.glDeleteTextures(1, &texture);
        }

        public override void Bind(int slot = 0) {
            throw new NotImplementedException();
        }

        public override void Unbind() {
            throw new NotImplementedException();
        }

        public override void SetData(Chorizite.Core.Render.Rectangle rectangle, byte[] data) {
            throw new NotImplementedException();
        }
    }
}