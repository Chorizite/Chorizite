using Autofac.Core;
using Chorizite.Core.Render;
using Microsoft.Extensions.Logging;
using SharpDX;
using SharpDX.Direct3D9;
using System.Numerics;

namespace Chorizite.NativeClientBootstrapper.Render {
    internal class HLSLShader : AShader {
        private readonly Device _device;
        internal Effect? Effect;

        protected override string VertShaderFileName => $"{Name}.fx";

        public HLSLShader(Device device, string name, string vertSource, string fragSource, ILogger log, string? shaderDir = null) : base(name, vertSource, fragSource, log, shaderDir) {
            _device = device;
        }

        public override void SetActive() {
            base.SetActive();
        }

        public override void Reload() {
            Effect?.OnLostDevice();
            Effect?.OnResetDevice();
        }

        protected override void LoadShader(string? vertShaderSource, string? fragShaderSource) {
            Effect = Effect.FromString(_device, vertShaderSource, ShaderFlags.None);
        }

        public override void SetUniform(string name, Matrix4x4 val) {
            Effect?.SetValue(name, val);
        }

        public override void SetUniform(string name, int val) {
            Effect?.SetValue(name, val);
        }

        public override void SetUniform(string name, float val) {
            Effect?.SetValue(name, val);
        }

        public override void SetUniform(string name, float[] val) {
            Effect?.SetValue(name, val);
        }

        public override void SetUniform(string name, Vector4 val) {
            Effect?.SetValue(name, val);
        }

        public override void SetUniform(string name, Vector3 val) {
            Effect?.SetValue(name, val);
        }

        public override void SetUniform(string name, Vector2 val) {
            Effect?.SetValue(name, val);
        }

        public override void SetUniform(string name, Vector3[] val) {
            Effect?.SetValue(name, val);
        }

        protected override void Unload() {
            Effect?.Dispose();
        }
    }
}