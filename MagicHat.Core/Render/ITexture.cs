using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core.Render {
    public interface ITexture : IDisposable
    {
        IntPtr TexturePtr { get; }
    }
}
