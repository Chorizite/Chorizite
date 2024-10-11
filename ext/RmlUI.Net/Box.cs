using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet {
    public unsafe class Box : RmlBase<Event> {

        internal Box(IntPtr ptr) : base(ptr) {

        }

        public Vector2f GetPosition(BoxArea area) {
            var v2 = (Vector2f*)Native.Box.GetPosition(NativePtr, (int)area);
            return new Vector2f(v2->X, v2->Y);
        }

        public Vector2f GetSize() {
            var v2 = (Vector2f*)Native.Box.GetSize(NativePtr);
            return new Vector2f(v2->X, v2->Y);
        }

        public Vector2f GetSize(BoxArea area) {
            var v2 = (Vector2f*)Native.Box.GetSize(NativePtr, (int)area);
            return new Vector2f(v2->X, v2->Y);
        }
    }
}
