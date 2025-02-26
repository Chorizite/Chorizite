namespace Chorizite.Core.Plugins {
    public interface IPluginLoader {
        bool CanLoadPlugin(PluginManifest manifest);
        bool LoadPluginInstance(PluginManifest manifest, out PluginInstance? instance);
    }
}