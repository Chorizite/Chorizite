using NJsonSchema.Annotations;
using System.Collections.Generic;

namespace Chorizite.Plugins.Models {
    /// <summary>
    /// Information about a plugin
    /// </summary>
    [JsonSchemaExtensionData("description", "Information about a plugin, used for the index page")]
    public class PluginListingModel {
        /// <summary>
        /// The id of the plugin
        /// </summary>
        [JsonSchemaExtensionData("description", "The id of the plugin. These are unique to the plugin index and are used to identify plugins in the index.")]
        public required string Id { get; set; }

        /// <summary>
        /// The name of the plugin
        /// </summary>
        [JsonSchemaExtensionData("description", "The name of the plugin. Used for display purposes only.")]
        public required string Name { get; set; }

        /// <summary>
        /// The plugin website
        /// </summary>
        [JsonSchemaExtensionData("description", "Plugin website url.")]
        public required string Website { get; set; }

        /// <summary>
        /// The author of the plugin
        /// </summary>
        [JsonSchemaExtensionData("description", "The author of the plugin.")]
        public required string Author { get; set; }

        /// <summary>
        /// The description of the plugin
        /// </summary>
        [JsonSchemaExtensionData("description", "The description of the plugin.")]
        public required string Description { get; set; }

        /// <summary>
        /// True if this plugin is installed by default, false otherwise
        /// </summary>
        [JsonSchemaExtensionData("description", "True if this plugin is installed by default, false otherwise.")]
        public required bool IsDefault { get; set; }

        /// <summary>
        /// True if this is an official plugin, false otherwise
        /// </summary>
        [JsonSchemaExtensionData("description", "True if this is an official plugin, false otherwise.")]
        public required bool IsOfficial { get; set; }

        /// <summary>
        /// The dependencies for this release
        /// </summary>
        [JsonSchemaExtensionData("description", "The dependencies for this release.")]
        public required List<string>? Dependencies { get; set; }

        /// <summary>
        /// The environments this release supports
        /// </summary>
        [JsonSchemaExtensionData("description", "The environments this release supports.")]
        public required List<string> Environments { get; set; }

        /// <summary>
        /// The total number of downloads for this plugin
        /// </summary>
        [JsonSchemaExtensionData("description", "The total number of downloads for this plugin.")]
        public required int TotalDownloads { get; set; }

        /// <summary>
        /// The latest version of the plugin
        /// </summary>

        [JsonSchemaExtensionData("description", "The latest version of the plugin.")]
        public required ReleaseModel Latest { get; set; }

        /// <summary>
        /// The latest beta version of the plugin, if any
        /// </summary>

        [JsonSchemaExtensionData("description", "The latest beta version of the plugin, if any.")]
        public required ReleaseModel? LatestBeta { get; set; }
    }
}