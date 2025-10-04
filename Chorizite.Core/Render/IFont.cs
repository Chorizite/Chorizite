using Chorizite.Core.Render.DrawCommands;
using Chorizite.Core.Render.Vertex;
using System;
using System.Numerics;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Represents a font
    /// </summary>
    public interface IFont : IDisposable{
        /// <summary>
        /// The texture that holds the font
        /// </summary>
        public ITexture Texture { get; }

        /// <summary>
        /// The texture that holds the shadow, if any
        /// </summary>
        public ITexture? ShadowTexture { get; }

        /// <summary>
        /// Get the vertices and indices for the text
        /// </summary>
        /// <param name="command"></param>
        /// <param name="vertices"></param>
        /// <param name="indices"></param>
        /// <param name="numVertices"></param>
        /// <param name="numIndices"></param>
        void GetVertices(DrawTextCommand command, ref VertexPositionColorTexture[] vertices, ref uint[] indices, ref int numVertices, ref int numIndices);

        /// <summary>
        /// Get the vertices and indices for the text shadow
        /// </summary>
        /// <param name="command"></param>
        /// <param name="vertices"></param>
        /// <param name="indices"></param>
        /// <param name="numVertices"></param>
        /// <param name="numIndices"></param>
        void GetShadowVertices(DrawTextCommand command, ref VertexPositionColorTexture[] vertices, ref uint[] indices, ref int numVertices, ref int numIndices);

        /// <summary>
        /// Measures the text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxWidth"></param>
        /// <returns></returns>
        public Vector2 MeasureText(string text, float? maxWidth = null);
    }
}