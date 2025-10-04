using Chorizite.Core.Render.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.Vertex {
    /// <summary>
    /// Represents a buffer
    /// </summary>
    public interface IBuffer : IDisposable {
        /// <summary>
        /// The size of the buffer, in bytes
        /// </summary>
        int Size { get; }

        /// <summary>
        /// The usage type of the buffer
        /// </summary>
        BufferUsage Usage { get; }

        /// <summary>
        /// Binds the buffer
        /// </summary>
        void Bind();

        /// <summary>
        /// Unbinds the buffer
        /// </summary>
        void Unbind();
    }
}
