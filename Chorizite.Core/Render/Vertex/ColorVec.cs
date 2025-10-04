using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.Vertex {
    /// <summary>
    /// Represents a color vector
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ColorVec {
        /// <summary>
        /// White
        /// </summary>
        public static readonly ColorVec White = new ColorVec(1, 1, 1);
        
        /// <summary>
        /// Black
        /// </summary>
        public static readonly ColorVec Black = new ColorVec(0, 0, 0);

        /// <summary>
        /// Red
        /// </summary>
        public static readonly ColorVec Red = new ColorVec(1, 0, 0);

        /// <summary>
        /// Green
        /// </summary>
        public static readonly ColorVec Green = new ColorVec(0, 1, 0);

        /// <summary>
        /// Blue
        /// </summary>
        public static readonly ColorVec Blue = new ColorVec(0, 0, 1);

        /// <summary>
        /// Yellow
        /// </summary>
        public static readonly ColorVec Yellow = new ColorVec(1, 1, 0);

        /// <summary>
        /// Magenta
        /// </summary>
        public static readonly ColorVec Magenta = new ColorVec(1, 0, 1);

        /// <summary>
        /// Cyan
        /// </summary>
        public static readonly ColorVec Cyan = new ColorVec(0, 1, 1);
        
        /// <summary>
        /// Transparent
        /// </summary>
        public static readonly ColorVec Transparent = new ColorVec(0, 0, 0, 0);

        /// <summary>
        /// The red component, from 0 to 1
        /// </summary>
        public float R;

        /// <summary>
        /// The green component, from 0 to 1
        /// </summary>
        public float G;

        /// <summary>
        /// The blue component, from 0 to 1
        /// </summary>
        public float B;

        /// <summary>
        /// The alpha component, from 0 to 1
        /// </summary>
        public float A;

        /// <summary>
        /// Constructs a color vector
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        public ColorVec(float red, float green, float blue, float alpha = 1f) {
            A = alpha;
            R = red;
            G = green;
            B = blue;
        }
    }
}
