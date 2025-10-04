using Chorizite.Core.Render.Vertex;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Backends.ACBackend.Extensions {
    internal static class VectorExtensions {
        public static int ToArgb(this ColorVec color) {
            return Color.FromArgb((int)(color.A * 255), (int)(color.R * 255), (int)(color.G  * 255), (int)(color.B  * 255)).ToArgb();
        }
    }
}
