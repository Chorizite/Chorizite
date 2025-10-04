using Chorizite.Core.Dats;
using Chorizite.Core.Render.DrawCommands;
using Chorizite.Core.Render.Enums;
using Chorizite.Core.Render.Vertex;
using DatReaderWriter.DBObjs;
using DatReaderWriter.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Represents an AC font, loaded from the dats
    /// </summary>
    public class ACFont : IFont {
        private Dictionary<ushort, FontCharDesc> _fontCharCache = [];
        private readonly IGraphicsDevice _device;
        private readonly TextLayout _layout;

        /// <summary>
        /// The id of the font, from the dats
        /// </summary>
        public uint Id { get; }

        /// <inheritdoc />
        public ITexture Texture { get; }

        /// <summary>
        /// The shadow texture
        /// </summary>
        public ITexture ShadowTexture { get; }

        /// <summary>
        /// The maximum height of the font
        /// </summary>
        public float MaxCharHeight { get; }
        public uint NumHorizontalBorderPixels { get; }
        public uint NumVerticalBorderPixels { get; }
        public uint MaxCharWidth { get; }
        public uint BaselineOffset { get; }

        /// <inheritdoc />
        public bool HasMultipleTextures => true;

        internal ACFont(IGraphicsDevice device, IDatReaderInterface dat, uint id) {
            _device = device;
            Id = id;
            var font = dat.Get<Font>(Id) ?? dat.Get<Font>(0x40000000u)!;

            MaxCharHeight = font.MaxCharHeight;
            MaxCharWidth = font.MaxCharWidth;
            NumHorizontalBorderPixels = font.NumHorizontalBorderPixels;
            NumVerticalBorderPixels = font.NumVerticalBorderPixels;
            BaselineOffset = font.BaselineOffset;

            Texture = LoadFontTexture(dat, font.ForegroundSurfaceDataId);
            if (font.BackgroundSurfaceDataId != 0) {
                ShadowTexture = LoadFontTexture(dat, font.BackgroundSurfaceDataId);
            }

            foreach (var c in font.CharDescs) {
                _fontCharCache[c.Unicode] = c;
            }

            _layout = new TextLayout(c => CharFromFontCache(c));
        }

        private ITexture LoadFontTexture(IDatReaderInterface dat, uint surfaceId) {
            if (!dat.TryGet<RenderSurface>(surfaceId, out var surface)) {
                throw new Exception($"Failed to load font texture: 0x{surfaceId:X8}");
            }

            var bytes = new byte[surface.SourceData.Length * 4];
            for (int i = 0; i < surface.SourceData.Length; i++) {
                bytes[i * 4] = 255;
                bytes[i * 4 + 1] = 255;
                bytes[i * 4 + 2] = 255;
                bytes[i * 4 + 3] = surface.SourceData[i];
            }

            var texture = _device.CreateTexture(TextureFormat.RGBA8, surface.Width, surface.Height, bytes);
            if (texture is null) throw new Exception($"Failed to load font texture: 0x{surfaceId:X8}");
            return texture;
        }

        /// <inheritdoc />
        public void GetShadowVertices(DrawTextCommand command, ref VertexPositionColorTexture[] vertices, ref uint[] indices, ref int numVertices, ref int numIndices) {
            var color = command.Options.ShadowColor;
            float currentY = command.Dest.Y;
            var options = command.Options;
            float? maxW = command.Dest.Width > 0 ? command.Dest.Width : null;
            var (lines, lineWidths) = _layout.LayoutText(command.Text, maxW);
            float alignmentWidth = maxW ?? (lineWidths.Count > 0 ? lineWidths.Max() : 0);

            var textHeight = lines.Count * MaxCharHeight;
            if (options.VAlign == TextVAlign.Middle) {
                currentY += (command.Dest.Height - textHeight) / 2f;
            }
            else if (options.VAlign == TextVAlign.Bottom) {
                currentY += command.Dest.Height - textHeight;
            }

            for (int lineIndex = 0; lineIndex < lines.Count; lineIndex++) {
                var line = lines[lineIndex];
                float lineWidth = lineWidths[lineIndex];
                float startX = command.Dest.X;

                if (options.Align == TextAlign.Center) {
                    startX += (alignmentWidth - lineWidth) / 2f;
                }
                else if (options.Align == TextAlign.Right) {
                    startX += alignmentWidth - lineWidth;
                }

                float currentX = startX;

                foreach (char c in line) {
                    var charDesc = CharFromFontCache(c);
                    if (charDesc == null) continue;

                    currentX += charDesc.HorizontalOffsetBefore;

                    var x = (float)charDesc.OffsetX - (int)NumHorizontalBorderPixels;
                    var y = (float)charDesc.OffsetY - (int)NumVerticalBorderPixels;
                    var w = (float)charDesc.Width + (int)NumHorizontalBorderPixels * 2;
                    var h = (float)charDesc.Height + (int)NumVerticalBorderPixels * 2;

                    var charRect = new Rectangle(
                        (int)currentX - (int)NumHorizontalBorderPixels,
                        (int)(currentY + charDesc.VerticalOffsetBefore) - (int)NumVerticalBorderPixels,
                        (int)w,
                        (int)h
                    );
                    var uvRect = new Vector4(
                        x / (float)ShadowTexture.Width,
                        y / (float)ShadowTexture.Height,
                        (x + w) / (float)ShadowTexture.Width,
                        (y + h) / (float)ShadowTexture.Height
                    );

                    var startVertex = (uint)numVertices;

                    vertices[numVertices++] = new VertexPositionColorTexture(new Vector3(charRect.Left, charRect.Top, 0), color, new Vector2(uvRect.X, uvRect.Y));
                    vertices[numVertices++] = new VertexPositionColorTexture(new Vector3(charRect.Right, charRect.Top, 0), color, new Vector2(uvRect.Z, uvRect.Y));
                    vertices[numVertices++] = new VertexPositionColorTexture(new Vector3(charRect.Left, charRect.Bottom, 0), color, new Vector2(uvRect.X, uvRect.W));
                    vertices[numVertices++] = new VertexPositionColorTexture(new Vector3(charRect.Right, charRect.Bottom, 0), color, new Vector2(uvRect.Z, uvRect.W));

                    indices[numIndices++] = startVertex + 0;
                    indices[numIndices++] = startVertex + 1;
                    indices[numIndices++] = startVertex + 2;
                    indices[numIndices++] = startVertex + 2;
                    indices[numIndices++] = startVertex + 1;
                    indices[numIndices++] = startVertex + 3;

                    currentX += charDesc.Width + charDesc.HorizontalOffsetAfter;
                }

                currentY += MaxCharHeight;
            }
        }

        /// <inheritdoc />
        public void GetVertices(DrawTextCommand command, ref VertexPositionColorTexture[] vertices, ref uint[] indices, ref int numVertices, ref int numIndices) {
            var color = command.Color;
            float currentY = command.Dest.Y;
            var options = command.Options;
            float? maxW = command.Dest.Width > 0 ? command.Dest.Width : null;
            var (lines, lineWidths) = _layout.LayoutText(command.Text, maxW);
            float alignmentWidth = maxW ?? (lineWidths.Count > 0 ? lineWidths.Max() : 0);
            
            var textHeight = lines.Count * MaxCharHeight;
            if (options.VAlign == TextVAlign.Middle) {
                currentY += (command.Dest.Height - textHeight) / 2f;
            }
            else if (options.VAlign == TextVAlign.Bottom) {
                currentY += command.Dest.Height - textHeight;
            }

            for (int lineIndex = 0; lineIndex < lines.Count; lineIndex++) {
                var line = lines[lineIndex];
                float lineWidth = lineWidths[lineIndex];
                float startX = command.Dest.X;

                if (options.Align == TextAlign.Center) {
                    startX += (alignmentWidth - lineWidth) / 2f;
                }
                else if (options.Align == TextAlign.Right) {
                    startX += alignmentWidth - lineWidth;
                }

                float currentX = startX;

                foreach (char c in line) {
                    var charDesc = CharFromFontCache(c);
                    if (charDesc == null) continue;

                    currentX += charDesc.HorizontalOffsetBefore;

                    var charRect = new Rectangle(
                        (int)currentX,
                        (int)(currentY + charDesc.VerticalOffsetBefore),
                        charDesc.Width,
                        charDesc.Height
                    );

                    var uvRect = new Vector4(
                        (float)charDesc.OffsetX / (float)Texture.Width,
                        (float)charDesc.OffsetY / (float)Texture.Height,
                        ((float)charDesc.OffsetX + charDesc.Width) / (float)Texture.Width,
                        ((float)charDesc.OffsetY + charDesc.Height) / (float)Texture.Height
                    );

                    var startVertex = (uint)numVertices;

                    vertices[numVertices++] = new VertexPositionColorTexture(new Vector3(charRect.Left, charRect.Top, 0), color, new Vector2(uvRect.X, uvRect.Y));
                    vertices[numVertices++] = new VertexPositionColorTexture(new Vector3(charRect.Right, charRect.Top, 0), color, new Vector2(uvRect.Z, uvRect.Y));
                    vertices[numVertices++] = new VertexPositionColorTexture(new Vector3(charRect.Left, charRect.Bottom, 0), color, new Vector2(uvRect.X, uvRect.W));
                    vertices[numVertices++] = new VertexPositionColorTexture(new Vector3(charRect.Right, charRect.Bottom, 0), color, new Vector2(uvRect.Z, uvRect.W));

                    indices[numIndices++] = startVertex + 0;
                    indices[numIndices++] = startVertex + 1;
                    indices[numIndices++] = startVertex + 2;
                    indices[numIndices++] = startVertex + 2;
                    indices[numIndices++] = startVertex + 1;
                    indices[numIndices++] = startVertex + 3;

                    currentX += charDesc.Width + charDesc.HorizontalOffsetAfter;
                }

                currentY += MaxCharHeight;
            }
        }

        /// <inheritdoc />
        public Vector2 MeasureText(string text, float? maxWidth = null) {
            var (lines, lineWidths) = _layout.LayoutText(text, maxWidth);
            float totalWidth = lineWidths.Count > 0 ? lineWidths.Max() : 0;
            float totalHeight = lines.Count * MaxCharHeight;
            return new Vector2(totalWidth, totalHeight);
        }

        private FontCharDesc? CharFromFontCache(char c) {
            if (_fontCharCache.TryGetValue((ushort)c, out var charDesc)) return charDesc;
            return null;
        }

        /// <inheritdoc />
        public void Dispose() {
            Texture?.Dispose();
        }
    }
}