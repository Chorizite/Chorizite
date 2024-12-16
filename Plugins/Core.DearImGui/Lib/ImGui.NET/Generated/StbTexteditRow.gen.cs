using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct StbTexteditRow
    {
        public float x0;
        public float x1;
        public float baseline_y_delta;
        public float ymin;
        public float ymax;
        public int num_chars;
    }
    public unsafe partial struct StbTexteditRowPtr
    {
        public StbTexteditRow* NativePtr { get; }
        public StbTexteditRowPtr(StbTexteditRow* nativePtr) => NativePtr = nativePtr;
        public StbTexteditRowPtr(IntPtr nativePtr) => NativePtr = (StbTexteditRow*)nativePtr;
        public static implicit operator StbTexteditRowPtr(StbTexteditRow* nativePtr) => new StbTexteditRowPtr(nativePtr);
        public static implicit operator StbTexteditRow* (StbTexteditRowPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator StbTexteditRowPtr(IntPtr nativePtr) => new StbTexteditRowPtr(nativePtr);
        public float x0 { get { return NativePtr->x0; } set { NativePtr->x0 = value; } }
        public float x1 { get { return NativePtr->x1; } set { NativePtr->x1 = value; } }
        public float baseline_y_delta { get { return NativePtr->baseline_y_delta; } set { NativePtr->baseline_y_delta = value; } }
        public float ymin { get { return NativePtr->ymin; } set { NativePtr->ymin = value; } }
        public float ymax { get { return NativePtr->ymax; } set { NativePtr->ymax = value; } }
        public int num_chars { get { return NativePtr->num_chars; } set { NativePtr->num_chars = value; } }
    }
}
