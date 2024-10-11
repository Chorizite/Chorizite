using ACClientLib.DatReaderWriter.Enums;
using ACDatReader.FileTypes;
using MagicHat.Core.Dats;
using MagicHat.Core.Render;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Globalization;
using System.Runtime.InteropServices;
using WaveEngine.Bindings.OpenGL;
using static System.Windows.Forms.DataFormats;
using Color = SixLabors.ImageSharp.Color;
using Image = SixLabors.ImageSharp.Image;

namespace Launcher.Render {
    internal unsafe class ManagedGLTexture : ITexture {
        private static readonly Color BORDER_COLOR_MASK = Color.White;
        private static readonly Color BACKGROUND_COLOR_MASK = Color.Black;
        static readonly PixelType GL_UNSIGNED_BYTE = (PixelType)0x1401;
        private uint _texture;

        public IntPtr TexturePtr => (IntPtr)_texture;

        /// <summary>
        /// The bitmap this texture is using.
        /// </summary>
        public Image<Argb32> Bitmap { get; set; } = null;

        internal static ManagedGLTexture FromDatUrl(string source, ILogger? log, IDatReaderInterface datReader) {
            var uri = new Uri(source);
            uint id = ParseDatId(uri.Host);
            Image<Argb32> baseBmp = GetIconBitmap(id, datReader, out var file).CloneAs<Argb32>();

            if (file?.Format == SurfacePixelFormat.PFID_CUSTOM_RAW_JPEG) {
                return new ManagedGLTexture(baseBmp);
            }

            var bmp2 = new Image<Argb32>(baseBmp.Width, baseBmp.Height);

            for (int x = 0; x < baseBmp.Width; x++) {
                for (int y = 0; y < baseBmp.Height; y++) {
                    Color gotColor = baseBmp[x, y];
                    if (gotColor == BACKGROUND_COLOR_MASK) {
                        baseBmp[x, y] = Color.Transparent;
                    }
                }
            }

            bmp2.Mutate(x => x.Fill(Color.Transparent));
            bmp2.Mutate(x => x.DrawImage(baseBmp, 1));
            baseBmp.Dispose();

            return new ManagedGLTexture(bmp2);
        }

        /// <summary>
        /// Create a new managed texture from a bitmap file path.
        /// </summary>
        /// <param name="file">The bitmap file path for the texture.</param>
        public ManagedGLTexture(string file) : base() {
            Bitmap = Image.Load(file).CloneAs<Argb32>();
            CreateTexture();
        }

        /// <summary>
        /// Create a new managed texture from a bitmap. This copies your bitmap data immediately
        /// so you can dispose the passed bitmap immediately.
        /// </summary>
        /// <param name="bitmap">The bitmap source for the texture.</param>
        public ManagedGLTexture(Image bitmap) : base() {
            Bitmap = bitmap.CloneAs<Argb32>();
            CreateTexture();
        }

