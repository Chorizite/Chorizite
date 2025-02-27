using SharpDX.Mathematics.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Backends.ACBackend.Extensions {
    internal static class MatrixExtensions {
        public static RawMatrix ToDX(this Matrix4x4 mat) {
            var dx = new RawMatrix();
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4x4 CreateOrthographicOffCenterLeftHanded(float left, float right, float bottom, float top, float zNearPlane, float zFarPlane) {
            // This implementation is based on the DirectX Math Library XMMatrixOrthographicOffCenterLH method
            // https://github.com/microsoft/DirectXMath/blob/master/Inc/DirectXMathMatrix.inl

            float reciprocalWidth = 1.0f / (right - left);
            float reciprocalHeight = 1.0f / (top - bottom);
            float range = 1.0f / (zFarPlane - zNearPlane);

            return new Matrix4x4(
                reciprocalWidth + reciprocalWidth, 0, 0, 0,
                0, reciprocalHeight + reciprocalHeight, 0, 0,
                0, 0, range, 0,
                -(left + right) * reciprocalWidth, -(top + bottom) * reciprocalHeight, -range * zNearPlane, 1
                );
        }
    }
}
