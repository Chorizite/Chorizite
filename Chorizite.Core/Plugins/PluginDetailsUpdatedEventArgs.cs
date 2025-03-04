using Chorizite.Plugins.Models;

namespace Chorizite.Core.Plugins {
    /// <summary>
    /// Arguments for the PluginDetailsUpdated event
    /// </summary>
    public class PluginDetailsUpdatedEventArgs {
        /// <summary>
        /// The id of the plugin
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The details
        /// </summary>
        public PluginDetailsModel Details { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="details"></param>
        public PluginDetailsUpdatedEventArgs(string id, PluginDetailsModel details) {
            Id = id;
            Details = details;
        }
    }
}