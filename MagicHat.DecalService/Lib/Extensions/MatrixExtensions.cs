using Microsoft.DirectX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Service.Lib.Extensions {
    internal static class MatrixExtensions {
        public static Matrix ToDX(this Matrix4x4 mat) {
            var dx = new Matrix();
            dx.M11 = mat.M11;
            dx.M12 = mat.M12;
            dx.M13 = mat.M13;
            dx.M14 = mat.M14;
            dx.M21 = mat.M21;
            dx.M22 = mat.M22;
            dx.M23 = mat.M23;
            dx.M24 = mat.M24;
            dx.M31 = mat.M31;
            dx.M32 = mat.M32;
            dx.M33 = mat.M33;
            dx.M34 = mat.M34;
            dx.M41 = mat.M41;
            dx.M42 = mat.M42;
            dx.M43 = mat.M43;
            dx.M44 = mat.M44;
            return dx;
        }
    }
}
