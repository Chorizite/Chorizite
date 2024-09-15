namespace MagicHat.Service.Lib.Plugins {
    public interface IPluginLoader {
        bool CanLoadPlugin(PluginManifest manifest);
        bool LoadPluginInstance(PluginManifest manifest, out PluginInstance? instance);
        IPluginCore? GetPluginInterface(PluginInstance plugin);
    }
}