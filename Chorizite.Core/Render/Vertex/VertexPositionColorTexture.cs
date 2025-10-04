using Chorizite.Core.Render.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.Vertex {
    /// <summary>
    /// Represents a vertex with position, color and texture coordinates
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VertexPositionColorTexture : IVertex {
        private static readonly VertexFormat _format = new VertexFormat(
            new VertexAttribute(VertexAttributeName.Position, 3, VertexAttribType.Float, false, 0),
            new VertexAttribute(VertexAttributeName.Color, 4, VertexAttribType.Float, false, 12),
            new VertexAttribute(VertexAttributeName.TexCoords, 2, VertexAttribType.Float, false, 28)
        );

        /// <summary>
        /// The size of the vertex, in bytes
        /// </summary>
        public static int Size => Marshal.SizeOf<VertexPositionColorTexture>();

        /// <summary>
        /// The vertex format for this vertex type
        /// </summary>
        public static VertexFormat Format => _format;

        /// <summary>
        /// The position
        /// </summary>
        public Vector3 Position;

        /// <summary>
        /// The color
        /// </summary>
        public ColorVec Color;

        /// <summary>
        /// The texture coordinates
        /// </summary>
        public Vector2 TexCoords;

        /// <summary>
        /// Constructs a vertex
        /// </summary>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <param name="texCoords"></param>
        public VertexPositionColorTexture(Vector3 position, ColorVec color, Vector2 texCoords) {
            Position = position;
            Color = color;
            TexCoords = texCoords;
        }
    }
}
