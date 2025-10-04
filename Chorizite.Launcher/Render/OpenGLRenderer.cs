using Chorizite.Core.Dats;
using Chorizite.Core.Render;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using System.Numerics;
using System.Text.RegularExpressions;
using WaveEngine.Bindings.OpenGL;
using static SDL2.SDL;
using System.Reflection;
using Chorizite.Common;
using LauncherApp.Lib;
using System.Runtime.InteropServices;
using SDL2;
using Chorizite.Core.Render.Enums;
using Chorizite.Core.Render.Vertex;

namespace LauncherApp.Render {
    unsafe public class OpenGLRenderer : IRenderer {
        private static Regex _datFileRegex = new Regex(@"^dat:\/\/");
        private Dictionary<nint, GeometryBufferRef> _geometryBuffers = new();
        private List<ManagedGLTexture> _textures = new();
        internal SDL_DisplayMode CurrentDisplayMode;
        private nint SDLWindowHandle;

        public nint HWND { get; private set; }

        private nint SDLGLContext;
        private int _nextGeometryId = 1;
        private readonly ILogger _log;

        private struct GeometryBufferRef : IDisposable {
            public readonly uint VAO;
            public readonly uint VBO;
            public readonly uint IBO;
            public readonly VertexPositionColorTexture[] Verts;
            public readonly int[] Indices;

            public GeometryBufferRef(uint vao, uint vbo, uint ebo, VertexPositionColorTexture[] verts, int[] inds) {
                VAO = vao;
                VBO = vbo;
                Verts = verts;
                Indices = inds;
            }

            public void Dispose() {
                fixed (uint* _VAOPtr = &VAO) {
                    GL.glDeleteVertexArrays(1, _VAOPtr);
                }
                fixed (uint* _VBOPtr = &VBO) {
                    GL.glDeleteBuffers(1, _VBOPtr);
                }
                fixed (uint* _IBOPtr = &IBO) {
                    GL.glDeleteBuffers(1, _IBOPtr);
                }
            }
        }

        public int Width { get; protected set; } = 800;
        public int Height { get; protected set; } = 600;
        public bool HasFocus => Native.GetForegroundWindow() == HWND;
        public List<string> Extensions { get; } = [];
        public Vector2 ViewportSize => new(Width, Height);

        public GLSLShader ColorShader { get; }
        public GLSLShader TextureShader { get; }

        public IntPtr NativeDevice => IntPtr.Zero;
        public IntPtr NativeHwnd => IntPtr.Zero;

        public IGraphicsDevice GraphicsDevice => throw new NotImplementedException();

        public IDrawList DrawList => throw new NotImplementedException();

        public IShader UIShader => throw new NotImplementedException();

        public IShader TextShader => throw new NotImplementedException();

        public IFontManager FontManager => throw new NotImplementedException();

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? OnRender2D {
            add { _OnRender2D.Subscribe(value); }
            remove { _OnRender2D.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnRender2D = new();

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? OnGraphicsPreReset {
            add { _OnGraphicsPreReset.Subscribe(value); }
            remove { _OnGraphicsPreReset.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnGraphicsPreReset = new();

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? OnGraphicsPostReset {
            add { _OnGraphicsPostReset.Subscribe(value); }
            remove { _OnGraphicsPostReset.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnGraphicsPostReset = new();

        public OpenGLRenderer(ILogger<OpenGLRenderer> log) {
            _log = log;
            SetupSDL();
            SetupOpenGL();

            var shaderDir = Path.GetFullPath($"./../../Launcher/Launcher/Render/Shaders");

            ColorShader = new GLSLShader("VertexPositionColor", GetEmbeddedResource("Render.Shaders.VertexPositionColor.vert"), GetEmbeddedResource("Render.Shaders.VertexPositionColor.frag"),  _log, shaderDir);
            TextureShader = new GLSLShader("VertexPositionColorTexture", GetEmbeddedResource("Render.Shaders.VertexPositionColorTexture.vert"), GetEmbeddedResource("Render.Shaders.VertexPositionColorTexture.frag"), _log, shaderDir);

            SetWindowIcon();
        }

        private void SetWindowIcon() {
            _icon = LoadPngToSdlSurface(Path.Combine(Program.AssemblyDirectory, "icon.png"));

            SDL_SetWindowIcon(SDLWindowHandle, (nint)_icon);
        }

        private string GetEmbeddedResource(string filename) {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Chorizite.Launcher." + filename;

            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream is null) throw new Exception($"Resource not found: {resourceName}");
            using var reader = new StreamReader(stream);
            string result = reader.ReadToEnd();
            return result;
        }

        #region graphics / input setup
        unsafe private void SetupOpenGL() {
            GL.LoadAllFunctions(SDL_GL_GetProcAddress);
        }

        private void SetupSDL() {
            if (SDL_Init(SDL_INIT_EVENTS | SDL_INIT_VIDEO | SDL_INIT_TIMER) < 0) {
                _log.LogError($"SDL_Init failed: {SDL_GetError()}");
            }

            SDL_SetHint(SDL_HINT_MOUSE_FOCUS_CLICKTHROUGH, "1");
            SDL_SetHint(SDL_HINT_RENDER_DRIVER, "opengl");
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_DEPTH_SIZE, 24);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_STENCIL_SIZE, 8);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_DOUBLEBUFFER, 1);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_CONTEXT_PROFILE_MASK, SDL_GLprofile.SDL_GL_CONTEXT_PROFILE_CORE);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_CONTEXT_MAJOR_VERSION, 3);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_CONTEXT_MINOR_VERSION, 3);
            SDL_GetCurrentDisplayMode(0, out CurrentDisplayMode);

