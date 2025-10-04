using Chorizite.Core.Render.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.Vertex {
    /// <summary>
    /// Represents a vertex attribute
    /// </summary>
    public struct VertexAttribute {
        /// <summary>
        /// The name of the attribute
        /// </summary>
        public VertexAttributeName Name;

        /// <summary>
        /// The size of the attribute (number of components, not bytes)
        /// </summary>
        public int Size;

        /// <summary>
        /// The type of the attribute
        /// </summary>
        public VertexAttribType Type;

        /// <summary>
        /// Whether the attribute is normalized
        /// </summary>
        public bool Normalized;

        /// <summary>
        /// The offset of the attribute, in bytes
        /// </summary>
        public int Offset;

        /// <summary>
        /// Constructs a vertex attribute
        /// </summary>
        /// <param name="name"></param>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <param name="normalized"></param>
        /// <param name="offset"></param>
        public VertexAttribute(VertexAttributeName name, int size, VertexAttribType type, bool normalized, int offset) {
            Name = name;
            Size = size;
            Type = type;
            Normalized = normalized;
            Offset = offset;
        }
    }
}
