using System.Numerics;
using System.Runtime.InteropServices;

namespace RmlUiNet
{

    [Flags]
    public enum DefaultActionPhase : int {
        None = 0,
        Capture = 1,
        Target = 2,
        Bubble = 4
    }

    public enum ModalFlag
    {
        /// <summary>Remove modal state.</summary>
        None,

        /// <summary>Set modal state, other documents cannot receive focus.</summary>
        Modal,

        /// <summary>Modal state unchanged.</summary>
        Keep
    }

    public enum FocusFlag
    {
        /// <summary>No focus.</summary>
        None,

        /// <summary>Focus the document.</summary>
        Document,

        /// <summary>Focus the element in the document which last had focus.</summary>
        Keep,

        /// <summary>Focus the first tab element with the 'autofocus' attribute or else the document.</summary>
        Auto
    }

    public enum ScrollBehavior {
        Auto,
        Smooth,
        Instant
    }

    public enum VariantType {
        NONE = '-',
        BOOL = 'B',
        BYTE = 'b',
        CHAR = 'c',
        FLOAT = 'f',
        DOUBLE = 'd',
        INT = 'i',
        INT64 = 'I',
        UINT = 'u',
        UINT64 = 'U',
        STRING = 's',
        VECTOR2 = '2',
        VECTOR3 = '3',
        VECTOR4 = '4',
        COLOURF = 'g',
        COLOURB = 'h',
        SCRIPTINTERFACE = 'p',
        TRANSFORMPTR = 't',
        TRANSITIONLIST = 'T',
        ANIMATIONLIST = 'A',
        DECORATORSPTR = 'D',
        FILTERSPTR = 'F',
        FONTEFFECTSPTR = 'E',
        COLORSTOPLIST = 'C',
        BOXSHADOWLIST = 'S',
        VOIDPTR = '*',
    };

    public enum FontWeight
    {
        Auto,
        Normal = 400,
        Bold = 700
    }

    public enum BoxArea { Margin, Border, Padding, Content, Auto };

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Vector2i
    {
        public readonly int X;
        public readonly int Y;

        public Vector2i(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Vector2f
    {
        public readonly float X;
        public readonly float Y;

        public Vector2f(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Vertex
    {
        /// <summary>Two-dimensional position of the vertex (usually in pixels).</summary>
        public readonly Vector2f Position;

        /// <summary>RGBA-ordered 8-bit / channel colour.</summary>
        public readonly ColorB Colour;

        /// <summary>Texture coordinate for any associated texture.</summary>
        public readonly Vector2f TextureCoordinates;
    }

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ColorB
    {
        public readonly byte Red;
        public readonly byte Green;
        public readonly byte Blue;
        public readonly byte Alpha;

        public override string ToString()
        {
            return $"({Red}, {Green}, {Blue}, {Alpha})";
        }
    }
}
