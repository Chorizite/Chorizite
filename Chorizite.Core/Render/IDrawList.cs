using Chorizite.Core.Render.Vertex;
using System;
using System.Numerics;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Represents a draw list for rendering 2D objects
    /// </summary>
    public interface IDrawList : IDisposable {
        /// <summary>
        /// Pushes a clip rectangle, which limits the drawing area. PopClipRect() must be called to restore the previous clip
        /// </summary>
        /// <param name="rect">The screen area to clip</param>
        public void PushClipRect(Rectangle rect);

        /// <summary>
        /// Restores the previous clip rectangle
        /// </summary>
        public void PopClipRect();

        /// <summary>
        /// Render this draw list to the screen
        /// </summary>
        public void Flush();

        /// <summary>
        /// Draws an outlined rectangle
        /// </summary>
        /// <param name="rect">The rectangle to draw</param>
        /// <param name="thickness">The border thickness</param>
        /// <param name="color">The border color</param>
        public void DrawRect(Rectangle rect, int thickness, ColorVec color);

        /// <summary>
        /// Draws a filled rectangle
        /// </summary>
        /// <param name="rect">The rectangle to draw</param>
        /// <param name="color">The fill color</param>
        public void DrawRectFilled(Rectangle rect, ColorVec color);

        /// <summary>
        /// Draws a texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="destRect">The screen area rectangle</param>
        /// <param name="uvs">The texture coordinates</param>
        public void DrawTexture(ITexture texture, Rectangle destRect, RectangleF? uvs = null);

        /// <summary>
        /// Draws text
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="dest"></param>
        /// <param name="color"></param>
        /// <param name="options"></param>
        public void DrawText(IFont font, string text, Rectangle dest, ColorVec color, TextOptions? options = null);

        /// <summary>
        /// Draws a ring
        /// </summary>
        /// <param name="center">The center of the ring</param>
        /// <param name="innerRadius">The inner radius</param>
        /// <param name="outerRadius">The outer radius</param>
        /// <param name="startAngle">The start angle</param>
        /// <param name="endAngle">The end angle</param>
        /// <param name="segments">The number of segments</param>
        /// <param name="color">The color</param>
        void DrawRing(Vector2 center, float innerRadius, float outerRadius, float startAngle, float endAngle, int segments, ColorVec color);
    }
}