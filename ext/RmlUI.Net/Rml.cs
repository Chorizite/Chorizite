using System;

namespace RmlUiNet
{
    public static class Rml
    {
        public static bool Initialise()
        {
            return Native.Rml.Initialise();
        }

        public static void Shutdown()
        {
            RmlInstanceCache.Instance?.Clear();
            Native.Rml.Shutdown();
        }

        public static void SetSystemInterface(SystemInterface systemInterface)
        {
            Native.Rml.SetSystemInterface(systemInterface.NativePtr);
        }

        public static void SetRenderInterface(RenderInterface renderInterface)
        {
            Native.Rml.SetRenderInterface(renderInterface.NativePtr);
        }

        public static void SetFileInterface(FileInterface fileInterface)
        {
            Native.Rml.SetFileInterface(fileInterface.NativePtr);
        }

        /// <summary>
        /// Adds a new font face to the font engine. The face's family, style and weight will be determined from the face itself.
        /// </summary>
        /// <param name="fileName">The file to load the face from.</param>
        /// <param name="fallbackFace">True to use this font face for unknown characters in other font faces.</param>
        /// <param name="weight">The weight to load when the font face contains multiple weights, otherwise the weight to register the font as. By default it loads all found font weights.</param>
        /// <returns>True if the face was loaded successfully, false otherwise.</returns>
        public static bool LoadFontFace(string fileName, bool fallbackFace = false, FontWeight weight = FontWeight.Auto)
        {
            return Native.Rml.LoadFontFace(fileName, fallbackFace, weight);
        }

        public static Context? CreateContext(string name, Vector2i dimensions, RenderInterface? renderInterface = null)
        {
            return Context.Create(name, dimensions, renderInterface);
        }

        public static bool RemoveContext(string name) {
            return Native.Rml.RemoveContext(name);
        }

        public static void RegisterPlugin(Plugin plugin) {
            Native.Rml.RegisterPlugin(plugin.NativePtr);
        }

        public static RenderInterface GetRenderInterface() {
            return RenderInterface.Create(Native.Rml.GetRenderInterface());
        }
    }
}
