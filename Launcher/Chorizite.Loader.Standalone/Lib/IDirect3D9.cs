namespace Chorizite.Loader.Standalone.Lib {
    /// <summary>
    /// Contains the D3D9 interface.
    /// </summary>
    public enum IDirect3D9 {
        /*** IUnknown methods ***/
        QueryInterface,
        AddRef,
        Release,

        /*** IDirect3D9 methods ***/
        RegisterSoftwareDevice,
        GetAdapterCount,
        GetAdapterIdentifier,
        GetAdapterModeCount,
        EnumAdapterModes,
        GetAdapterDisplayMode,
        CheckDeviceType,
        CheckDeviceFormat,
        CheckDeviceMultiSampleType,
        CheckDepthStencilMatch,
        CheckDeviceFormatConversion,
        GetDeviceCaps,
        GetAdapterMonitor,
        CreateDevice
    }
    public unsafe struct BlittablePtr<T> where T : unmanaged {
        /// <summary>
        /// The pointer to the value.
        /// </summary>
        public T* Pointer { get; set; }

        /// <summary>
        /// Creates a blittable pointer
        /// </summary>
        /// <param name="pointer"></param>
        public BlittablePtr(T* pointer) => Pointer = pointer;

        /// <summary/>
        public static implicit operator BlittablePtr<T>(T* operand) => new BlittablePtr<T>(operand);
    }

    public unsafe struct BlittablePtrPtr<T> where T : unmanaged {
        /// <summary>
        /// The pointer to the value.
        /// </summary>
        public T** Pointer { get; set; }

        /// <summary>
        /// Creates a blittable pointer
        /// </summary>
        /// <param name="pointer"></param>
        public BlittablePtrPtr(T** pointer) => Pointer = pointer;

        /// <summary/>
        public static implicit operator BlittablePtrPtr<T>(T** operand) => new BlittablePtrPtr<T>(operand);
    }
}
