using MagicHat.Core.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Service.Lib.Extensions {
    internal static class VectorExtensions {
        public static int ToArgb(this ColorVec color) {
            return Color.FromArgb((int)(color.Alpha * 255), (int)(color.Red * 255), (int)(color.Green * 255), (int)(color.Blue * 255)).ToArgb();
        }
    }
}
