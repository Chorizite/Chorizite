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
    /// <summary>
    /// Represents a shader.
    /// </summary>
    public abstract class AShader : IDisposable {
        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger _log;
        private readonly FileWatcher? _fileWatcher;
        private string _liveShaderDirectory = "";

        /// <summary>
        /// The name of the vertex shader file
        /// </summary>
        protected virtual string VertShaderFileName => $"{Name}.vert";
        /// <summary>
        /// The name of the fragment shader file
        /// </summary>
        protected virtual string FragShaderFileName => $"{Name}.frag";

        /// <summary>
        /// Whether this shader needs to be reloaded
        /// </summary>
        protected bool NeedsLoad { get; set; } = true;

        /// <summary>
        /// The source code of the vertex shader
        /// </summary>
        protected string? _vertSource;

        /// <summary>
        /// The source code of the fragment shader
        /// </summary>
        protected string? _fragSource;

        /// <summary>
        /// The name of this shader. It should match the filename without the extension.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Constructs a shader
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vertSource"></param>
        /// <param name="fragSource"></param>
        /// <param name="log"></param>
        /// <param name="shaderDirectory"></param>
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

        /// <summary>
        /// Sets this shader as active. Will reload the shader if necessary.
        /// </summary>
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

        /// <summary>
        /// Loads the shader
        /// </summary>
        /// <param name="vertShaderSource"></param>
        /// <param name="fragShaderSource"></param>
        protected abstract void LoadShader(string? vertShaderSource, string? fragShaderSource);

        /// <summary>
        /// Sets a uniform
        /// </summary>
        /// <param name="name"></param>
        /// <param name="viewProj"></param>
        public abstract void SetUniform(string name, Matrix4x4 viewProj);

        /// <summary>
        /// Sets a uniform
        /// </summary>
        /// <param name="name"></param>
        /// <param name="v"></param>
        public abstract void SetUniform(string name, int v);

        /// <summary>
        /// Sets a uniform
        /// </summary>
        /// <param name="name"></param>
        /// <param name="v"></param>
        public abstract void SetUniform(string name, float v);

        /// <summary>
        /// Sets a uniform
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vs"></param>
        public abstract void SetUniform(string name, float[] vs);

        /// <summary>
        /// Sets a uniform
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vec"></param>
        public abstract void SetUniform(string name, Vector4 vec);

        /// <summary>
        /// Sets a uniform
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vec"></param>
        public abstract void SetUniform(string name, Vector3 vec);

        /// <summary>
        /// Sets a uniform
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vec"></param>
        public abstract void SetUniform(string name, Vector2 vec);

        /// <summary>
        /// Sets a uniform
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vecs"></param>
        public abstract void SetUniform(string name, Vector3[] vecs);
        
        /// <summary>
        /// Unloads the shader
        /// </summary>
        protected abstract void Unload();

        /// <inheritdoc/>
        public virtual void Dispose() {
            _fileWatcher?.Dispose();
            Unload();
        }
    }
}
