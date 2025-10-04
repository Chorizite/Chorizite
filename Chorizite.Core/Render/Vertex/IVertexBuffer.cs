using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.Vertex {
    /// <summary>
    /// Represents a vertex buffer
    /// </summary>
    public interface IVertexBuffer : IBuffer {
        /// <summary>
        /// Replaces the data in the buffer
        /// </summary>
        /// <param name="data">Data to write</param>
        public void SetData<T>(T[] data) where T : IVertex;

        /// <summary>
        /// Replaces the data in the buffer
        /// </summary>
        /// <param name="data">Data to write</param>
        public void SetData<T>(Span<T> data) where T : IVertex;

        /// <summary>
        /// Updates a section of the buffer without reallocating
        /// </summary>
        /// <param name="data">The data to upload</param>
        /// <param name="destinationOffsetBytes">Destination offset in bytes in the GPU buffer</param>
        /// <param name="sourceOffsetElements">Source offset in elements in the data array</param>
        /// <param name="lengthElements">Number of elements to copy, or 0 to use all remaining elements</param>
        public void SetSubData<T>(T[] data, int destinationOffsetBytes, int sourceOffsetElements = 0, int lengthElements = 0) where T : IVertex;


        /// <summary>
        /// Updates a section of the buffer without reallocating
        /// </summary>
        /// <param name="data">The data to upload</param>
        /// <param name="destinationOffsetBytes">Destination offset in bytes in the GPU buffer</param>
        /// <param name="sourceOffsetElements">Source offset in elements in the data array</param>
        /// <param name="lengthElements">Number of elements to copy, or 0 to use all remaining elements</param>
        public void SetSubData<T>(Span<T> data, int destinationOffsetBytes, int sourceOffsetElements = 0, int lengthElements = 0) where T : IVertex;
    }
}
