using Chorizite.Core.Render.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Texture Array interface
    /// </summary>
    public interface ITextureArray : IDisposable {
        /// <summary>
        /// The width
        /// </summary>
        int Width { get; }

        /// <summary>
        /// The height
        /// </summary>
        int Height { get; }

        /// <summary>
        /// The number of textures in the array
        /// </summary>
        int Size { get; }

        /// <summary>
        /// The format
        /// </summary>
        TextureFormat Format { get; }

        /// <summary>
        /// A pointer to the native device texture
        /// </summary>
        IntPtr NativePtr { get; }

        /// <summary>
        /// Binds the texture
        /// </summary>
        /// <param name="slot">The texture slot</param>
        public void Bind(int slot = 0);

        /// <summary>
        /// Add a new layer to the texture array in the first available slot.
        /// </summary>
        /// <param name="data">The byte array containing the data to assign to the specified layer. Cannot be null.</param>
        /// <returns>The newly created layers index</returns>
        int AddLayer(byte[] data);

        /// <summary>
        /// Add a new layer to the texture array in the first available slot.
        /// </summary>
        /// <param name="data">The byte array containing the data to assign to the specified layer. Cannot be null.</param>
        /// <returns>The newly created layers index</returns>
        int AddLayer(Span<byte> data);

        /// <summary>
        /// Updates the specified layer with the provided data.
        /// </summary>
        /// <param name="layer">The zero-based index of the layer to update. Must be within the valid range of existing layers.</param>
        /// <param name="data">The data to apply to the layer. Cannot be null.</param>
        void UpdateLayer(int layer, byte[] data);

        /// <summary>
        /// Removes the layer at the specified index.
        /// </summary>
        /// <param name="layer">The zero-based index of the layer to remove. Must be within the valid range of existing layers.</param>
        void RemoveLayer(int layer);

        /// <summary>
        /// Unbinds the texture
        /// </summary>
        public void Unbind();
    }
}
