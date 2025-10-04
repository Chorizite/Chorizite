using Chorizite.Core.Lib;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Represents a shader.
    /// </summary>
    public abstract class BaseShader : IShader, IDisposable {
        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger _log;
        protected readonly FileWatcher? _fileWatcher;
        protected readonly string? _liveShaderDirectory;

        /// <summary>
        /// The program id
        /// </summary>
        public uint ProgramId { get; protected set; }

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
        public BaseShader(string name, string vertSource, string? fragSource, ILogger log) {
            Name = name;
            _log = log;
            _vertSource = vertSource;
            _fragSource = fragSource;
        }

        /// <summary>
        /// Initializes a new instance of the BaseShader class, loading the specified vertex and fragment shader files
        /// from the given directory and setting up file watching for live shader changes.
        /// </summary>
        /// <remarks>This constructor sets up a file watcher to automatically reload the shader when any
        /// associated shader file changes. The shader directory path is resolved to its absolute form. Ensure that the
        /// provided directory contains the required shader files before calling this constructor.</remarks>
        /// <param name="name">The name of the shader. This is used to locate the corresponding vertex and fragment shader files within the
        /// specified directory.</param>
        /// <param name="shaderDirectory">The path to the directory containing the shader files. The directory must contain files named 'name.vert'
        /// and 'name.frag'.</param>
        /// <param name="log">The logger instance used for diagnostic and debug output during shader initialization and file watching.</param>
        /// <exception cref="Exception">Thrown if either the vertex shader file ('name.vert') or the fragment shader file ('name.frag') does not
        /// exist in the specified directory.</exception>
        public BaseShader(string name, string shaderDirectory, ILogger log) {
            Name = name;
            _log = log;
            _liveShaderDirectory = Path.GetFullPath(shaderDirectory);

            if (!File.Exists(Path.Combine(_liveShaderDirectory, $"{Name}.vert"))) {
                throw new Exception($"Vertex shader file not found: {Path.Combine(_liveShaderDirectory, $"{Name}.vert")}");
            }
            if (!File.Exists(Path.Combine(_liveShaderDirectory, $"{Name}.frag"))) {
                throw new Exception($"Fragment shader file not found: {Path.Combine(_liveShaderDirectory, $"{Name}.frag")}");
            }

            _log.LogDebug($"Watching {Name} shader directory: {_liveShaderDirectory}");
            _fileWatcher = new FileWatcher(_liveShaderDirectory, $"{Name}.*", (file) => {
                _log.LogDebug("Shader file changed: {file}", file);
                Reload();
            });
        }

        /// <summary>
        /// Mark this shader is needing to be reloaded. It will attempt to reload next time <see cref="SetActive"/> is called.
        /// </summary>
        public virtual void Reload() {
            NeedsLoad = true;
        }

        /// <summary>
        /// Sets this shader as active. Will reload the shader if necessary.
        /// </summary>
        public virtual void SetActive() {
            if (NeedsLoad) {
                try {
                    _log?.LogDebug($"Setting active shader {Name}");
                    string? vertShaderSource = _vertSource;
                    string? fragShaderSource = _fragSource;
                    if (File.Exists(Path.Combine(_liveShaderDirectory, VertShaderFileName))) {
                        vertShaderSource = File.ReadAllText(Path.Combine(_liveShaderDirectory, VertShaderFileName));
                    }
                    if (File.Exists(Path.Combine(_liveShaderDirectory, FragShaderFileName))) {
                        fragShaderSource = File.ReadAllText(Path.Combine(_liveShaderDirectory, FragShaderFileName));
                    }

                    if (string.IsNullOrEmpty(vertShaderSource)) {
                        throw new Exception($"Vertex shader source for shader {Name} is null or empty.");
                    }
                    if (string.IsNullOrEmpty(fragShaderSource)) {
                        throw new Exception($"Fragment shader source for shader {Name} is null or empty.");
                    }

                    Load(vertShaderSource, fragShaderSource);
                    NeedsLoad = false;
                }
                catch (Exception ex) {
                    _log?.LogError(ex, $"Error setting active shader {Name}");
                }
            }
        }

        /// <summary>
        /// Loads the shader from disk or from the currently set vert / shader source depending on what constructor
        /// was used to create this shader.
        /// </summary>
        public virtual void Load() {
            if (!String.IsNullOrEmpty(_liveShaderDirectory)) {
                if (File.Exists(Path.Combine(_liveShaderDirectory, $"{Name}.vert"))) {
                    _vertSource = File.ReadAllText(Path.Combine(_liveShaderDirectory, $"{Name}.vert"));
                }
                if (File.Exists(Path.Combine(_liveShaderDirectory, $"{Name}.frag"))) {
                    _fragSource = File.ReadAllText(Path.Combine(_liveShaderDirectory, $"{Name}.Frag"));
                }
            }
        }

        /// <summary>
        /// Loads the shader
        /// </summary>
        /// <param name="vertShaderSource"></param>
        /// <param name="fragShaderSource"></param>
        public abstract void Load(string vertShaderSource, string fragShaderSource);

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

        /// <summary>
        /// Binds the shader
        /// </summary>
        public abstract void Bind();

        /// <summary>
        /// Unbinds the shader
        /// </summary>
        public abstract void Unbind();
    }
}
