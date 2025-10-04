using Autofac.Core;
using Chorizite.Core.Render;
using Microsoft.Extensions.Logging;
using SharpDX;
using SharpDX.Direct3D9;
using System.Numerics;

namespace Chorizite.NativeClientBootstrapper.Render {
    internal class HLSLShader : IShader {
        public string Name => throw new System.NotImplementedException();

        public uint ProgramId => throw new System.NotImplementedException();

        public void Bind() {
            throw new System.NotImplementedException();
        }

        public void Load(string vertexShader, string fragmentShader) {
            throw new System.NotImplementedException();
        }

        public void SetUniform(string name, float value) {
            throw new System.NotImplementedException();
        }

        public void SetUniform(string name, int value) {
            throw new System.NotImplementedException();
        }

        public void SetUniform(string name, Vector2 value) {
            throw new System.NotImplementedException();
        }

        public void SetUniform(string name, Vector3 value) {
            throw new System.NotImplementedException();
        }

        public void SetUniform(string name, Vector4 value) {
            throw new System.NotImplementedException();
        }

        public void SetUniform(string name, Matrix4x4 value) {
            throw new System.NotImplementedException();
        }

        public void SetUniform(string name, float[] values) {
            throw new System.NotImplementedException();
        }

        public void Unbind() {
            throw new System.NotImplementedException();
        }
    }
}