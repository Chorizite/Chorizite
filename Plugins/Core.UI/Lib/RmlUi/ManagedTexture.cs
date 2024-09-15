using ACClientLib.DatReaderWriter.Enums;
using Autofac.Core;
using Microsoft.DirectX.Direct3D;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ACUI.Lib.RmlUi {
    /// <summary>
    /// Holds a texture (from a bitmap), maybe other things later...
    /// Using this class will automatically recreate the texture as needed.
    /// </summary>
    public class ManagedTexture : IDisposable {
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
        public ManagedTexture(Texture texture) : base() {
            Texture = texture;
        }

        /// <summary>
        /// Create a new managed texture from a bitmap file path.
        /// </summary>
        /// <param name="file">The bitmap file path for the texture.</param>
        public ManagedTexture(string file) : base() {
            Bitmap = new Bitmap(file);
            CreateTexture();
        }

        /// <summary>
        /// Create a new managed texture from a bitmap. This copies your bitmap data immediately
        /// so you can dispose the passed bitmap immediately.
        /// </summary>
        /// <param name="bitmap">The bitmap source for the texture.</param>
        public ManagedTexture(Bitmap bitmap) : base() {
            Bitmap = new Bitmap(bitmap);
            CreateTexture();
        }

        /// <summary>
        /// Create a new managed texture from a bitmap stream
        /// </summary>
        /// <param name="stream">The bitmap stream source</param>
        public ManagedTexture(Stream stream) : base() {
            Bitmap = new Bitmap(stream);
            CreateTexture();
        }

        public ManagedTexture(uint icon, ACClientLib.DatReaderWriter.DatDatabaseReader _portalDat, bool border) {
            if (icon < 0x06000000)
                icon += 0x06000000;

            if (!_portalDat.TryReadFile<ACDatReader.FileTypes.Texture>(icon, out var iconFile)) {
                UI.Instance.Log?.LogError($"Could not load icon from dat: 0x{icon:X8}");
                return;
            }

            if (iconFile is null || iconFile.SourceData is null) {
                UI.Instance.Log?.LogError($"iconFile was null: 0x{icon:X8}");
                return;
            }

            Bitmap = GetBitmap(iconFile, border);
            CreateTexture();
        }

        private Bitmap GetBitmap(ACDatReader.FileTypes.Texture texture, bool border) {
            Bitmap image = new Bitmap(texture.Width, texture.Height);
            var colorArray = texture.GetImageColorArray();
            switch (texture.Format) {
                case SurfacePixelFormat.PFID_R8G8B8:
                case SurfacePixelFormat.PFID_CUSTOM_LSCAPE_R8G8B8:
                    for (int i = 0; i < texture.Height; i++)
                        for (int j = 0; j < texture.Width; j++) {
                            int idx = (i * texture.Width) + j;
                            int r = (colorArray[idx] & 0xFF0000) >> 16;
                            int g = (colorArray[idx] & 0xFF00) >> 8;
                            int b = colorArray[idx] & 0xFF;
                            image.SetPixel(j, i, Color.FromArgb(r, g, b));
                        }
                    break;
                case SurfacePixelFormat.PFID_A8R8G8B8:
                    for (int i = 0; i < texture.Height; i++)
                        for (int j = 0; j < texture.Width; j++) {
                            int idx = (i * texture.Width) + j;
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
                            int idx = (i * texture.Width) + j;
                            int r = colorArray[idx];
                            int g = colorArray[idx];
                            int b = colorArray[idx];
                            image.SetPixel(j, i, Color.FromArgb(r, g, b));
                        }
                    break;
                case SurfacePixelFormat.PFID_R5G6B5: // 16-bit RGB
                    for (int i = 0; i < texture.Height; i++)
                        for (int j = 0; j < texture.Width; j++) {
                            int idx = 3 * ((i * texture.Width) + j);
                            int r = (int)(colorArray[idx]);
                            int g = (int)(colorArray[idx + 1]);
                            int b = (int)(colorArray[idx + 2]);
                            image.SetPixel(j, i, Color.FromArgb(r, g, b));
                        }
                    break;
                case SurfacePixelFormat.PFID_A4R4G4B4:
                    for (int i = 0; i < texture.Height; i++)
                        for (int j = 0; j < texture.Width; j++) {
                            int idx = 4 * ((i * texture.Width) + j);
                            int a = (colorArray[idx]);
                            int r = (colorArray[idx + 1]);
                            int g = (colorArray[idx + 2]);
                            int b = (colorArray[idx + 3]);
                            image.SetPixel(j, i, Color.FromArgb(a, r, g, b));
                        }
                    break;
            }

            return SwapColor(image, border ? Color.Magenta : Color.Transparent, Color.Transparent);
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

#if NET35_OR_GREATER
            if (Bitmap != null)
                Texture = new Texture(CoreUIPlugin.UI.Backend.GetD3DDevice(), Bitmap, Usage.Dynamic, Pool.Default);
#endif
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
    }
}
