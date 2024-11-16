using Chorizite.Core.Lib;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render {

    public abstract class AShader : IDisposable {
        protected readonly ILogger _log;
        private readonly FileWatcher _fileWatcher;
        private string _liveShaderDirectory = "";

        protected virtual string VertShaderFileName => $"{Name}.vert";
        protected virtual string FragShaderFileName => $"{Name}.frag";
        protected bool NeedsLoad { get; set; } = true;
        protected string? _vertSource;
        protected string? _fragSource;

        /// <summary>
        /// The name of this shader. It should match the filename without the extension.
        /// </summary>
        public string Name { get; }

        public AShader(string name, string vertSource, string? fragSource, ILogger log, string? shaderDirectory = null) {
            Name = name;
            _log = log;
            _vertSource = vertSource;
            _fragSource = fragSource;

            if (!string.IsNullOrEmpty(shaderDirectory)) {
                _liveShaderDirectory = Path.GetFullPath(shaderDirectory);
                _log.LogTrace($"Live shader directory: {Path.GetFullPath(_liveShaderDirectory)}");
                if (Directory.Exists(_liveShaderDirectory)) {
                    _fileWatcher = new FileWatcher(_liveShaderDirectory, $"{Name}.*", (file) => {
                        Reload();
                    });
                }
            }
        }

        /// <summary>
        /// Mark this shader is needing to be reloaded. It will attempt to reload next time <see cref="SetActive"/> is called.
        /// </summary>
        public virtual void Reload() {
            _log.LogDebug($"Reloading shader: {Name}");
            NeedsLoad = true;
        }


        public virtual void SetActive() {
            if (NeedsLoad) {
                try {
                    string? vertShaderSource = _vertSource;
                    string? fragShaderSource = _fragSource;
                    if (File.Exists(Path.Combine(_liveShaderDirectory, VertShaderFileName))) {
                        vertShaderSource = File.ReadAllText(Path.Combine(_liveShaderDirectory, VertShaderFileName));
                    }
                    if (File.Exists(Path.Combine(_liveShaderDirectory, FragShaderFileName))) {
                        fragShaderSource = File.ReadAllText(Path.Combine(_liveShaderDirectory, FragShaderFileName));
                    }

                    LoadShader(vertShaderSource, fragShaderSource);
                    NeedsLoad = false;
                }
                catch (Exception ex) {
                    _log?.LogError(ex, $"Error setting active shader {Name}");
                }
            }
        }

        protected abstract void LoadShader(string? vertShaderSource, string? fragShaderSource);

        public abstract void SetUniform(string name, Matrix4x4 viewProj);
        public abstract void SetUniform(string name, int v);
        public abstract void SetUniform(string name, float v);
        public abstract void SetUniform(string name, float[] vs);
        public abstract void SetUniform(string name, Vector4 vec);
        public abstract void SetUniform(string name, Vector3 vec);
        public abstract void SetUniform(string name, Vector2 vec);
        public abstract void SetUniform(string name, Vector3[] vecs);
        protected abstract void Unload();

        public virtual void Dispose() {
            _fileWatcher?.Dispose();
            Unload();
        }
    }
}
