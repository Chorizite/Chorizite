using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render {
    public interface ITexture : IDisposable {
        /// <summary>
        /// The width of the texture
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// The height of the texture
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// The pointer to the texture
        /// </summary>
        IntPtr TexturePtr { get; }

        /// <summary>
        /// Whether the texture uses premultiplied alpha
        /// </summary>
        public bool PreMultipliedAlpha { get; }
    }
}
