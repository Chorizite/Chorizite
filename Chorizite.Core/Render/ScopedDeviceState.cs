using Chorizite.Core.Render.Enums;
using System;
using System.Collections.Generic;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Temporarily overrides the current device state and restores it when disposed.
    /// Use with a 'using' block to ensure cleanup.
    /// </summary>
    public class ScopedDeviceState : IDisposable {
        /// <summary>
        /// The graphics device
        /// </summary>
        protected readonly IGraphicsDevice _device;

        /// <summary>
        /// The new viewport, if overridden
        /// </summary>
        protected Rectangle? _viewport;

        /// <summary>
        /// The new scissor region, if overridden
        /// </summary>
        protected Rectangle? _scissor;

        /// <summary>
        /// The new blend factors, if overridden
        /// </summary>
        protected BlendFactor? _srcBlendFactor;

        /// <summary>
        /// The new blend factors, if overridden
        /// </summary>
        protected BlendFactor? _dstBlendFactor;

        /// <summary>
        /// The new cull mode, if overridden
        /// </summary>
        protected CullMode? _cullMode;

        /// <summary>
        /// The new polygon mode, if overridden
        /// </summary>
        protected PolygonMode? _polygonMode;

        /// <summary>
        /// The original shader, only populated if overridden
        /// </summary>
        protected IShader? _originalShader;

        /// <summary>
        /// The original textures, only populated if overridden
        /// </summary>
        protected Dictionary<int, ITexture> _originalTextures = new();

        /// <summary>
        /// The original viewport, only populated if overridden
        /// </summary>
        protected Rectangle? _originalViewport;

        /// <summary>
        /// The original scissor region, only populated if overridden
        /// </summary>
        protected Rectangle? _originalScissor;

        /// <summary>
        /// The original blend factors, only populated if overridden
        /// </summary>
        protected BlendFactor? _originalSrcBlendFactor;

        /// <summary>
        /// The original blend factors, only populated if overridden
        /// </summary>
        protected BlendFactor? _originalDstBlendFactor;

        /// <summary>
        /// The original cull mode, only populated if overridden
        /// </summary>
        protected CullMode? _originalCullMode;

        /// <summary>
        /// The original polygon mode, only populated if overridden
        /// </summary>
        protected PolygonMode? _originalPolygonMode;

        /// <summary>
        /// The original render states, only populated if overridden
        /// </summary>
        protected readonly Dictionary<RenderState, bool> _originalRenderState = new();

        /// <summary>
        /// The viewport area
        /// </summary>
        public virtual Rectangle Viewport {
            get => _viewport.HasValue ? _viewport.Value : _device.Viewport;
            set {
                _originalViewport ??= _device.Viewport;
                _viewport = _device.Viewport = value;
            }
        }

        /// <summary>
        /// The scissor area
        /// </summary>
        public virtual Rectangle Scissor {
            get => _scissor.HasValue ? _scissor.Value : _device.Scissor;
            set {
                _originalScissor ??= _device.Scissor;
                _scissor = _device.Scissor = value;
            }
        }

        /// <summary>
        /// The source blend factor
        /// </summary>
        public virtual BlendFactor SourceBlendFactor {
            get => _srcBlendFactor.HasValue ? _srcBlendFactor.Value : _device.SourceBlendFactor;
            set {
                _originalSrcBlendFactor ??= _device.SourceBlendFactor;
                _srcBlendFactor = _device.SourceBlendFactor = value;
            }
        }

        /// <summary>
        /// The destination blend factor
        /// </summary>
        public virtual BlendFactor DestBlendFactor {
            get => _dstBlendFactor.HasValue ? _dstBlendFactor.Value : _device.DestBlendFactor;
            set {
                _originalDstBlendFactor ??= _device.DestBlendFactor;
                _dstBlendFactor = _device.DestBlendFactor = value;
            }
        }

        /// <summary>
        /// The cull mode
        /// </summary>
        public virtual CullMode CullMode {
            get => _cullMode.HasValue ? _cullMode.Value : _device.CullMode;
            set {
                _originalCullMode ??= _device.CullMode;
                _cullMode = _device.CullMode = value;
            }
        }

        /// <summary>
        /// The polygon mode
        /// </summary>
        public virtual PolygonMode PolygonMode {
            get => _polygonMode.HasValue ? _polygonMode.Value : _device.PolygonMode;
            set {
                _originalPolygonMode ??= _device.PolygonMode;
                _polygonMode = _device.PolygonMode = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScopedDeviceState"/> class.
        /// </summary>
        /// <param name="device"></param>
        public ScopedDeviceState(IGraphicsDevice device) {
            _device = device;
        }

        /// <summary>
        /// Set a render state, then restore it when disposed
        /// </summary>
        /// <param name="state"></param>
        /// <param name="enabled"></param>
        public virtual void SetRenderState(RenderState state, bool enabled) {
            _originalRenderState.TryAdd(state, _device.GetRenderState(state));
            _device.SetRenderState(state, enabled);
        }

        /// <summary>
        /// Bind a shader, then restore it when disposed
        /// </summary>
        /// <param name="shader"></param>
        public virtual void BindShader(IShader shader) {
            _originalShader = _device.Shader;
            _device.Shader = shader;
        }

        /// <summary>
        /// Bind a texture, then restore it when disposed
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="slot"></param>
        public virtual void BindTexture(ITexture texture, int slot) {
            _device.BindTexture(texture, slot);
        }

        /// <summary>
        /// Restores the previous render state.
        /// </summary>
        public virtual void Dispose() {
            if (_originalViewport.HasValue) {
                _device.Viewport = _originalViewport.Value;
            }
            if (_originalScissor.HasValue) _device.Scissor = _originalScissor.Value;
            if (_originalSrcBlendFactor.HasValue) _device.SourceBlendFactor = _originalSrcBlendFactor.Value;
            if (_originalDstBlendFactor.HasValue) _device.DestBlendFactor = _originalDstBlendFactor.Value;

            foreach (var state in _originalRenderState) {
                _device.SetRenderState(state.Key, state.Value);
            }
        }
    }
}