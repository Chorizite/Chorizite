using Chorizite.Core.Render.Enums;
using Chorizite.Core.Render.Vertex;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Represents options for rendering text
    /// </summary>
    public class TextOptions {
        /// <summary>
        /// The alignment of the text
        /// </summary>
        public TextAlign Align { get; set; } = TextAlign.Left;

        /// <summary>
        /// The vertical alignment of the text
        /// </summary>
        public TextVAlign VAlign { get; set; } = TextVAlign.Top;

        /// <summary>
        /// Whether to draw a shadow on the text with, not always available for all fonts
        /// </summary>
        public bool Shadow { get; set; } = false;

        /// <summary>
        /// The color of the shadow, only applicable if <see cref="Shadow"/> is true
        /// </summary>
        public ColorVec ShadowColor { get; set; } = ColorVec.Black;
    }
}