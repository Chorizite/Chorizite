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

    public unsafe class GLSLShader : IShader {
        private readonly ILogger _log;
        private readonly string _name;
        public IntPtr Program { get; protected set; }

        public string Name => _name;

        public uint ProgramId => (uint)Program;

        public GLSLShader(string name, string vertSource, string fragSource, ILogger log, string? shaderDirectory = null) {
            _name = name;
            _log = log;
            Load(vertSource, fragSource);
        }

        public  void SetActive() {
            GL.glUseProgram((uint)Program);
        }

        public  void SetUniform(string location, Matrix4x4 m) {
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

        public  void SetUniform(string location, int v) {
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

        public  void SetUniform(string location, Vector2 vec) {
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

        public  void SetUniform(string location, Vector3 vec) {
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


        public  void SetUniform(string location, Vector3[] vecs) {
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

        public  void SetUniform(string location, Vector4 vec) {
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

        public  void SetUniform(string location, float v) {
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

        public  void SetUniform(string location, float[] vs) {
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

        private uint CompileShader(ShaderType shaderType, string name, string shaderSource) {
            uint shader = GL.glCreateShader(shaderType);

            IntPtr* textPtr = stackalloc IntPtr[1];
            textPtr[0] = Marshal.StringToHGlobalAnsi(shaderSource);
            int shaderSourceLength = shaderSource.Length;

            try {
                GL.glShaderSource(shader, 1, (IntPtr)textPtr, &shaderSourceLength);
                GL.glCompileShader(shader);

                int success = 0;
                byte* infoLog = stackalloc byte[4096];
                GL.glGetShaderiv(shader, ShaderParameterName.CompileStatus, &success);
                if (success != 1) {
                    GL.glGetShaderInfoLog(shader, 4096, (int*)0, (char*)infoLog);
                    var message = Marshal.PtrToStringAnsi((IntPtr)infoLog) ?? "unknown shader compile error";
                    _log.LogError("Shader compile failed for {ShaderName} ({ShaderType}): {Message}", name, shaderType, message);
                }
            }
            finally {
                Marshal.FreeHGlobal(textPtr[0]);
            }

            return shader;
        }


        public void Load(string vertexShader, string fragmentShader) {
            var vertexShaderId = CompileShader(ShaderType.VertexShader, _name, vertexShader);
            var fragmentShaderId = CompileShader(ShaderType.FragmentShader, _name, fragmentShader);

            uint program = GL.glCreateProgram();
            GL.glAttachShader(program, vertexShaderId);
            GL.glAttachShader(program, fragmentShaderId);
            GL.glLinkProgram(program);

            int success = 0;
            byte* infoLog = stackalloc byte[4096];
            GL.glGetProgramiv(program, ProgramPropertyARB.LinkStatus, &success);
            if (success != 1) {
                GL.glGetProgramInfoLog(program, 4096, (int*)0, (char*)infoLog);
                var message = Marshal.PtrToStringAnsi((IntPtr)infoLog) ?? "unknown shader link error";
                _log.LogError("Shader link failed for {ShaderName}: {Message}", _name, message);
            }

            GL.glDetachShader(program, vertexShaderId);
            GL.glDetachShader(program, fragmentShaderId);
            GL.glDeleteShader(vertexShaderId);
            GL.glDeleteShader(fragmentShaderId);

            Program = (IntPtr)program;
        }

        public void Bind() {
            SetActive();
        }

        public void Unbind() {
            GL.glUseProgram(0);
        }
    }
}
