namespace Chorizite.Core.Plugins {
    /// <summary>
    /// Interface for a plugin loader
    /// </summary>
    public interface IPluginLoader {
        /// <summary>
        /// Check if the plugin loader can load a plugin
        /// </summary>
        /// <param name="manifest"></param>
        /// <returns></returns>
        bool CanLoadPlugin(PluginManifest manifest);

        /// <summary>
        /// Load a plugin
        /// </summary>
        /// <param name="manifest"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        bool LoadPluginInstance(PluginManifest manifest, out PluginInstance? instance);
    }
}