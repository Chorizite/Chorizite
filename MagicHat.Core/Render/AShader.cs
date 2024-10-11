using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core.Render {

    public abstract class AShader : IDisposable {
        internal static readonly Dictionary<string, AShader> LoadedShaders = [];
        public string Name { get; }

        public IntPtr Program { get; protected set; }
        public string VertShaderSource { get; protected set; }
        public string FragShaderSource { get; protected set; }

        public bool NeedsLoad { get; set; }

        public AShader(string name) {
            Name = name;
            LoadedShaders.TryAdd(name, this);
        }

        public abstract void SetActive();
        public abstract void SetUniform(string name, Matrix4x4 viewProj);
        public abstract void SetUniform(string name, int v);
        public abstract void SetUniform(string name, float v);
        public abstract void SetUniform(string name, float[] vs);
        public abstract void SetUniform(string name, Vector4 vec);
        public abstract void SetUniform(string name, Vector3 vec);
        public abstract void SetUniform(string name, Vector2 vec);
        public abstract void SetUniform(string name, Vector3[] vecs);

        public abstract void Dispose();

        public virtual void Reload(string vertexSource = null, string fragmentSource = null) {
            if (vertexSource is not null) {
                VertShaderSource = vertexSource;
            }
            if (fragmentSource is not null) {
                FragShaderSource = fragmentSource;
            }
            NeedsLoad = true;
        }
    }
}
