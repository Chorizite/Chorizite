namespace Chorizite.OpenGLSDLBackend {
    public interface IUniformBuffer {
        void Bind(uint bindingPoint);
        void Dispose();
        void SetData<T>(T[] data) where T : unmanaged;
        void SetData<T>(System.Span<T> data) where T : unmanaged;
        void SetSubData<T>(System.Span<T> data, int destinationOffsetBytes, int sourceOffsetElements = 0, int lengthElements = 0) where T : unmanaged;
        void Unbind();
    }
}