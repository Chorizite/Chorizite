using Chorizite.Core.Render.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.Vertex {
    /// <summary>
    /// Represents a vertex format
    /// </summary>
    public class VertexFormat {
        /// <summary>
        /// The vertex attributes
        /// </summary>
        public VertexAttribute[] Attributes { get; }

        /// <summary>
        /// The stride
        /// </summary>
        public int Stride => Attributes.Sum(a => a.Size * GetSize(a.Type));

        private int GetSize(VertexAttribType type) {
            switch (type) {
                case VertexAttribType.Float:
                    return sizeof(float);
                case VertexAttribType.Int:
                case VertexAttribType.UnsignedInt:
                    return sizeof(int);
                case VertexAttribType.Byte:
                case VertexAttribType.UnsignedByte:
                    return sizeof(byte);
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Constructs a vertex format
        /// </summary>
        /// <param name="attributes"></param>
        public VertexFormat(params VertexAttribute[] attributes) {
            Attributes = attributes;
        }
    }
}
