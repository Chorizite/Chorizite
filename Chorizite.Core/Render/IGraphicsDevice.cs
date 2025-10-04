using Chorizite.Core.Render.Enums;
using Chorizite.Core.Render.Vertex;
using Chorizite.OpenGLSDLBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Represents a graphics device
    /// </summary>
    public interface IGraphicsDevice : IDisposable {
        /// <summary>
        /// The viewport area
        /// </summary>
        public Rectangle Viewport { get; set; }

        /// <summary>
        /// The scissor area
        /// </summary>
        public Rectangle Scissor { get; set; }

        /// <summary>
        /// The source blend factor.
        /// </summary>
        public BlendFactor SourceBlendFactor { get; set; }

        /// <summary>
        /// The destination blend factor.
        /// </summary>
        public BlendFactor DestBlendFactor { get; set; }

        /// <summary>
        /// The cull mode
        /// </summary>
        public CullMode CullMode { get; set; }

        /// <summary>
        /// The polygon mode
        /// </summary>
        public PolygonMode PolygonMode { get; set; }

        /// <summary>
        /// The current shader
        /// </summary>
        public IShader? Shader { get; set; }

        /// <summary>
        /// The native device pointer
        /// </summary>
        public IntPtr NativeDevice { get; }

        /// <summary>
        /// Callback for graphics reset
        /// </summary>
        public event EventHandler<EventArgs> OnGraphicsPreReset;

        /// <summary>
        /// Callback for graphics reset
        /// </summary>
        public event EventHandler<EventArgs> OnGraphicsPostReset;

        /// <summary>
        /// Initialize the device
        /// </summary>
        void Initialize();

        /// <summary>
        /// Clear the screen
        /// </summary>
        /// <param name="color">The color</param>
        /// <param name="flags">The clear flags</param>
        /// <param name="depth">The depth value</param>
        /// <param name="stencil">The stencil value</param>
        void Clear(ColorVec color, ClearFlags flags, float depth, int stencil);

        /// <summary>
        /// Create a vertex buffer
        /// </summary>
        /// <param name="size">The buffer size, in bytes</param>
        /// <param name="usage">The buffer usage</param>
        IVertexBuffer CreateVertexBuffer(int size, BufferUsage usage = BufferUsage.Static);

        /// <summary>
        /// Create an index buffer
        /// </summary>
        /// <param name="size">The buffer size, in bytes</param>
        /// <param name="usage">The buffer usage</param>
        IIndexBuffer CreateIndexBuffer(int size, BufferUsage usage = BufferUsage.Static);

        /// <summary>
        /// Create a vertex array
        /// </summary>
        /// <param name="vertexBuffer">The vertex buffer</param>
        /// <param name="format">The vertex format</param>
        IVertexArray CreateArrayBuffer(IVertexBuffer vertexBuffer, VertexFormat format);

        /// <summary>
        /// Create a shader
        /// </summary>
        /// <param name="name">The name of the shader</param>
        /// <param name="vertexCode">The vertex shader code, in text form</param>
        /// <param name="fragmentCode">The fragment shader code, in text form</param>
        IShader CreateShader(string name, string vertexCode, string fragmentCode);

        /// <summary>
        /// Creates a new shader instance using the specified name and source directory.
        /// It expects a vertex shader file named "{name}.vert" and a fragment shader file named "{name}.frag" to be present in the provided directory.
        /// </summary>
        /// <param name="name">The unique name to assign to the shader. This name is used to identify the shader within the application, and when resolving the shader file paths.</param>
        /// <param name="shaderDirectory">The path to the shader source files directory.</param>
        /// <returns>An <see cref="IShader"/> instance representing the created shader.</returns>
        IShader CreateShader(string name, string shaderDirectory);

        /// <summary>
        /// Set the active texture
        /// </summary>
        /// <param name="texture">The texture to set, or null to unbind</param>
        /// <param name="slot">The texture slot</param>
        void BindTexture(ITexture? texture, int slot = 0);

        /// <summary>
        /// Draw indexed elements from the currently bound vertex array / index buffer
        /// </summary>
        /// <param name="type">The primitive type</param>
        /// <param name="numElements">The number of elements to draw</param>
        /// <param name="indiceOffset">The index offset</param>
        void DrawElements(PrimitiveType type, int numElements, int indiceOffset = 0);

        /// <summary>
        /// Set a render state
        /// </summary>
        /// <param name="state"></param>
        /// <param name="enabled"></param>
        void SetRenderState(RenderState state, bool enabled);

        /// <summary>
        /// Get the current render state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        bool GetRenderState(RenderState state);

        /// <summary>
        /// Begin a frame
        /// </summary>
        void BeginFrame();

        /// <summary>
        /// Present the frame to the screen
        /// </summary>
        void EndFrame();

        /// <summary>
        /// Creates a framebuffer for rendering to a texture.
        /// </summary>
        /// <param name="texture">The texture to render to.</param>
        /// <param name="width">The width of the framebuffer.</param>
        /// <param name="height">The height of the framebuffer.</param>
        /// <param name="hasDepthStencil">Whether to include a depth-stencil attachment.</param>
        /// <returns>A framebuffer object.</returns>
        IFramebuffer CreateFramebuffer(ITexture texture, int width, int height, bool hasDepthStencil = false);

        /// <summary>
        /// Binds a framebuffer for rendering.
        /// </summary>
        /// <param name="framebuffer">The framebuffer to bind, or null to bind the default framebuffer.</param>
        void BindFramebuffer(IFramebuffer? framebuffer);

        /// <summary>
        /// Creates a new texture array with the specified format, dimensions, and number of layers.
        /// </summary>
        /// <param name="format">The pixel format to use for each texture in the array.</param>
        /// <param name="width">The width, in pixels, of each texture in the array. Must be greater than zero.</param>
        /// <param name="height">The height, in pixels, of each texture in the array. Must be greater than zero.</param>
        /// <param name="size">The number of textures (layers) in the array. Must be greater than zero.</param>
        /// <returns>An <see cref="ITextureArray"/> instance representing the created texture array.</returns>
        ITextureArray CreateTextureArray(TextureFormat format, int width, int height, int size);

        /// <summary>
        /// Retrieves the texture array associated with the specified native pointer.
        /// </summary>
        /// <param name="ptr">A native pointer that identifies the texture array to retrieve.</param>
        /// <returns>An object that implements <see cref="ITextureArray"/> if the pointer is valid; otherwise, <see
        /// langword="null"/>.</returns>
        ITextureArray? GetTextureArray(IntPtr ptr);

        /// <summary>
        /// Releases the resources associated with the specified texture array.
        /// </summary>
        /// <param name="textureArray">The texture array to release. Cannot be null.</param>
        void ReleaseTextureArray(ITextureArray textureArray);

        /// <summary>
        /// Create a texture from raw data
        /// </summary>
        /// <param name="format">The texture format</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="data">The texture data</param>
        /// <returns></returns>
        ITexture? CreateTexture(TextureFormat format, int width, int height, byte[] data);

        /// <summary>
        /// Load the specified texture file or dat resource uri
        /// </summary>
        /// <param name="format">The texture format to convert to after loading</param>
        /// <param name="filename">A filename or dat resource uri</param>
        /// <returns></returns>
        public ITexture? CreateTexture(TextureFormat format, string filename);

        /// <summary>
        /// Get a texture from a native pointer, returns null if not found
        /// </summary>
        /// <param name="ptr">A pointer to a native texture</param>
        /// <returns></returns>
        ITexture? GetTexture(IntPtr ptr);

        /// <summary>
        /// Release a texture, disposing of it
        /// </summary>
        /// <param name="texture"></param>
        void ReleaseTexture(ITexture texture);
        IUniformBuffer CreateUniformBuffer(BufferUsage usage, int size);
    }
}