            var windowFlags = SDL_WindowFlags.SDL_WINDOW_SHOWN | SDL_WindowFlags.SDL_WINDOW_OPENGL/* | SDL_WindowFlags.SDL_WINDOW_BORDERLESS*/;
            SDLWindowHandle = SDL_CreateWindow("Chorizite", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, Width, Height, windowFlags);
            if (SDLWindowHandle == nint.Zero) {
                _log.LogError($"Failed to create window: {SDL_GetError()}");
                return;
            }

            SDL_SysWMinfo wmInfo = new();
            SDL_VERSION(out var version);
            SDL_GetWindowWMInfo(SDLWindowHandle, ref wmInfo);
            //Native.MakeWindowTransparent(wmInfo.info.win.window);

            HWND = wmInfo.info.win.window;

            SDLGLContext = SDL_GL_CreateContext(SDLWindowHandle);
            if (SDLGLContext == nint.Zero) {
                _log.LogError($"Failed to create gl context: {SDL_GetError()}");
                return;
            }
        }
        #endregion // graphics / input setup

        internal unsafe string CheckErrors() {
            var error = GL.glGetError();
            if (error != ErrorCode.NoError) {
                _log.LogError($"OpenGL Error: {error}");
            }

            return error.ToString();
        }

        public void Resize(int width, int height) {
            if (width > 0 && height > 0) {
                if (Width != width) {
                    Width = width;
                }
                if (Height != height) {
                    Height = height;
                }
            }
        }

        public void Update() {
            SDL_SetWindowSize(SDLWindowHandle, Width, Height);
            GL.glViewport(0, 0, Width, Height);
        }

        public void Render() {
            SDL_GL_MakeCurrent(SDLWindowHandle, SDLGLContext);

            GL.glBindFramebuffer(FramebufferTarget.Framebuffer, 0);

            GL.glClearColor(0f, 0f, 0f, 0f);
            GL.glClear((uint)(AttribMask.ColorBufferBit | AttribMask.DepthBufferBit | AttribMask.StencilBufferBit));

            GL.glEnable(EnableCap.Blend);
            GL.glDisable(EnableCap.ScissorTest);
            GL.glDisable(EnableCap.CullFace);
            //GL.glBlendEquation(BlendEquationModeEXT.FuncAdd);
            GL.glBlendFunc(BlendingFactor.One, BlendingFactor.OneMinusSrcAlpha);
            //GL.glBlendFuncSeparate(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha, BlendingFactor.One, (BlendingFactor)0);
            GL.glEnable(EnableCap.StencilTest);
            GL.glStencilFunc(StencilFunction.Always, 1, 0xFFFFFFFF);
            GL.glStencilMask(0xFFFFFFFF);
            GL.glStencilOp(StencilOp.Keep, StencilOp.Keep, StencilOp.Keep);
            GL.glDisable(EnableCap.DepthTest);
            GL.glEnable(EnableCap.Multisample);

            ColorShader.SetUniform("xProjection", Matrix4x4.CreateOrthographicOffCenter(0, Width, Height, 0, -10000, 10000));
            TextureShader.SetUniform("xProjection", Matrix4x4.CreateOrthographicOffCenter(0, Width, Height, 0, -10000, 10000));

            _OnRender2D?.Invoke(this, EventArgs.Empty);

            SDL_GL_SwapWindow(SDLWindowHandle);

            _x = true;
        }

