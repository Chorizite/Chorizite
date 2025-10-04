using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.Vertex {
    /// <summary>
    /// Interface for a vertex array
    /// </summary>
    public interface IVertexArray : IDisposable {
        /// <summary>
        /// Sets the vertex buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="format"></param>
        public void SetVertexBuffer(IVertexBuffer buffer, VertexFormat format);

        /// <summary>
        /// Binds the vertex array
        /// </summary>
        public void Bind();

        /// <summary>
        /// Unbinds the vertex array
        /// </summary>
        public void Unbind();
    }
}
