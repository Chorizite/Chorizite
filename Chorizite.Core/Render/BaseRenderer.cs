using Chorizite.Common;
using Chorizite.Core.Render.Enums;
using FontStashSharp.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Chorizite.Core.Render {
    /// <summary>
    /// A base renderer
    /// </summary>
    public abstract class BaseRenderer : IRenderer {
        private bool _didSetUIUniforms = false;
        private RenderTarget? _currentRenderTarget;
        private List<Rectangle> _viewportStack = new List<Rectangle>();

        /// <inheritdoc/>
        protected abstract ILogger Log { get; }

        /// <inheritdoc/>
        public abstract nint NativeHwnd { get; }

        /// <inheritdoc/>
        public abstract IGraphicsDevice GraphicsDevice { get; }

        /// <inheritdoc/>
        public abstract IDrawList DrawList { get; }

        /// <inheritdoc/>
        public abstract IShader UIShader { get; }

        /// <inheritdoc/>
        public abstract IShader TextShader { get; }

        /// <inheritdoc/>
        public abstract IFontManager FontManager { get; }

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? OnBeforeRender3D {
            add { _OnBeforeRender3D.Subscribe(value); }
            remove { _OnBeforeRender3D.Unsubscribe(value); }
        }
        /// <summary>
        /// Use to invoke OnBeforeRender3D
        /// </summary>
        protected readonly WeakEvent<EventArgs> _OnBeforeRender3D = new();

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? OnRender3D {
            add { _OnRender3D.Subscribe(value); }
            remove { _OnRender3D.Unsubscribe(value); }
        }
        /// <summary>
        /// Use to invoke OnRender3D
        /// </summary>
        protected readonly WeakEvent<EventArgs> _OnRender3D = new();

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? OnAfterRender3D {
            add { _OnAfterRender3D.Subscribe(value); }
            remove { _OnAfterRender3D.Unsubscribe(value); }
        }
        /// <summary>
        /// Use to invoke OnAfterRender3D
        /// </summary>
        protected readonly WeakEvent<EventArgs> _OnAfterRender3D = new();

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? OnBeforeRenderUI {
            add { _OnBeforeRenderUI.Subscribe(value); }
            remove { _OnBeforeRenderUI.Unsubscribe(value); }
        }
        /// <summary>
        /// Use to invoke OnBeforeRenderUI
        /// </summary>
        protected readonly WeakEvent<EventArgs> _OnBeforeRenderUI = new();

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? OnRenderUI {
            add { _OnRenderUI.Subscribe(value); }
            remove { _OnRenderUI.Unsubscribe(value); }
        }
        /// <summary>
        /// Use to invoke OnRenderUI
        /// </summary>
        protected readonly WeakEvent<EventArgs> _OnRenderUI = new();

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? OnAfterRenderUI {
            add { _OnAfterRenderUI.Subscribe(value); }
            remove { _OnAfterRenderUI.Unsubscribe(value); }
        }
        /// <summary>
        /// Use to invoke OnAfterRenderUI
        /// </summary>
        protected readonly WeakEvent<EventArgs> _OnAfterRenderUI = new();

        /// <inheritdoc/>
        public virtual ScopedDeviceState CreateScopedState() => new ScopedDeviceState(this.GraphicsDevice);

        /// <inheritdoc/>
        public virtual RenderTarget CreateRenderTarget(int width, int height) {
            return new RenderTarget(this, Log, width, height);
        }

        /// <inheritdoc/>
        public virtual void BindRenderTarget(RenderTarget? renderTarget) {
            //_currentRenderTarget?.Flush();
            _currentRenderTarget = renderTarget;

            if (_currentRenderTarget is null) {
                GraphicsDevice.BindFramebuffer(null);
                /*
                if (_viewportStack.Count > 0) {
                    GraphicsDevice.Viewport = _viewportStack[_viewportStack.Count - 1];
                    _viewportStack.RemoveAt(_viewportStack.Count - 1);
                }
                */
            }
            else {
                //_viewportStack.Add(GraphicsDevice.Viewport);
                _currentRenderTarget.Bind();
                //GraphicsDevice.Viewport = _currentRenderTarget.Viewport;
            }
        }

        /// <inheritdoc/>
        public virtual void Render() {
            GraphicsDevice.BeginFrame();

            _OnBeforeRender3D.Invoke(this, EventArgs.Empty);
            _OnRender3D.Invoke(this, EventArgs.Empty);
            _OnAfterRender3D.Invoke(this, EventArgs.Empty);

            _OnBeforeRenderUI.Invoke(this, EventArgs.Empty);
            using (var scope = CreateScopedState()) {
                scope.CullMode = CullMode.None;
                scope.PolygonMode = PolygonMode.Fill;
                scope.SourceBlendFactor = BlendFactor.SrcAlpha;
                scope.DestBlendFactor = BlendFactor.OneMinusSrcAlpha;
                scope.SetRenderState(RenderState.DepthTest, false);
                scope.SetRenderState(RenderState.ScissorTest, false);
                scope.SetRenderState(RenderState.AlphaBlend, false);

                scope.BindShader(TextShader);


                TextShader.SetUniform("xProjection", Matrix4x4.CreateOrthographicOffCenterLeftHanded(
                    0,
                    GraphicsDevice.Viewport.Width,
                    0,
                    GraphicsDevice.Viewport.Height,
                    -1000f,
                    1000f));
                TextShader.SetUniform("xWorld", Matrix4x4.Identity);

                scope.BindShader(UIShader);

                UIShader.SetUniform("xProjection", Matrix4x4.CreateOrthographicOffCenterLeftHanded(
                    0,
                    GraphicsDevice.Viewport.Width,
                    0,
                    GraphicsDevice.Viewport.Height,
                    -1000f,
                    1000f));
                UIShader.SetUniform("xWorld", Matrix4x4.Identity);

                _OnRenderUI.Invoke(this, EventArgs.Empty);
                DrawList.Flush();
                _OnAfterRenderUI.Invoke(this, EventArgs.Empty);
            }

            GraphicsDevice.EndFrame();
        }

        /// <inheritdoc/>
        public abstract void SetCursor(uint cursorDataId, Vector2 hotspot);

        /// <inheritdoc/>
        public virtual void Resize(int width, int height) {
            GraphicsDevice.Viewport = new Rectangle(0, 0, width, height);
        }

        /// <inheritdoc/>
        public abstract void Dispose();
    }
}
