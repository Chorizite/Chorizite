namespace Chorizite.Core.Plugins.AssemblyLoader {
    /// <summary>
    /// Used to serialize settings for an assembly plugin
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISerializeSettings<T> {
        /// <summary>
        /// The json type info for the settings object
        /// </summary>
        protected System.Text.Json.Serialization.Metadata.JsonTypeInfo<T> TypeInfo { get; }

        /// <summary>
        /// Called before the plugin is unloaded.
        /// </summary>
        /// <returns></returns>
        protected T SerializeBeforeUnload();

        /// <summary>
        /// Called directly after the plugin is loaded.
        /// </summary>
        /// <param name="settings">The settings object returned from SerializeBeforeUnload</param>
        protected void DeserializeAfterLoad(T? settings);
    }
}
