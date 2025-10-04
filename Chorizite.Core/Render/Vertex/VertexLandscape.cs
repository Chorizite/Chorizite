using Chorizite.Core.Render.Enums;
using System;
using System.Numerics;
using System.Runtime.InteropServices;
namespace Chorizite.Core.Render.Vertex {
    [StructLayout(LayoutKind.Sequential)]
    public struct VertexLandscape : IVertex {
        private static readonly VertexFormat _format = new VertexFormat(
            new VertexAttribute(VertexAttributeName.Position, 3, VertexAttribType.Float, false, 0),
            new VertexAttribute(VertexAttributeName.Normal, 3, VertexAttribType.Float, false, 12),
            new VertexAttribute(VertexAttributeName.TexCoord0, 4, VertexAttribType.UnsignedByte, false, 24),
            // Packed overlay data as integers
            new VertexAttribute(VertexAttributeName.TexCoord1, 4, VertexAttribType.UnsignedByte, false, 28),
            new VertexAttribute(VertexAttributeName.TexCoord2, 4, VertexAttribType.UnsignedByte, false, 32),
            new VertexAttribute(VertexAttributeName.TexCoord3, 4, VertexAttribType.UnsignedByte, false, 36),
            new VertexAttribute(VertexAttributeName.TexCoord4, 4, VertexAttribType.UnsignedByte, false, 40),
            new VertexAttribute(VertexAttributeName.TexCoord5, 4, VertexAttribType.UnsignedByte, false, 44)
        );
        public static int Size => Marshal.SizeOf<VertexLandscape>();
        public static VertexFormat Format => _format;
        public Vector3 Position;
        public Vector3 Normal;
        public uint PackedBase;  // Packed base texture coord
        public uint PackedOverlay0;  // Overlay 1
        public uint PackedOverlay1;  // Overlay 2
        public uint PackedOverlay2;  // Overlay 3
        public uint PackedRoad0;     // Road 1
        public uint PackedRoad1;     // Road 2
        public VertexLandscape() {
            Position = Vector3.Zero;
            Normal = Vector3.Zero;
            PackedBase = PackTexCoord(0, 0, 255, 255);
            PackedOverlay0 = PackTexCoord(-1, -1, 255, 255);
            PackedOverlay1 = PackTexCoord(-1, -1, 255, 255);
            PackedOverlay2 = PackTexCoord(-1, -1, 255, 255);
            PackedRoad0 = PackTexCoord(-1, -1, 255, 255);
            PackedRoad1 = PackTexCoord(-1, -1, 255, 255);
        }
        // Helper methods for packing/unpacking
        public static uint PackTexCoord(float u, float v, byte texIdx, byte alphaIdx) {
            // Convert -1, 0, 1 to 0, 1, 2
            byte packedU = (byte)(u + 1);
            byte packedV = (byte)(v + 1);
            // Pack into uint: [packedV:2bits][packedU:2bits][reserved:4bits] | [reserved:8bits] | [texIdx:8bits] | [alphaIdx:8bits]
            return (uint)((packedV << 6) | (packedU << 4)) |
                   ((uint)texIdx << 16) |
                   ((uint)alphaIdx << 24);
        }
        public void SetBase(float u, float v, byte texIdx, byte alphaIdx) {
            PackedBase = PackTexCoord(u, v, texIdx, alphaIdx);
        }
        public void SetOverlay0(float u, float v, byte texIdx, byte alphaIdx) {
            PackedOverlay0 = PackTexCoord(u, v, texIdx, alphaIdx);
        }
        public void SetOverlay1(float u, float v, byte texIdx, byte alphaIdx) {
            PackedOverlay1 = PackTexCoord(u, v, texIdx, alphaIdx);
        }
        public void SetOverlay2(float u, float v, byte texIdx, byte alphaIdx) {
            PackedOverlay2 = PackTexCoord(u, v, texIdx, alphaIdx);
        }
        public void SetRoad0(float u, float v, byte texIdx, byte alphaIdx) {
            PackedRoad0 = PackTexCoord(u, v, texIdx, alphaIdx);
        }
        public void SetRoad1(float u, float v, byte texIdx, byte alphaIdx) {
            PackedRoad1 = PackTexCoord(u, v, texIdx, alphaIdx);
        }
    }
}