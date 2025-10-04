using Chorizite.Core.Render.Enums;
using System.Numerics;

namespace Chorizite.Core.Render.DrawCommands {
    /// <summary>
    /// Draw command for drawing a texture
    /// </summary>
    public struct DrawTextureCommand : IDrawCommand {
        /// <inheritdoc/>
        public DrawCommandType Type => DrawCommandType.DrawTexture;

        /// <summary>
        /// Texture to draw
        /// </summary>
        public ITexture Texture;

        /// <summary>
        /// Rectangle to draw to on screen
        /// </summary>
        public Rectangle Rectangle;

        /// <summary>
        /// UV coordinates
        /// </summary>
        public RectangleF UVs { get; }

        /// <summary>
        /// Create a new texture draw command
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The screen rectangle</param>
        public DrawTextureCommand(ITexture texture, Rectangle rect, RectangleF uvs) {
            Texture = texture;
            Rectangle = rect;
            UVs = uvs;
        }
    }
}
