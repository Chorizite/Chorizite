using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Lib {
    public struct BoundingBox {
        public Vector3 Min;
        public Vector3 Max;

        public BoundingBox(Vector3 min, Vector3 max) {
            Min = min;
            Max = max;
        }

        public Vector3 Center => (Min + Max) * 0.5f;
        public Vector3 Size => Max - Min;
    }
}
