using Chorizite.Core.Render.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Represents a texture
    /// </summary>
    public interface ITexture : IDisposable {
        /// <summary>
        /// The width
        /// </summary>
        int Width { get; }

        /// <summary>
        /// The height
        /// </summary>
        int Height { get; }

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
        ///     Sets the data for the specified rectangular region.
        /// </summary>
        /// <param name="rectangle">The rectangular area to which the data will be applied.</param>
        /// <param name="data">The data to set within the specified rectangle.</param>
        void SetData(Rectangle rectangle, byte[] data);

        /// <summary>
        /// Unbinds the texture
        /// </summary>
        public void Unbind();
    }
}
