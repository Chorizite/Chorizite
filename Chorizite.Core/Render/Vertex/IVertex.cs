namespace Chorizite.Core.Render.Vertex {
    /// <summary>
    /// Interface for a vertex
    /// </summary>
    public interface IVertex {
        /// <summary>
        /// Vertex size
        /// </summary>
        public abstract static int Size { get; }

        /// <summary>
        /// Vertex format
        /// </summary>
        public abstract static VertexFormat Format { get; }
    }
}