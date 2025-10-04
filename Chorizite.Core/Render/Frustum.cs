using Chorizite.Core.Lib;
using System;
using System.Numerics;

namespace Chorizite.Core.Render {
    public struct Frustum {
        public Plane[] Planes;

        public Frustum(Matrix4x4 viewProjection) {
            Planes = new Plane[6];

            // Extract frustum planes from view-projection matrix
            // Left plane
            Planes[0] = new Plane(
                viewProjection.M14 + viewProjection.M11,
                viewProjection.M24 + viewProjection.M21,
                viewProjection.M34 + viewProjection.M31,
                viewProjection.M44 + viewProjection.M41
            );

            // Right plane
            Planes[1] = new Plane(
                viewProjection.M14 - viewProjection.M11,
                viewProjection.M24 - viewProjection.M21,
                viewProjection.M34 - viewProjection.M31,
                viewProjection.M44 - viewProjection.M41
            );

            // Bottom plane
            Planes[2] = new Plane(
                viewProjection.M14 + viewProjection.M12,
                viewProjection.M24 + viewProjection.M22,
                viewProjection.M34 + viewProjection.M32,
                viewProjection.M44 + viewProjection.M42
            );

            // Top plane
            Planes[3] = new Plane(
                viewProjection.M14 - viewProjection.M12,
                viewProjection.M24 - viewProjection.M22,
                viewProjection.M34 - viewProjection.M32,
                viewProjection.M44 - viewProjection.M42
            );

            // Near plane
            Planes[4] = new Plane(
                viewProjection.M13,
                viewProjection.M23,
                viewProjection.M33,
                viewProjection.M43
            );

            // Far plane
            Planes[5] = new Plane(
                viewProjection.M14 - viewProjection.M13,
                viewProjection.M24 - viewProjection.M23,
                viewProjection.M34 - viewProjection.M33,
                viewProjection.M44 - viewProjection.M43
            );

            // Normalize planes
            for (int i = 0; i < 6; i++) {
                var length = Math.Sqrt(Planes[i].Normal.X * Planes[i].Normal.X +
                                     Planes[i].Normal.Y * Planes[i].Normal.Y +
                                     Planes[i].Normal.Z * Planes[i].Normal.Z);
                Planes[i] = new Plane(
                    Planes[i].Normal.X / (float)length,
                    Planes[i].Normal.Y / (float)length,
                    Planes[i].Normal.Z / (float)length,
                    Planes[i].D / (float)length
                );
            }
        }

        public bool IntersectsBoundingBox(BoundingBox box) {
            for (int i = 0; i < 6; i++) {
                var plane = Planes[i];

                // Get the positive vertex (furthest point in direction of plane normal)
                var positiveVertex = new Vector3(
                    plane.Normal.X >= 0 ? box.Max.X : box.Min.X,
                    plane.Normal.Y >= 0 ? box.Max.Y : box.Min.Y,
                    plane.Normal.Z >= 0 ? box.Max.Z : box.Min.Z
                );

                // If positive vertex is behind plane, box is completely outside
                if (Vector3.Dot(plane.Normal, positiveVertex) + plane.D < 0) {
                    return false;
                }
            }

            return true;
        }
    }
}