        public unsafe IntPtr CompileGeometry(IEnumerable<VertexPositionColorTexture> vertices, IEnumerable<int> indices) {
            //_log?.LogTrace($"CompileGeometry: verts: {vertices.Count()} inds: {indices.Count()}");

            var verts = vertices.ToArray();
            var vSize = VertexPositionColorTexture.Size;

            uint VBO, VAO, IBO;
            GL.glGenVertexArrays(1, &VAO);
            GL.glGenBuffers(1, &VBO);
            GL.glGenBuffers(1, &IBO);
            GL.glBindVertexArray(VAO);

            GL.glBindBuffer(BufferTargetARB.ArrayBuffer, VBO);
            fixed (void* vertsPtr = &verts[0]) {
                GL.glBufferData(BufferTargetARB.ArrayBuffer, vSize * verts.Length, vertsPtr, BufferUsageARB.StaticDraw);
            }

            // Position
            GL.glEnableVertexAttribArray(0);
            GL.glVertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, vSize, (void*)0);

            // Color
            GL.glEnableVertexAttribArray(1);
            GL.glVertexAttribPointer(1, 4, VertexAttribPointerType.Float, false, vSize, (void*)12);

            // Texture Coordinate
            GL.glEnableVertexAttribArray(2);
            GL.glVertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, vSize, (void*)28);

            // Bind and set index buffer data
            var indicesArray = indices.ToArray();
            GL.glBindBuffer(BufferTargetARB.ElementArrayBuffer, IBO);
            fixed (int* indicesPtr = &indicesArray[0]) {
                GL.glBufferData(BufferTargetARB.ElementArrayBuffer, indicesArray.Length * sizeof(uint), indicesPtr, BufferUsageARB.StaticDraw);
            }

            GL.glBindVertexArray(0);
            GL.glBindBuffer(BufferTargetARB.ArrayBuffer, 0);
            GL.glBindBuffer(BufferTargetARB.ElementArrayBuffer, 0);

            var id = _nextGeometryId++;
            var geometry = new GeometryBufferRef(VAO, VBO, IBO, verts, indicesArray);
            _geometryBuffers.Add(id, geometry);

            return new IntPtr(id);
        }

        private bool _x = false;
        private Matrix4x4 _transform = Matrix4x4.Identity;
        private SDL_Surface* _icon;

        public event EventHandler<EventArgs> OnBeforeRender3D;
        public event EventHandler<EventArgs> OnRender3D;
        public event EventHandler<EventArgs> OnAfterRender3D;
        public event EventHandler<EventArgs> OnBeforeRenderUI;
        public event EventHandler<EventArgs> OnRenderUI;
        public event EventHandler<EventArgs> OnAfterRenderUI;

        public void RenderGeometry(IntPtr geometry, Matrix4x4 translation, ITexture? texture) {
            var geom = _geometryBuffers[geometry];

            if (texture is ManagedGLTexture dxTexture && dxTexture is not null) {
                if (!_x) {
                    return;
                }
                GL.glBindTexture(TextureTarget.Texture2d, (uint)dxTexture.TexturePtr);
                TextureShader.SetActive();
                TextureShader.SetUniform("xWorld", translation * _transform);
            }
            else {
                ColorShader.SetActive();
                ColorShader.SetUniform("xWorld", translation * _transform);
                GL.glBindTexture(TextureTarget.Texture2d, 0);
            }

            GL.glBindVertexArray(geom.VAO);
            //GL.glDrawElements(PrimitiveType.Triangles, geom.Indices.Length, DrawElementsType.UnsignedInt, (void*)0);

            GL.glBindTexture(TextureTarget.Texture2d, 0);
            GL.glBindVertexArray(0);
        }

        public void ReleaseGeometry(IntPtr geometry) {
            //_log?.LogTrace($"ReleaseGeometry: 0x{geometry:X8}");
            if (_geometryBuffers.TryGetValue(geometry, out var geom)) {
                _geometryBuffers.Remove(geometry);
                geom.Dispose();
            }
        }

        public ITexture GenerateTexture(byte[] source, Vector2 dimensions) {
            //_log?.LogTrace($"Generate texture: {dimensions.X}x{dimensions.Y}");
            var dx = (int)dimensions.X;
            var dy = (int)dimensions.Y;

            //var texture = new ManagedGLTexture(source, dx, dy);
            //_textures.Add(texture);
            //return texture;
            return null;
        }

        public ITexture? LoadTexture(string source, out Vector2 textureDimensions) {
            try {
                //_log?.LogTrace($"LoadTexture: {source}");
                ManagedGLTexture texture = null;// new ManagedGLTexture(source);

                if (texture.TexturePtr == IntPtr.Zero) {
                    _log?.LogError($"Failed to load texture: {source}");
                    textureDimensions = Vector2.Zero;
                    return default;
                }

                _log?.LogTrace($"Loaded texture: 0x{texture.TexturePtr:X8} {source}");

                textureDimensions = new Vector2(texture.Width, texture.Height);
                _textures.Add(texture);
                return texture;
            }
            catch (Exception ex) {
                _log?.LogError($"Error loading texture ({source}): {ex}");
                textureDimensions = System.Numerics.Vector2.Zero;
                return default;
            }
        }

        public void ReleaseTexture(ITexture textureHandle) {
            //_log?.LogTrace($"Disping texture: 0x{textureHandle.TexturePtr:X8}");
            textureHandle.Dispose();
            _textures.Remove((ManagedGLTexture)textureHandle);
        }

        public void EnableScissorRegion(bool enable) {
            if (enable) {
                GL.glEnable(EnableCap.ScissorTest);
            }
            else {
                GL.glDisable(EnableCap.ScissorTest);
            }
        }

        public void SetScissorRegion(int left, int top, int right, int bottom) {
            GL.glScissor(left, (int)ViewportSize.Y - top - (bottom - top), right - left, (bottom - top));
        }

        public void SetTransform(Matrix4x4 transform) {
            _transform = transform;
        }

        public static unsafe SDL.SDL_Surface* LoadPngToSdlSurface(string filePath) {
            // Load the image using ImageSharp
            using var image = Image.Load<Rgba32>(filePath);

            // Create a byte array to hold the pixel data
            byte[] pixels = new byte[image.Width * image.Height * 4];

            // Copy pixel data to the byte array
            fixed (void* ptr = &pixels[0]) {
                // Create SDL surface
                var surface = (SDL.SDL_Surface*)SDL.SDL_CreateRGBSurface(
                    0,
                    image.Width,
                    image.Height,
                    32,
                    0x000000FF,  // R mask
                    0x0000FF00,  // G mask
                    0x00FF0000,  // B mask
                    0xFF000000   // A mask
                );

                if (surface == null) {
                    throw new Exception($"Failed to create SDL surface: {SDL.SDL_GetError()}");
                }

                // Lock the surface for pixel access
                SDL.SDL_LockSurface((nint)surface);

                try {
                    // Copy pixels from ImageSharp to SDL surface
                    for (int y = 0; y < image.Height; y++) {
                        for (int x = 0; x < image.Width; x++) {
                            Rgba32 pixel = image[x, y];
                            int offset = (y * image.Width + x) * 4;

                            pixels[offset + 0] = pixel.R;     // Red
                            pixels[offset + 1] = pixel.G;     // Green
                            pixels[offset + 2] = pixel.B;     // Blue
                            pixels[offset + 3] = pixel.A;     // Alpha
                        }
                    }

                    // Copy the pixel array to the SDL surface
                    System.Buffer.MemoryCopy(
                        ptr,
                        (void*)surface->pixels,
                        surface->pitch * surface->h,
                        pixels.Length
                    );
                }
                finally {
                    SDL.SDL_UnlockSurface((nint)surface);
                }

                return surface;
            }
        }

        public void Dispose() {
            SDL_FreeSurface((nint)_icon);
            foreach (var texture in _textures) {
                texture.Dispose();
            }
            _textures.Clear();
        }

        public ScopedDeviceState CreateScopedState() {
            throw new NotImplementedException();
        }

        public RenderTarget CreateRenderTarget(int width, int height) {
            throw new NotImplementedException();
        }

        public void BindRenderTarget(RenderTarget? renderTarget) {
            throw new NotImplementedException();
        }

        public void SetCursor(uint cursorDataId, Vector2 hotspot) {
            throw new NotImplementedException();
        }
    }
}
