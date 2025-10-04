using Chorizite.Common;
using Chorizite.Core.Render.Enums;
using Chorizite.Core.Render.Vertex;
using Chorizite.OpenGLSDLBackend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render {
    /// <summary>  
    /// A base graphics device  
    /// </summary>  
    public abstract class BaseGraphicsDevice : IGraphicsDevice {
        /// <summary>
        /// The current viewport
        /// </summary>
        protected Rectangle _viewport;

        /// <summary>
        /// The current scissor region
        /// </summary>
        protected Rectangle _scissor;

        /// <summary>
        /// The current blend factors
        /// </summary>
        protected BlendFactor _srcBlendFactor = BlendFactor.One;

        /// <summary>
        /// The current blend factors
        /// </summary>
        protected BlendFactor _dstBlendFactor = BlendFactor.OneMinusSrcAlpha;

        /// <summary>
        /// The current cull mode
        /// </summary>
        protected CullMode _cullMode = CullMode.None;

        /// <summary>
        /// The current polygon mode
        /// </summary>
        protected PolygonMode _polygonMode = PolygonMode.Fill;

        /// <summary>
        /// The current render states
        /// </summary>
        protected Dictionary<RenderState, bool> _renderStates = new();

        /// <summary>
        /// The current shader
        /// </summary>
        protected IShader? _currentShader;

        /// <summary>
        /// The current textures, key is bound slot
        /// </summary>
        protected Dictionary<int, ITexture?> _boundTextures = new();

        protected Dictionary<IntPtr, ITexture> _managedTextures = new();
        protected Dictionary<IntPtr, ITextureArray> _managedTextureArrays = new();

        /// <inheritdoc/>  
        public Rectangle Viewport {
            get => _viewport;
            set {
                if (!_viewport.Equals(value)) {
                    _viewport = value;
                    SetViewportInternal(_viewport);
                }
            }
        }

        /// <inheritdoc/>  
        public IShader? Shader {
            get => _currentShader;
            set {
                _currentShader?.Unbind();
                value?.Bind();
                _currentShader = value;
            }
        }


        /// <inheritdoc/>  
        public Rectangle Scissor {
            get => _scissor;
            set {
                if (!_scissor.Equals(value)) {
                    _scissor = value;
                    SetScissorRectInternal(_scissor);
                }
            }
        }

        /// <inheritdoc/>  
        public BlendFactor SourceBlendFactor {
            get => _srcBlendFactor;
            set {
               if (!_srcBlendFactor.Equals(value)) {
                    _srcBlendFactor = value;
                    SetBlendFactorInternal(_srcBlendFactor, _dstBlendFactor);
                }
            }
        }

        /// <inheritdoc/>  
        public BlendFactor DestBlendFactor {
            get => _dstBlendFactor;
            set {
                if (!_dstBlendFactor.Equals(value)) {
                    _dstBlendFactor = value;
                    SetBlendFactorInternal(_srcBlendFactor, _dstBlendFactor);
                }
            }
        }

        /// <inheritdoc/>  
        public CullMode CullMode {
            get => _cullMode;
            set {
                if (!_cullMode.Equals(value)) {
                    _cullMode = value;
                    SetCullModeInternal(_cullMode);
                }
            }
        }

        /// <inheritdoc/>  
        public PolygonMode PolygonMode {
            get => _polygonMode;
            set {
                if (!_polygonMode.Equals(value)) {
                    _polygonMode = value;
                    SetPolygonModeInternal(_polygonMode);
                }
            }
        }

        /// <inheritdoc/>  
        public abstract nint NativeDevice { get; }

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? OnGraphicsPreReset {
            add { _OnGraphicsPreReset.Subscribe(value); }
            remove { _OnGraphicsPreReset.Unsubscribe(value); }
        }

        /// <summary>
        /// Pre reset event invoker
        /// </summary>
        protected readonly WeakEvent<EventArgs> _OnGraphicsPreReset = new();

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? OnGraphicsPostReset {
            add { _OnGraphicsPostReset.Subscribe(value); }
            remove { _OnGraphicsPostReset.Unsubscribe(value); }
        }

        /// <summary>
        /// Post reset event invoker
        /// </summary>
        protected readonly WeakEvent<EventArgs> _OnGraphicsPostReset = new();

        /// <inheritdoc/>  
        public virtual bool GetRenderState(RenderState state) {
            if (_renderStates.TryGetValue(state, out bool enabled)) return enabled;
            return false;
        }

        /// <inheritdoc/>  
        public virtual void Initialize() {
            CullMode = CullMode.Back;
            PolygonMode = PolygonMode.Fill;
            SetRenderState(RenderState.AlphaBlend, true);
            SetRenderState(RenderState.DepthTest, false);
            SetRenderState(RenderState.DepthWrite, false);
            SetRenderState(RenderState.Fog, false);
            SetRenderState(RenderState.Lighting, false);
            SetRenderState(RenderState.ScissorTest, false);
        }


        /// <inheritdoc/>  
        public virtual void BindTexture(ITexture? texture, int slot = 0) {
            if (_boundTextures.TryGetValue(slot, out var tex)) {
                if (tex != texture) {
                    tex?.Unbind();
                    _boundTextures[slot] = texture;
                }
            }
            else {
                _boundTextures.Add(slot, texture);
            }

            texture?.Bind(slot);
        }

        /// <inheritdoc/>  
        public virtual void SetRenderState(RenderState state, bool enabled) {
            if (!_renderStates.TryAdd(state, enabled)) {
                if (_renderStates[state] == enabled) return;
                _renderStates[state] = enabled;
            }
            SetRenderStateInternal(state, enabled);
        }

        /// <summary>
        /// Set the scissor rect
        /// </summary>
        /// <param name="scissor"></param>
        protected abstract void SetScissorRectInternal(Rectangle scissor);

        /// <summary>
        /// Set the viewport
        /// </summary>
        /// <param name="viewport"></param>
        protected abstract void SetViewportInternal(Rectangle viewport);

        /// <summary>
        /// Set the blend factor
        /// </summary>
        /// <param name="srcBlendFactor"></param>
        /// <param name="dstBlendFactor"></param>
        protected abstract void SetBlendFactorInternal(BlendFactor srcBlendFactor, BlendFactor dstBlendFactor);

        /// <inheritdoc cref="SetRenderState(RenderState, bool)"/>
        protected abstract void SetRenderStateInternal(RenderState state, bool enabled);

        /// <summary>
        /// Set the polygon mode
        /// </summary>
        /// <param name="polygonMode"></param>
        protected abstract void SetPolygonModeInternal(PolygonMode polygonMode);

        /// <summary>
        /// Set the cull mode
        /// </summary>
        /// <param name="cullMode"></param>
        protected abstract void SetCullModeInternal(CullMode cullMode);

        /// <inheritdoc/>
        public abstract void Clear(ColorVec color, ClearFlags flags, float depth, int stencil);

        /// <inheritdoc/>
        public abstract IShader CreateShader(string name, string vertexCode, string fragmentCode);

        /// <inheritdoc/>
        public abstract IShader CreateShader(string name, string shaderDirectory);

        /// <inheritdoc/>
        public virtual ITextureArray? CreateTextureArray(TextureFormat format, int width, int height, int size) {
            var textureArray = CreateTextureArrayInternal(format, width, height, size);
            _managedTextureArrays.Remove(textureArray.NativePtr);
            _managedTextureArrays.TryAdd(textureArray.NativePtr, textureArray);
            return textureArray;
        }

        /// <inheritdoc/>
        public abstract ITextureArray CreateTextureArrayInternal(TextureFormat format, int width, int height, int size);

        /// <inheritdoc/>
        public virtual ITextureArray? GetTextureArray(IntPtr ptr) {
            if (_managedTextureArrays.TryGetValue(ptr, out var textureArray)) {
                return textureArray;
            }
            return null;
        }

        /// <inheritdoc/>
        public virtual void ReleaseTextureArray(ITextureArray textureArray) {
            if (textureArray is not null) {
                textureArray.Dispose();
                _managedTextureArrays.Remove(textureArray.NativePtr);
            }
        }

        /// <inheritdoc/>
        public virtual ITexture? GetTexture(IntPtr ptr) {
            if (_managedTextures.TryGetValue(ptr, out var texture)) {
                return texture;
            }
            return null;
        }

        /// <inheritdoc/>
        public virtual ITexture CreateTexture(TextureFormat format, int width, int height, byte[]? data) {
            var texture = CreateTextureInternal(format, width, height, data);
            _managedTextures.Remove(texture.NativePtr);
            _managedTextures.TryAdd(texture.NativePtr, texture);
            return texture;
        }

        /// <inheritdoc/>
        public virtual ITexture? CreateTexture(TextureFormat format, string filename) {
            var texture = CreateTextureInternal(format, filename);
            if (texture == null) return null;
            _managedTextures.Remove(texture.NativePtr);
            _managedTextures.TryAdd(texture.NativePtr, texture);
            return texture;
        }

        /// <inheritdoc/>
        public virtual void ReleaseTexture(ITexture texture) {
            if (texture is not null) {
                texture.Dispose();
                _managedTextures.Remove(texture.NativePtr);
            }
        }

        /// <inheritdoc/>
        public abstract ITexture CreateTextureInternal(TextureFormat format, int width, int height, byte[]? data);

        /// <inheritdoc/>
        public abstract ITexture? CreateTextureInternal(TextureFormat format, string filename);

        /// <inheritdoc/>
        public abstract IVertexBuffer CreateVertexBuffer(int size, BufferUsage usage = BufferUsage.Static);

        /// <inheritdoc/>
        public abstract IIndexBuffer CreateIndexBuffer(int size, BufferUsage usage = BufferUsage.Static);

        /// <inheritdoc/>
        public abstract IVertexArray CreateArrayBuffer(IVertexBuffer vertexBuffer, VertexFormat format);

        /// <inheritdoc/>
        public abstract IUniformBuffer CreateUniformBuffer(BufferUsage usage, int size);

        /// <inheritdoc/>
        public abstract void DrawElements(PrimitiveType type, int numElements, int indiceOffset = 0);

        /// <inheritdoc/>
        public abstract void BeginFrame();

        /// <inheritdoc/>
        public abstract void EndFrame();

        /// <inheritdoc/>
        public abstract IFramebuffer CreateFramebuffer(ITexture texture, int width, int height, bool hasDepthStencil = false);

        /// <inheritdoc/>
        public abstract void BindFramebuffer(IFramebuffer? framebuffer);

        /// <inheritdoc/>  
        public virtual void Dispose() {
            foreach (var texture in _managedTextures.Values) {
                texture.Dispose();
            }
            _managedTextures.Clear();
        }
    }
}
