using ACClientLib.DatReaderWriter;
using ACClientLib.DatReaderWriter.Enums;
using Autofac.Core;
using MagicHat.Core.Dats;
using MagicHat.Core.Render;
using Microsoft.DirectX.Direct3D;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Security.Policy;
using System.Web;

namespace MagicHat.DecalService.Lib.Render {
    /// <summary>
    /// Holds a texture (from a bitmap), maybe other things later...
    /// Using this class will automatically recreate the texture as needed.
    /// </summary>
    public class ManagedDXTexture : ITexture {
        private static readonly Color BORDER_COLOR_MASK = Color.FromArgb(-1);
        private static readonly Color BACKGROUND_COLOR_MASK = Color.FromArgb(255, 0, 0, 0);

        /// <summary>
        /// The bitmap this texture is using.
        /// </summary>
        public Bitmap Bitmap { get; set; } = null;

        /// <summary>
        /// The DirectX texture
        /// </summary>
        public Texture Texture { get; set; } = null;

        /// <summary>
        /// Pointer to the unmanaged texture
        /// </summary>
        public unsafe IntPtr TexturePtr => Texture == null ? IntPtr.Zero : (IntPtr)Texture.UnmanagedComPointer;

        /// <summary>
        /// Create a new managed texture from a DX Texture.
        /// </summary>
        /// <param name="texture">The texture.</param>
        public ManagedDXTexture(Texture texture) : base() {
            Texture = texture;
        }

        /// <summary>
        /// Create a new managed texture from a bitmap file path.
        /// </summary>
        /// <param name="file">The bitmap file path for the texture.</param>
        public ManagedDXTexture(string file) : base() {
            Bitmap = new Bitmap(file);
            CreateTexture();
        }

        /// <summary>
        /// Create a new managed texture from a bitmap. This copies your bitmap data immediately
        /// so you can dispose the passed bitmap immediately.
        /// </summary>
        /// <param name="bitmap">The bitmap source for the texture.</param>
        public ManagedDXTexture(Bitmap bitmap) : base() {
            Bitmap = new Bitmap(bitmap);
            CreateTexture();
        }

        /// <summary>
        /// Create a new managed texture from a bitmap stream
        /// </summary>
        /// <param name="stream">The bitmap stream source</param>
        public ManagedDXTexture(Stream stream) : base() {
            Bitmap = new Bitmap(stream);
            CreateTexture();
        }

        private static Bitmap GetBitmap(ACDatReader.FileTypes.Texture texture) {
            if (texture.Format == SurfacePixelFormat.PFID_CUSTOM_RAW_JPEG) {
                using (var ms = new MemoryStream(texture.SourceData)) {
                    using (var src = new Bitmap(ms)) {
                        texture.Width = src.Width;
                        texture.Height = src.Height;
                        var bmp = new Bitmap(src.Width, src.Height, PixelFormat.Format32bppArgb);
                        bmp.MakeTransparent();
                        using (var gfx = Graphics.FromImage(bmp)) {
                            gfx.DrawImage(src, 0, 0, src.Width, src.Height);
                            gfx.Save();
                        }
                        return bmp;
                    }
                }
            }

            Bitmap image = new Bitmap(texture.Width, texture.Height);
            var colorArray = texture.GetImageColorArray();
            switch (texture.Format) {
                case SurfacePixelFormat.PFID_R8G8B8:
                case SurfacePixelFormat.PFID_CUSTOM_LSCAPE_R8G8B8:
                    for (int i = 0; i < texture.Height; i++)
                        for (int j = 0; j < texture.Width; j++) {
                            int idx = i * texture.Width + j;
                            int r = (colorArray[idx] & 0xFF0000) >> 16;
                            int g = (colorArray[idx] & 0xFF00) >> 8;
                            int b = colorArray[idx] & 0xFF;
                            image.SetPixel(j, i, Color.FromArgb(r, g, b));
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
                            image.SetPixel(j, i, Color.FromArgb(a, r, g, b));
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
                            image.SetPixel(j, i, Color.FromArgb(r, g, b));
                        }
                    break;
                case SurfacePixelFormat.PFID_R5G6B5: // 16-bit RGB
                    for (int i = 0; i < texture.Height; i++)
                        for (int j = 0; j < texture.Width; j++) {
                            int idx = 3 * (i * texture.Width + j);
                            int r = colorArray[idx];
                            int g = colorArray[idx + 1];
                            int b = colorArray[idx + 2];
                            image.SetPixel(j, i, Color.FromArgb(r, g, b));
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
                            image.SetPixel(j, i, Color.FromArgb(a, r, g, b));
                        }
                    break;
                default:
                    throw new Exception($"Unknown pixel format: {texture.Format}");
            }

            return image;
        }

