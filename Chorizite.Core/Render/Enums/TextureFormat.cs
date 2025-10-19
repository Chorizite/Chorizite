namespace Chorizite.Core.Render.Enums {
    /// <summary>
    /// Texture formats
    /// </summary>
    public enum TextureFormat {
        /// <summary>
        /// RGBA8 - 8 bits per channel (32 bits per pixel)
        /// </summary>
        RGBA8,

        /// <summary>
        /// RGB8 - 8 bits per channel (24 bits per pixel)
        /// </summary>
        RGB8,

        /// <summary>
        /// A8 - Single alpha channel (8 bits per pixel)
        /// </summary>
        A8,

        /// <summary>
        /// RGBA32F - 32-bit float per channel (128 bits per pixel)
        /// </summary>
        Rgba32f,

        /// <summary>
        /// DXT1 - Compressed format with 1-bit alpha (4 bits per pixel)
        /// </summary>
        DXT1,

        /// <summary>
        /// DXT3 - Compressed format with explicit alpha (8 bits per pixel)
        /// </summary>
        DXT3,

        /// <summary>
        /// DXT5 - Compressed format with interpolated alpha (8 bits per pixel)
        /// </summary>
        DXT5
    }
}