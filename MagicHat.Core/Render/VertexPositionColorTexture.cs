using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core.Render {
    [StructLayout(LayoutKind.Sequential)]
    public struct VertexPositionColorTexture {
        public static readonly int Size = Marshal.SizeOf<VertexPositionColorTexture>();

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
