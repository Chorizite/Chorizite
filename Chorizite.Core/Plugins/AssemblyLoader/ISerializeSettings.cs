using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Plugins.AssemblyLoader {
    public interface ISerializeSettings<T> {
        /// <summary>
        /// The json type info for the settings object
        /// </summary>
        protected System.Text.Json.Serialization.Metadata.JsonTypeInfo<T> JsonSettingsTypeInfo { get; }

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