        internal unsafe void CreateTexture() {
            if (Bitmap != null) {
                uint texture = 0;
                GL.glGenTextures(1, &texture);
                GL.glBindTexture(TextureTarget.Texture2d, texture);
                _texture = texture;

                // Get the pixel data from the ImageSharp bitmap
                byte[] pixelData = new byte[Bitmap.Width * Bitmap.Height * 4];
                Bitmap.CopyPixelDataTo(pixelData);

                // Swap ARGB to RGBA format
                for (int i = 0; i < pixelData.Length; i += 4) {
                    byte a = pixelData[i];
                    byte r = pixelData[i + 1];
                    byte g = pixelData[i + 2];
                    byte b = pixelData[i + 3];

                    pixelData[i] = r;
                    pixelData[i + 1] = g;
                    pixelData[i + 2] = b;
                    pixelData[i + 3] = a;
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

        private static Image<Argb32> GetIconBitmap(uint id, IDatReaderInterface portalDat, out ACDatReader.FileTypes.Texture? iconFile) {
            if (!portalDat.TryGet<ACDatReader.FileTypes.Texture>(id, out iconFile)) {
                throw new Exception($"Could not load icon from dat: 0x{id:X8}");
            }

            if (iconFile is null || iconFile.SourceData is null) {
                throw new Exception($"iconFile was null: 0x{id:X8}");
            }

            return GetBitmap(iconFile);
        }

        private static Image<Argb32> GetBitmap(ACDatReader.FileTypes.Texture texture) {
            if (texture.Format == SurfacePixelFormat.PFID_CUSTOM_RAW_JPEG) {
                using (var ms = new MemoryStream(texture.SourceData)) {
                    using (var src = Image.Load(ms)) {
                        texture.Width = src.Width;
                        texture.Height = src.Height;
                        return src.CloneAs<Argb32>();
                    }
                }
            }
            var image = new Image<Argb32>(texture.Width, texture.Height);
            var colorArray = texture.GetImageColorArray();
            switch (texture.Format) {
                case SurfacePixelFormat.PFID_R8G8B8:
                case SurfacePixelFormat.PFID_CUSTOM_LSCAPE_R8G8B8:
                    for (int i = 0; i < texture.Height; i++)
                        for (int j = 0; j < texture.Width; j++) {
                            int idx = i * texture.Width + j;
                            byte r = (byte)((colorArray[idx] & 0xFF0000) >> 16);
                            byte g = (byte)((colorArray[idx] & 0xFF00) >> 8);
                            byte b = (byte)(colorArray[idx] & 0xFF);
                            image[j, i] = Color.FromRgba(r, g, b, 255);
                        }
                    break;
                case SurfacePixelFormat.PFID_A8R8G8B8:
                    for (int i = 0; i < texture.Height; i++)
                        for (int j = 0; j < texture.Width; j++) {
                            int idx = i * texture.Width + j;
                            int a = (int)((colorArray[idx] & 0xFF000000) >> 24);
                            int r = (colorArray[idx] & 0xFF0000) >> 16;
                            int g = (colorArray[idx] & 0xFF00) >> 8;
                            int b = colorArray[idx] & 0xFF;
                            image[j, i] = Color.FromRgba((byte)r, (byte)g, (byte)b, 255);
                        }
                    break;
                /*
            case SurfacePixelFormat.PFID_INDEX16:
            case SurfacePixelFormat.PFID_P8:
                var pal = UBService.PortalDat.ReadFromDat<ACE.DatLoader.FileTypes.Palette>((uint)texture.DefaultPaletteId);

                // Apply any custom palette colors, if any, to our loaded palette (note, this may be all of them!)
                if (texture.CustomPaletteColors.Count > 0)
                    foreach (KeyValuePair<int, uint> entry in texture.CustomPaletteColors)
                        if (entry.Key <= pal.Colors.Count)
                            pal.Colors[entry.Key] = entry.Value;

                for (int i = 0; i < texture.Height; i++)
                    for (int j = 0; j < texture.Width; j++) {
                        int idx = (i * texture.Width) + j;
                        int a = (int)((pal.Colors[colorArray[idx]] & 0xFF000000) >> 24);
                        int r = (int)(pal.Colors[colorArray[idx]] & 0xFF0000) >> 16;
                        int g = (int)(pal.Colors[colorArray[idx]] & 0xFF00) >> 8;
                        int b = (int)pal.Colors[colorArray[idx]] & 0xFF;
                        image.SetPixel(j, i, Color.FromArgb(a, r, g, b));
                    }
                break;
                */
                case SurfacePixelFormat.PFID_A8:
                case SurfacePixelFormat.PFID_CUSTOM_LSCAPE_ALPHA:
                    for (int i = 0; i < texture.Height; i++)
                        for (int j = 0; j < texture.Width; j++) {
                            int idx = i * texture.Width + j;
                            int r = colorArray[idx];
                            int g = colorArray[idx];
                            int b = colorArray[idx];
                            image[j, i] = Color.FromRgba((byte)r, (byte)g, (byte)b, 255);
                        }
                    break;
                case SurfacePixelFormat.PFID_R5G6B5: // 16-bit RGB
                    for (int i = 0; i < texture.Height; i++)
                        for (int j = 0; j < texture.Width; j++) {
                            int idx = 3 * (i * texture.Width + j);
                            int r = colorArray[idx];
                            int g = colorArray[idx + 1];
                            int b = colorArray[idx + 2];
                            image[j, i] = Color.FromRgba((byte)r, (byte)g, (byte)b, 255);
                        }
                    break;
                case SurfacePixelFormat.PFID_A4R4G4B4:
                    for (int i = 0; i < texture.Height; i++)
                        for (int j = 0; j < texture.Width; j++) {
                            int idx = 4 * (i * texture.Width + j);
                            int a = colorArray[idx];
                            int r = colorArray[idx + 1];
                            int g = colorArray[idx + 2];
                            int b = colorArray[idx + 3];
                            image[j, i] = Color.FromRgba((byte)r, (byte)g, (byte)b, 255);
                        }
                    break;
                default:
                    throw new Exception($"Unknown pixel format: {texture.Format}");
            }

            return image;
        }

        private static uint ParseDatId(string value) {
            uint id = 0;

            if (value.StartsWith("0x")) {
                uint.TryParse(value.Replace("0x", ""), NumberStyles.HexNumber, null, out id);
            }
            else if (!uint.TryParse(value, out id)) {
                return 0;
            }

            if (id < 0x06000000)
                id += 0x06000000;

            return id;
        }

        public void Dispose() {
            Bitmap?.Dispose();
            uint texture = _texture;
            GL.glDeleteTextures(1, &texture);
        }
    }
}