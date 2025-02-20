using Autofac.Core;
using Chorizite.Backends.ACBackend.Extensions;
using Chorizite.Core.Dats;
using Chorizite.Core.Render;
using Microsoft.Extensions.Logging;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Security.Policy;
using System.Web;
using SharpDX.Multimedia;
using System.Xml.Linq;
using SharpDX;
using System.Runtime.InteropServices;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Drawing.Processing;

namespace Chorizite.NativeClientBootstrapper.Render {
    public class ManagedDXTexture : BitmapTexture {
        /// <summary>
        /// The DirectX texture
        /// </summary>
        public Texture? Texture { get; private set; } = null;

        /// <inheritdoc/>
        public override IntPtr TexturePtr => Texture?.NativePointer ?? IntPtr.Zero;

        /// <inheritdoc/>
        public override int Width => Bitmap?.Width ?? 0;

        /// <inheritdoc/>
        public override int Height => Bitmap?.Height ?? 0;

        /// <inheritdoc/>
        public ManagedDXTexture(byte[] source, int width, int height) : base(source, width, height) {

        }

        /// <inheritdoc/>
        public ManagedDXTexture(string file) : base(file) {

        }

        /// <inheritdoc/>
        public ManagedDXTexture(string source, IDatReaderInterface _portalDat) : base(source, _portalDat) {

        }

        /// <inheritdoc/>
        protected ManagedDXTexture(Image bitmap) : base(bitmap) {

        }

        protected override unsafe void CreateTexture(bool premultiplyAlpha) {
            // Avoid creating a new texture and losing reference to the old one.
            if (Texture != null)
                return;

            if (Bitmap != null) {
                // Create the texture
                Texture = new Texture(DX9RenderInterface.D3Ddevice, Width, Height, 1, Usage.None, Format.A8R8G8B8, Pool.Managed);
                // Lock the texture to get access to the data
                DataRectangle dataRectangle = Texture.LockRectangle(0, LockFlags.None);

                // Get the pixel data from the ImageSharp bitmap
                byte[] pixelData = new byte[Bitmap.Width * Bitmap.Height * 4]; // RGBA has 4 bytes per pixel
                Bitmap.CopyPixelDataTo(pixelData);

                for (int i = 0; i < pixelData.Length; i += 4) {
                    byte r = pixelData[i];
                    byte g = pixelData[i + 1];
                    byte b = pixelData[i + 2];
                    byte a = pixelData[i + 3];

                    if (premultiplyAlpha) {
                        pixelData[i] = (byte)(b * a / 255);
                        pixelData[i + 1] = (byte)(g * a / 255);
                        pixelData[i + 2] = (byte)(r * a / 255);
                        pixelData[i + 3] = a;
                    }
                    else {
                        pixelData[i] = b;
                        pixelData[i + 1] = g;
                        pixelData[i + 2] = r;
                        pixelData[i + 3] = a;
                    }
                }

                // Copy the swapped pixel data into the texture
                Marshal.Copy(pixelData, 0, dataRectangle.DataPointer, pixelData.Length);

                // Unlock the texture
                Texture.UnlockRectangle(0);
            }
        }

        protected override void ReleaseTexture() {
            Texture?.Dispose();
            Texture = null;
        }
    }
}
