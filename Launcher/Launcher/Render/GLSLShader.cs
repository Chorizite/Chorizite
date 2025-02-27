using Chorizite.Core.Render;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WaveEngine.Bindings.OpenGL;

namespace LauncherApp.Render {

    public unsafe class GLSLShader : AShader {
        public IntPtr Program { get; protected set; }

        public GLSLShader(string name, string vertSource, string fragSource, ILogger log, string? shaderDirectory = null) : base(name, vertSource, fragSource, log, shaderDirectory) {
        }

        public override void SetActive() {
            base.SetActive();
            GL.glUseProgram((uint)Program);
        }

        public override void SetUniform(string location, Matrix4x4 m) {
            IntPtr cName = IntPtr.Zero;
            try {
                var m2 = new float[] {
                    m.M11, m.M12, m.M13, m.M14,
                    m.M21, m.M22, m.M23, m.M24,
                    m.M31, m.M32, m.M33, m.M34,
                    m.M41, m.M42, m.M43, m.M44
                };
                cName = Marshal.StringToHGlobalAnsi(location);
                fixed (float* transform = (float[])m2) {
                    GL.glUniformMatrix4fv(GL.glGetUniformLocation((uint)Program, (char*)cName), 1, false, transform);
                }
            }
            finally {
                if (cName != IntPtr.Zero) {
                    Marshal.FreeHGlobal(cName);
                }
            }
        }

        public override void SetUniform(string location, int v) {
            IntPtr cName = IntPtr.Zero;
            try {
                cName = Marshal.StringToHGlobalAnsi(location);
                GL.glUniform1i(GL.glGetUniformLocation((uint)Program, (char*)cName), v);
            }
            finally {
                if (cName != IntPtr.Zero) {
                    Marshal.FreeHGlobal(cName);
                }
            }
        }

        public override void SetUniform(string location, Vector2 vec) {
            IntPtr cName = IntPtr.Zero;
            try {
                cName = Marshal.StringToHGlobalAnsi(location);
                GL.glUniform2f(GL.glGetUniformLocation((uint)Program, (char*)cName), vec.X, vec.Y);
            }
            finally {
                if (cName != IntPtr.Zero) {
                    Marshal.FreeHGlobal(cName);
                }
            }
        }

        public override void SetUniform(string location, Vector3 vec) {
            IntPtr cName = IntPtr.Zero;
            try {
                cName = Marshal.StringToHGlobalAnsi(location);
                GL.glUniform3f(GL.glGetUniformLocation((uint)Program, (char*)cName), vec.X, vec.Y, vec.Z);
            }
            finally {
                if (cName != IntPtr.Zero) {
                    Marshal.FreeHGlobal(cName);
                }
            }
        }


        public override void SetUniform(string location, Vector3[] vecs) {
            for (var i = 0; i < vecs.Length; i++) {
                var vec = vecs[i];
                IntPtr cName = IntPtr.Zero;
                try {
                    cName = Marshal.StringToHGlobalAnsi($"{location}[{i}]");
                    GL.glUniform3f(GL.glGetUniformLocation((uint)Program, (char*)cName), vec.X, vec.Y, vec.Z);
                }
                finally {
                    if (cName != IntPtr.Zero) {
                        Marshal.FreeHGlobal(cName);
                    }
                }
            }
        }

        public override void SetUniform(string location, Vector4 vec) {
            IntPtr cName = IntPtr.Zero;
            try {
                cName = Marshal.StringToHGlobalAnsi(location);
                GL.glUniform4f(GL.glGetUniformLocation((uint)Program, (char*)cName), vec.X, vec.Y, vec.Z, vec.W);
            }
            finally {
                if (cName != IntPtr.Zero) {
                    Marshal.FreeHGlobal(cName);
                }
            }
        }

        public override void SetUniform(string location, float v) {
            IntPtr cName = IntPtr.Zero;
            try {
                cName = Marshal.StringToHGlobalAnsi(location);
                GL.glUniform1f(GL.glGetUniformLocation((uint)Program, (char*)cName), v);
            }
            finally {
                if (cName != IntPtr.Zero) {
                    Marshal.FreeHGlobal(cName);
                }
            }
        }

        public override void SetUniform(string location, float[] vs) {
            for (var i = 0; i < vs.Length; i++) {
                var v = vs[i];
                IntPtr cName = IntPtr.Zero;
                try {
                    cName = Marshal.StringToHGlobalAnsi($"{location}[{i}]");
                    GL.glUniform1f(GL.glGetUniformLocation((uint)Program, (char*)cName), v);
                }
                finally {
                    if (cName != IntPtr.Zero) {
                        Marshal.FreeHGlobal(cName);
                    }
                }
            }
        }

        protected override void LoadShader(string? vertShaderSource, string? fragShaderSource) {
            NeedsLoad = false;

            if (string.IsNullOrWhiteSpace(vertShaderSource) || string.IsNullOrWhiteSpace(fragShaderSource)) {
                _log.LogError($"Shader {Name} has no source code!");
                return;
            }

            uint vertexShader = CompileShader(ShaderType.VertexShader, Name, vertShaderSource);
            uint fragmentShader = CompileShader(ShaderType.FragmentShader, Name, fragShaderSource);

            var prog = GL.glCreateProgram();
            GL.glAttachShader(prog, vertexShader);
            GL.glAttachShader(prog, fragmentShader);
            GL.glLinkProgram(prog);

            int success = 0;
            GL.glGetProgramiv(prog, ProgramPropertyARB.LinkStatus, &success);
            if (success != 1) {
                var infoLog = stackalloc char[1024];
                GL.glGetProgramInfoLog(prog, 1024, (int*)0, infoLog);
                _log.LogError($"Error: shader program compilation failed: {Marshal.PtrToStringUTF8((IntPtr)infoLog)}");
                return;
            }
            else {
                _log.LogTrace($"{(Program != 0 ? "Reloaded" : "Loaded")} shader: {Name}");
            }

            GL.glDeleteShader(vertexShader);
            GL.glDeleteShader(fragmentShader);

            if (Program != 0) {
                Unload();
            }

            Program = (IntPtr)prog;
        }

        private uint CompileShader(ShaderType shaderType, string name, string shaderSource) {
            uint shader = GL.glCreateShader(shaderType);

            IntPtr* textPtr = stackalloc IntPtr[1];
            textPtr[0] = Marshal.StringToHGlobalAnsi(shaderSource);
            int shaderSourceLength = shaderSource.Length;

            GL.glShaderSource(shader, 1, (IntPtr)textPtr, &shaderSourceLength);
            GL.glCompileShader(shader);

            int success = 0;
            var infoLog = stackalloc char[1024];
            GL.glGetShaderiv(shader, ShaderParameterName.CompileStatus, &success);
            if (success != 1) {
                GL.glGetShaderInfoLog(shader, 1024, (int*)0, infoLog);
                System.Diagnostics.Debug.WriteLine($"Error: {name}:{shaderType} compilation failed: {Marshal.PtrToStringUTF8((IntPtr)infoLog)}");
                _log.LogError($"Error: {name}:{shaderType} compilation failed: {Marshal.PtrToStringUTF8((IntPtr)infoLog)}");
            }

            return shader;
        }

        protected override void Unload() {
            if (Program != 0) {
                GL.glDeleteProgram((uint)Program);
                Program = 0;
            }
        }
    }
}