        private static Bitmap SwapColor(Bitmap bmp, Color borderColor, Color backgroundColor) {
            for (int x = 0; x < bmp.Width; x++) {
                for (int y = 0; y < bmp.Height; y++) {
                    Color gotColor = bmp.GetPixel(x, y);
                    if (gotColor == BORDER_COLOR_MASK) {
                        bmp.SetPixel(x, y, borderColor);
                    }
                    else if (gotColor == BACKGROUND_COLOR_MASK) {
                        bmp.SetPixel(x, y, backgroundColor);
                    }
                }
            }
            return bmp;
        }

        internal void CreateTexture() {
            // avoid creating a new texture and losing reference to the old one,
            // if lost and not released, DX will crash later when resetting the device
            if (Texture != null)
                return;

            if (Bitmap != null)
                Texture = new Texture(DX9RenderInterface.D3Ddevice, Bitmap, Usage.Dynamic, Pool.Default);
        }

        internal void ReleaseTexture() {
            Texture?.Dispose();
            Texture = null;
        }

        /// <summary>
        /// Release this texture
        /// </summary>
        public void Dispose() {
            ReleaseTexture();
            Bitmap?.Dispose();
            Bitmap = null;
        }

        private static Dictionary<string, uint> _uiEffects = new Dictionary<string, uint>() {
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

        public static ManagedDXTexture FromDatUrl(string source, ILogger _log, IDatReaderInterface _portalDat) {
            var uri = new Uri(source);
            uint id = ParseDatId(uri.Host);
            Bitmap baseBmp = GetIconBitmap(id, _portalDat);

            if (baseBmp is null) return null;
            if (baseBmp?.Width == 32 && baseBmp?.Height == 32) return new ManagedDXTexture(baseBmp);

            var bmp = new Bitmap(baseBmp.Width, baseBmp.Height, PixelFormat.Format32bppArgb);
            bmp.MakeTransparent();

            Bitmap? underlay = null;
            Bitmap? uieffect = null;
            Bitmap? overlay1 = null;
            Bitmap? overlay2 = null;

            if (!string.IsNullOrEmpty(uri.Query)) {
                var query = HttpUtility.ParseQueryString(uri.Query);
                if (!string.IsNullOrEmpty(query["underlay"])) {
                    underlay = GetIconBitmap(ParseDatId(query["underlay"]), _portalDat);
                }
                if (!string.IsNullOrEmpty(query["overlay1"])) {
                    overlay1 = GetIconBitmap(ParseDatId(query["overlay1"]), _portalDat);
                }
                if (!string.IsNullOrEmpty(query["overlay2"])) {
                    overlay2 = GetIconBitmap(ParseDatId(query["overlay2"]), _portalDat);
                }
                if (!string.IsNullOrEmpty(query["uieffect"]) && _uiEffects.TryGetValue(query["uieffect"].ToLower(), out var effectId)) {
                    uieffect = GetIconBitmap(effectId, _portalDat);
                }
            }

            uieffect ??= GetIconBitmap(0x060011C5, _portalDat);

            using (var gfx = Graphics.FromImage(bmp)) {
                // ui effect
                if (baseBmp.Width == 32 && baseBmp.Height == 32) {
                    for (int x = 0; x < baseBmp.Width; x++) {
                        for (int y = 0; y < baseBmp.Height; y++) {
                            Color gotColor = baseBmp.GetPixel(x, y);
                            if (gotColor == BORDER_COLOR_MASK) {
                                baseBmp.SetPixel(x, y, uieffect.GetPixel(x, y));
                            }
                            else if (gotColor == BACKGROUND_COLOR_MASK) {
                                baseBmp.SetPixel(x, y, Color.Transparent);
                            }
                        }
                    }
                }

                if (underlay is not null) gfx.DrawImageUnscaled(underlay, Point.Empty);
                gfx.DrawImageUnscaled(baseBmp, Point.Empty);
                if (overlay1 is not null) gfx.DrawImageUnscaled(overlay1, Point.Empty);
                if (overlay2 is not null) gfx.DrawImageUnscaled(overlay2, Point.Empty);

                gfx.Save();
            }

            baseBmp?.Dispose();
            underlay?.Dispose();
            uieffect?.Dispose();
            overlay1?.Dispose();
            overlay2?.Dispose();

            return new ManagedDXTexture(bmp);
        }

        private static Bitmap GetIconBitmap(uint id, IDatReaderInterface portalDat) {
            if (!portalDat.TryGet<ACDatReader.FileTypes.Texture>(id, out var iconFile)) {
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
