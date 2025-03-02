using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Represents a color vector
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ColorVec {
        /// <summary>
        /// The red component, from 0 to 1
        /// </summary>
        public float Red;

        /// <summary>
        /// The green component, from 0 to 1
        /// </summary>
        public float Green;

        /// <summary>
        /// The blue component, from 0 to 1
        /// </summary>
        public float Blue;

        /// <summary>
        /// The alpha component, from 0 to 1
        /// </summary>
        public float Alpha;

        /// <summary>
        /// Constructs a color vector
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        public ColorVec(float alpha, float red, float green, float blue) {
            Alpha = alpha;
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}
