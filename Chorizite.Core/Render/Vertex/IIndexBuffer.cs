using Chorizite.Core.Render.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.Vertex {
    /// <summary>
    /// Represents an index buffer
    /// </summary>
    public interface IIndexBuffer : IBuffer {
        /// <summary>
        /// Replaces the data in the index buffer
        /// </summary>
        /// <param name="data">Data to write</param>
        public void SetData(uint[] data);
        /// <summary>
        /// Replaces the data in the index buffer
        /// </summary>
        /// <param name="data">Data to write</param>
        public void SetData(Span<uint> data);

        /// <summary>
        /// Updates a section of the buffer without reallocating
        /// </summary>
        /// <param name="data">The data to upload</param>
        /// <param name="destinationOffsetBytes">Destination offset in bytes in the GPU buffer</param>
        /// <param name="sourceOffsetElements">Source offset in elements in the data array</param>
        /// <param name="lengthElements">Number of elements to copy, or 0 to use all remaining elements</param>
        public void SetSubData(Span<uint> data, int destinationOffsetBytes, int sourceOffsetElements = 0, int lengthElements = 0);

        /// <summary>
        /// Updates a section of the buffer without reallocating
        /// </summary>
        /// <param name="data">The data to upload</param>
        /// <param name="destinationOffsetBytes">Destination offset in bytes in the GPU buffer</param>
        /// <param name="sourceOffsetElements">Source offset in elements in the data array</param>
        /// <param name="lengthElements">Number of elements to copy, or 0 to use all remaining elements</param>
        public void SetSubData(uint[] data, int destinationOffsetBytes, int sourceOffsetElements = 0, int lengthElements = 0);
    }
}
