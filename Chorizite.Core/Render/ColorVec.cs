using System.Runtime.InteropServices;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Legacy color vector kept at the original namespace for plugin binary compatibility.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ColorVec {
        // Preserve the original field names and layout expected by released plugins.
        public float Red;
        public float Green;
        public float Blue;
        public float Alpha;

        public float R {
            readonly get => Red;
            set => Red = value;
        }

        public float G {
            readonly get => Green;
            set => Green = value;
        }

        public float B {
            readonly get => Blue;
            set => Blue = value;
        }

        public float A {
            readonly get => Alpha;
            set => Alpha = value;
        }

        public ColorVec(float red, float green, float blue) {
            Alpha = 1f;
            Red = red;
            Green = green;
            Blue = blue;
        }

        // Legacy constructor order: alpha, red, green, blue.
        public ColorVec(float alpha, float red, float green, float blue) {
            Alpha = alpha;
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}
