using System.Numerics;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Represents a shader
    /// </summary>
    public interface IShader {
        /// <summary>
        /// The name of the shader
        /// </summary>
        public string Name { get; }
        uint ProgramId { get; }

        /// <summary>
        /// Load and compile the shader
        /// </summary>
        /// <param name="vertexShader"></param>
        /// <param name="fragmentShader"></param>
        void Load(string vertexShader, string fragmentShader);

        /// <summary>
        /// Set a shader float parameter
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The float value</param>
        void SetUniform(string name, float value);

        /// <summary>
        /// Set a shader int parameter
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The int value</param>
        void SetUniform(string name, int value);

        /// <summary>
        /// Set a shader vector2 parameter
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The vector2 value</param>
        void SetUniform(string name, Vector2 value);

        /// <summary>
        /// Set a shader vector3 parameter
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The vector3 value</param>
        void SetUniform(string name, Vector3 value);

        /// <summary>
        /// Set a shader vector4 parameter
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The vector4 value</param>
        void SetUniform(string name, Vector4 value);

        /// <summary>
        /// Set a shader matrix4x4 parameter
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The matrix4x4 value</param>
        void SetUniform(string name, Matrix4x4 value);

        /// <summary>
        /// Set a shader float array
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="values">The float array</param>
        void SetUniform(string name, float[] values);

        /// <summary>
        /// Bind the shader
        /// </summary>
        void Bind();

        /// <summary>
        /// Unbind the shader
        /// </summary>
        void Unbind();
    }
}