using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Plugins.AssemblyLoader {
    public interface ISerializeState<T> {
        /// <summary>
        /// The json type info for the state object
        /// </summary>
        protected System.Text.Json.Serialization.Metadata.JsonTypeInfo<T> TypeInfo { get; }

        /// <summary>
        /// Called before the plugin is unloaded during a reload.
        /// Return a state object that will be passed to DeserializeAfterLoad.
        /// </summary>
        /// <returns></returns>
        protected T SerializeBeforeUnload();

        /// <summary>
        /// Called after the plugin is loaded. If this is a reload, the state object will be passed in.
        /// If this is the first load, the state object will be null.
        /// </summary>
        /// <param name="state">The state object returned from SerializeBeforeUnload</param>
        protected void DeserializeAfterLoad(T? state);
    }
}
