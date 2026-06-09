using Chorizite.Core.Render.Enums;
using Chorizite.Core.Render.Vertex;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Legacy vertex type kept at the original namespace for plugin binary compatibility.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VertexPositionColorTexture : IVertex {
        private static readonly VertexFormat _format = new VertexFormat(
            new VertexAttribute(VertexAttributeName.Position, 3, VertexAttribType.Float, false, 0),
            new VertexAttribute(VertexAttributeName.Color, 4, VertexAttribType.Float, false, 12),
            new VertexAttribute(VertexAttributeName.TexCoords, 2, VertexAttribType.Float, false, 28)
        );

        public static int Size => Marshal.SizeOf<VertexPositionColorTexture>();

        public static VertexFormat Format => _format;

        public Vector3 Position;

        public ColorVec Color;

        public Vector2 TexCoords;

        public VertexPositionColorTexture(Vector3 position, ColorVec color, Vector2 texCoords) {
            Position = position;
            Color = color;
            TexCoords = texCoords;
        }
    }
}
