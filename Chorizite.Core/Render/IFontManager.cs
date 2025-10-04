using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Manages fonts
    /// </summary>
    public interface IFontManager : IDisposable {
        IFont GetFont(uint id);

        /// <summary>
        /// Get a font
        /// </summary>
        /// <param name="name"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public IFont GetFont(string name, int size);
    }
}
