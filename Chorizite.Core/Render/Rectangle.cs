using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Represents a rectangle
    /// </summary>
    public struct Rectangle {
        /// <summary>
        /// The X position, from the left of the screen
        /// </summary>
        public int X;

        /// <summary>
        /// The Y position, from the top of the screen
        /// </summary>
        public int Y;

        /// <summary>
        /// The width
        /// </summary>
        public int Width;

        /// <summary>
        /// The height
        /// </summary>
        public int Height;

        /// <summary>
        /// The left edge
        /// </summary>
        public int Left {
            get => X;
            set => X = value;
        }

        /// <summary>
        /// The right edge
        /// </summary>
        public int Right {
            get => X + Width;
            set => Width = value - X;
        }

        /// <summary>
        /// The top edge
        /// </summary>
        public int Top {
            get => Y;
            set => Y = value;
        }

        /// <summary>
        /// The bottom edge
        /// </summary>
        public int Bottom {
            get => Y + Height;
            set => Height = value - Y;
        }

        /// <summary>
        /// Constructs a rectangle
        /// </summary>
        /// <param name="x">The X position, from the left of the screen</param>
        /// <param name="y">The Y position, from the top of the screen</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public Rectangle(int x, int y, int width, int height) {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }

    /// <summary>
    /// Represents a rectangle
    /// </summary>
    public struct RectangleF {
        /// <summary>
        /// The X position, from the left of the screen
        /// </summary>
        public float X;

        /// <summary>
        /// The Y position, from the top of the screen
        /// </summary>
        public float Y;

        /// <summary>
        /// The width
        /// </summary>
        public float Width;

        /// <summary>
        /// The height
        /// </summary>
        public float Height;

        /// <summary>
        /// The left edge
        /// </summary>
        public float Left {
            get => X;
            set => X = value;
        }

        /// <summary>
        /// The right edge
        /// </summary>
        public float Right {
            get => X + Width;
            set => Width = value - X;
        }

        /// <summary>
        /// The top edge
        /// </summary>
        public float Top {
            get => Y;
            set => Y = value;
        }

        /// <summary>
        /// The bottom edge
        /// </summary>
        public float Bottom {
            get => Y + Height;
            set => Height = value - Y;
        }

        /// <summary>
        /// Constructs a rectangle
        /// </summary>
        /// <param name="x">The X position, from the left of the screen</param>
        /// <param name="y">The Y position, from the top of the screen</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public RectangleF(float x, float y, float width, float height) {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
