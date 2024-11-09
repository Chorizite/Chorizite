using DatReaderWriter.Enums;
using Chorizite.Core.Dats;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
using DatReaderWriter.DBObjs;

namespace Chorizite.Core.Render {
    public abstract class BitmapTexture : ITexture {
        private static readonly Color BORDER_COLOR_MASK = Color.White;
        private static readonly Color BACKGROUND_COLOR_MASK = Color.Black;

        /// <summary>
        /// The bitmap this texture is using.
        /// </summary>
        protected Image<Rgba32>? Bitmap { get; set; } = null;

        /// <inheritdoc/>
        public abstract IntPtr TexturePtr { get; }

        /// <inheritdoc/>
        public abstract int Width { get; }

        /// <inheritdoc/>
        public abstract int Height { get; }

        public BitmapTexture() {
        
        }

        public BitmapTexture(byte[] source, int width, int height) {
            Bitmap = new Image<Rgba32>(width, height);
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    Bitmap[x, y] = Color.FromRgba(source[(y * width + x) * 4], source[(y * width + x) * 4 + 1], source[(y * width + x) * 4 + 2], source[(y * width + x) * 4 + 3]);
                }
            }
            CreateTexture();
        }

        /// <summary>
        /// Create a new managed texture from a bitmap file path.
        /// </summary>
        /// <param name="file">The bitmap file path for the texture.</param>
        public BitmapTexture(string file) : base() {
            using var img = Image.Load(file);
            Bitmap = img.CloneAs<Rgba32>();
            CreateTexture();
        }

        /// <summary>
        /// Create a new managed texture from a bitmap. This copies your bitmap data immediately
        /// so you can dispose the passed bitmap immediately after constructing.
        /// </summary>
        /// <param name="bitmap">The bitmap source for the texture.</param>
        protected BitmapTexture(Image bitmap) : base() {
            Bitmap = bitmap.CloneAs<Rgba32>();
            CreateTexture();
        }

        /// <summary>
        /// Create a new managed texture from a dat url
        /// </summary>
        /// <param name="source"></param>
        /// <param name="_portalDat"></param>
        public BitmapTexture(string source, IDatReaderInterface _portalDat) {
            var uri = new Uri(source);
            uint id = ParseDatId(uri.Host);
            using var img = GetIconBitmap(id, _portalDat, out var file);
            Image<Rgba32> baseBmp = img.CloneAs<Rgba32>();

            if (file?.Format == PixelFormat.PFID_CUSTOM_RAW_JPEG) {
                Bitmap = baseBmp;
                CreateTexture();
                return;
            }

            var bmp2 = new Image<Rgba32>(baseBmp.Width, baseBmp.Height);

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
            Bitmap = bmp2;
            CreateTexture();
            /*
            if (baseBmp is null) return null;
            if (baseBmp.Width == 32 && baseBmp.Height == 32) return new ManagedDXTexture(baseBmp);

            var bmp = new Image<Argb32>(baseBmp.Width, baseBmp.Height);
            bmp.Mutate(x => x.Fill(Color.Transparent));

            Image<Argb32>? underlay = null;
            Image<Argb32>? uieffect = null;
            Image<Argb32>? overlay1 = null;
            Image<Argb32>? overlay2 = null;

            if (!string.IsNullOrEmpty(uri.Query)) {
                var query = HttpHelpers.ParseQueryString(uri.Query);
                if (query.ContainsKey("underlay") && !string.IsNullOrEmpty(query["underlay"])) {
                    underlay = GetIconBitmap(ParseDatId(query["underlay"]), _portalDat, out var _);
                }
                if (query.ContainsKey("overlay1") && !string.IsNullOrEmpty(query["overlay1"])) {
                    overlay1 = GetIconBitmap(ParseDatId(query["overlay1"]), _portalDat, out var _);
                }
                if (query.ContainsKey("overlay2") && !string.IsNullOrEmpty(query["overlay2"])) {
                    overlay2 = GetIconBitmap(ParseDatId(query["overlay2"]), _portalDat, out var _);
                }
                if (query.ContainsKey("uieffect") && !string.IsNullOrEmpty(query["uieffect"]) && _uiEffects.TryGetValue(query["uieffect"].ToLower(), out var effectId)) {
                    uieffect = GetIconBitmap(effectId, _portalDat, out var _);
                }
            }

            uieffect ??= GetIconBitmap(0x060011C5, _portalDat, out var _);
            // ui effect
            if (baseBmp.Width <= 32 && baseBmp.Height <= 32) {
                for (int x = 0; x < baseBmp.Width; x++) {
                    for (int y = 0; y < baseBmp.Height; y++) {
                        Color gotColor = bmp[x, y];
                        if (gotColor == BORDER_COLOR_MASK) {
                            bmp[x, y] = uieffect[x, y];
                        }
                        else if (gotColor == BACKGROUND_COLOR_MASK) {
                            bmp[x, y] = Color.Transparent;
                        }
                    }
                }

                if (underlay is not null) bmp.Mutate(x => x.DrawImage(underlay, 1));
                bmp.Mutate(x => x.DrawImage(baseBmp, 1));
                if (overlay1 is not null) bmp.Mutate(x => x.DrawImage(overlay1, 1));
                if (overlay2 is not null) bmp.Mutate(x => x.DrawImage(overlay2, 1));
            }

            baseBmp?.Dispose();
            underlay?.Dispose();
            uieffect?.Dispose();
            overlay1?.Dispose();
            overlay2?.Dispose();

            return new ManagedDXTexture(bmp);
            */
        }

        protected static Image<Rgba32> GetBitmap(DatReaderWriter.DBObjs.RenderSurface texture) {
            if (texture.Format == PixelFormat.PFID_CUSTOM_RAW_JPEG) {
                using (var ms = new MemoryStream(texture.SourceData)) {
                    using (var src = Image.Load(ms)) {
                        texture.Width = src.Width;
                        texture.Height = src.Height;
                        return src.CloneAs<Rgba32>();
                    }
                }
            }
            var image = new Image<Rgba32>(texture.Width, texture.Height);
            var colorArray = GetImageColorArray(texture);
            switch (texture.Format) {
                case PixelFormat.PFID_R8G8B8:
                case PixelFormat.PFID_CUSTOM_LSCAPE_R8G8B8:
                    for (int i = 0; i < texture.Height; i++)
                        for (int j = 0; j < texture.Width; j++) {
                            int idx = i * texture.Width + j;
                            byte r = (byte)((colorArray[idx] & 0xFF0000) >> 16);
                            byte g = (byte)((colorArray[idx] & 0xFF00) >> 8);
                            byte b = (byte)(colorArray[idx] & 0xFF);
                            image[j, i] = Color.FromRgba(r, g, b, 255);
                        }
                    break;
                case PixelFormat.PFID_A8R8G8B8:
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
                case PixelFormat.PFID_A8:
                case PixelFormat.PFID_CUSTOM_LSCAPE_ALPHA:
                    for (int i = 0; i < texture.Height; i++)
                        for (int j = 0; j < texture.Width; j++) {
                            int idx = i * texture.Width + j;
                            int r = colorArray[idx];
                            int g = colorArray[idx];
                            int b = colorArray[idx];
                            image[j, i] = Color.FromRgba((byte)r, (byte)g, (byte)b, 255);
                        }
                    break;
                case PixelFormat.PFID_R5G6B5: // 16-bit RGB
                    for (int i = 0; i < texture.Height; i++)
                        for (int j = 0; j < texture.Width; j++) {
                            int idx = 3 * (i * texture.Width + j);
                            int r = colorArray[idx];
                            int g = colorArray[idx + 1];
                            int b = colorArray[idx + 2];
                            image[j, i] = Color.FromRgba((byte)r, (byte)g, (byte)b, 255);
                        }
                    break;
                case PixelFormat.PFID_A4R4G4B4:
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

        protected abstract void CreateTexture();
        protected abstract void ReleaseTexture();

        /// <summary>
        /// Release this texture
        /// </summary>
        public void Dispose() {
            ReleaseTexture();
            Bitmap?.Dispose();
            Bitmap = null;
        }

        /// <summary>
        /// Converts the byte array SourceData into color values per pixel
        /// </summary>
        private static List<int> GetImageColorArray(RenderSurface surface) {
            List<int> colors = new List<int>();
            if (surface.SourceData == null || surface.SourceData.Length == 0) return colors;

            switch (surface.Format) {
                case PixelFormat.PFID_R8G8B8: // RGB
                    using (BinaryReader reader = new BinaryReader(new MemoryStream(surface.SourceData))) {
                        for (uint i = 0; i < surface.Height; i++)
                            for (uint j = 0; j < surface.Width; j++) {
                                byte b = reader.ReadByte();
                                byte g = reader.ReadByte();
                                byte r = reader.ReadByte();
                                int color = (r << 16) | (g << 8) | b;
                                colors.Add(color);
                            }
                    }
                    break;
                case PixelFormat.PFID_CUSTOM_LSCAPE_R8G8B8:
                    using (BinaryReader reader = new BinaryReader(new MemoryStream(surface.SourceData))) {
                        for (uint i = 0; i < surface.Height; i++)
                            for (uint j = 0; j < surface.Width; j++) {
                                byte r = reader.ReadByte();
                                byte g = reader.ReadByte();
                                byte b = reader.ReadByte();
                                int color = (r << 16) | (g << 8) | b;
                                colors.Add(color);
                            }
                    }
                    break;
                case PixelFormat.PFID_A8R8G8B8: // ARGB format. Most UI textures fall into this category
                    using (BinaryReader reader = new BinaryReader(new MemoryStream(surface.SourceData))) {
                        for (uint i = 0; i < surface.Height; i++)
                            for (uint j = 0; j < surface.Width; j++)
                                colors.Add(reader.ReadInt32());
                    }
                    break;
                case PixelFormat.PFID_INDEX16: // 16-bit indexed colors. Index references position in a palette;
                    using (BinaryReader reader = new BinaryReader(new MemoryStream(surface.SourceData))) {
                        for (uint y = 0; y < surface.Height; y++)
                            for (uint x = 0; x < surface.Width; x++)
                                colors.Add(reader.ReadInt16());
                    }
                    break;
                case PixelFormat.PFID_A8: // Greyscale, also known as Cairo A8.
                case PixelFormat.PFID_CUSTOM_LSCAPE_ALPHA:
                    using (BinaryReader reader = new BinaryReader(new MemoryStream(surface.SourceData))) {
                        for (uint y = 0; y < surface.Height; y++)
                            for (uint x = 0; x < surface.Width; x++)
                                colors.Add(reader.ReadByte());
                    }
                    break;
                case PixelFormat.PFID_P8: // Indexed
                    using (BinaryReader reader = new BinaryReader(new MemoryStream(surface.SourceData))) {
                        for (uint y = 0; y < surface.Height; y++)
                            for (uint x = 0; x < surface.Width; x++)
                                colors.Add(reader.ReadByte());
                    }
                    break;
                case PixelFormat.PFID_R5G6B5: // 16-bit RGB
                    using (BinaryReader reader = new BinaryReader(new MemoryStream(surface.SourceData))) {
                        for (uint y = 0; y < surface.Height; y++)
                            for (uint x = 0; x < surface.Width; x++) {
                                ushort val = reader.ReadUInt16();
                                List<int> color = get565RGB(val);
                                colors.Add(color[0]); // Red
                                colors.Add(color[1]); // Green
                                colors.Add(color[2]); // Blue
                            }
                    }
                    break;
                case PixelFormat.PFID_A4R4G4B4:
                    using (BinaryReader reader = new BinaryReader(new MemoryStream(surface.SourceData))) {
                        for (uint y = 0; y < surface.Height; y++)
                            for (uint x = 0; x < surface.Width; x++) {
                                ushort val = reader.ReadUInt16();
                                int alpha = (val >> 12) / 0xF * 255;
                                int red = (val >> 8 & 0xF) / 0xF * 255;
                                int green = (val >> 4 & 0xF) / 0xF * 255;
                                int blue = (val & 0xF) / 0xF * 255;

                                colors.Add(alpha);
                                colors.Add(red);
                                colors.Add(green);
                                colors.Add(blue);
                            }
                    }
                    break;
                default:
                    throw new Exception("Unhandled PixelFormat (" + surface.Format.ToString() + ") in RenderSurface " + surface.Id.ToString("X8"));
                    break;
            }

            return colors;
        }

        // https://docs.microsoft.com/en-us/windows/desktop/DirectShow/working-with-16-bit-rgb
        private static List<int> get565RGB(ushort val) {
            List<int> color = new List<int>();

            int red_mask = 0xF800;
            int green_mask = 0x7E0;
            int blue_mask = 0x1F;

            int red = ((val & red_mask) >> 11) << 3;
            int green = ((val & green_mask) >> 5) << 2;
            int blue = (val & blue_mask) << 3;

            color.Add(red); // Red
            color.Add(green); // Green
            color.Add(blue); // Blue

            return color;
        }

        internal static Dictionary<string, uint> _uiEffects = new Dictionary<string, uint>() {
            { "", 0x060011C5 },
            { "magical", 0x060011CA },
            { "posioned", 0x060011C6 },
            { "boosthealth", 0x06001B05 },
            { "boostmana", 0x060011CA },
            { "booststamina", 0x06001B06 },
            { "fire", 0x06001B2E },
            { "lightning", 0x06001B2D },
            { "frost", 0x06001B2F },
            { "acid", 0x06001B2C },
            { "bludgeoning", 0x060033C3 },
            { "slashing", 0x060033C2 },
            { "piercing", 0x060033C4 }
        };

        private static Image<Rgba32> GetIconBitmap(uint id, IDatReaderInterface portalDat, out DatReaderWriter.DBObjs.RenderSurface? iconFile) {
            if (!portalDat.TryGet(id, out iconFile)) {
                throw new Exception($"Could not load icon from dat: 0x{id:X8}");
            }

            if (iconFile is null || iconFile.SourceData is null) {
                throw new Exception($"iconFile was null: 0x{id:X8}");
            }

            return GetBitmap(iconFile);
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
    }
}
