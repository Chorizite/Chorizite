using System;
using System.Numerics;
using static RmlUiNet.Native.RenderInterface;

namespace RmlUiNet
{
    public unsafe class RenderInterface : RmlBase<RenderInterface>
    {
        private Native.RenderInterface.OnCompileGeometry _onCompileGeometry;
        private Native.RenderInterface.OnRenderGeometry _onRenderGeometry;
        private Native.RenderInterface.OnReleaseGeometry _onReleaseGeometry;
        private Native.RenderInterface.OnLoadTexture _onLoadTexture;
        private Native.RenderInterface.OnGenerateTexture _onGenerateTexture;
        private Native.RenderInterface.OnReleaseTexture _onReleaseTexture;
        private Native.RenderInterface.OnEnableScissorRegion _onEnableScissorRegion;
        private Native.RenderInterface.OnSetScissorRegion _onSetScissorRegion;
        private Native.RenderInterface.OnSetTransform _onSetTransform;

        internal static RenderInterface? Create(IntPtr nativePtr) {
            return GetOrCreateCache(nativePtr, ptr => new RenderInterface(ptr));
        }

        internal RenderInterface(IntPtr nativePtr) : base(nativePtr) {
        
        }

        public RenderInterface() : base(IntPtr.Zero)
        {
            _onCompileGeometry = CompileGeometry;
            _onRenderGeometry = RenderGeometry;
            _onReleaseGeometry = ReleaseGeometry;
            _onLoadTexture = LoadTexture;
            _onGenerateTexture = GenerateTexture;
            _onReleaseTexture = ReleaseTexture;
            _onEnableScissorRegion = EnableScissorRegion;
            _onSetScissorRegion = SetScissorRegion;
            _onSetTransform = SetTransform;

            NativePtr = Native.RenderInterface.Create(
                _onCompileGeometry,
                _onRenderGeometry,
                _onReleaseGeometry,
                _onLoadTexture,
                _onGenerateTexture,
                _onReleaseTexture,
                _onEnableScissorRegion,
                _onSetScissorRegion,
                _onSetTransform
            );

            ManuallyRegisterCache(NativePtr, this);
        }

        public virtual IntPtr CompileGeometry(Vertex* vertices, int vertexCount, int* indices, int indexCount) {
            return IntPtr.Zero;
        }

        public virtual void RenderGeometry(IntPtr geometry, Vector2f translation, IntPtr texture)
        {

        }

        public virtual void ReleaseGeometry(IntPtr geometry) {

        }

        public virtual IntPtr LoadTexture(ref Vector2i textureDimensions, string source)
        {
            textureDimensions = new Vector2i(69, 69);
            return IntPtr.Zero;
        }

        public virtual IntPtr GenerateTexture(byte* source, int numBytes, Vector2i dimensions)
        {
            return IntPtr.Zero;
        }

        public virtual void ReleaseTexture(IntPtr textureHandle)
        {

        }

        public virtual void EnableScissorRegion(bool enable)
        {

        }

        public virtual void SetScissorRegion(int x, int y, int width, int height)
        {

        }

        public virtual void SetTransform(IntPtr transform)
        {

        }

        public virtual void Test() {
            Native.RenderInterface.Test(NativePtr);
        }
    }
}
