using NJsonSchema.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Chorizite.Plugins.Models {

    [JsonSchemaExtensionData("description", "Plugin details.")]
    public class PluginDetailsModel {
        [JsonPropertyName("$schema")]
        public string Schema => "https://chorizite.github.io/plugin-index/schemas/plugin-details-schema.json";

        [JsonSchemaExtensionData("description", "The id of the plugin. These are unique to the plugin index and are used to identify plugins in the index.")]
        public required string Id { get; set; }

        [JsonSchemaExtensionData("description", "The name of the plugin. Used for display purposes only.")]
        public required string Name { get; set; }

        [JsonSchemaExtensionData("description", "Plugin website url.")]
        public required string Website { get; set; }

        [JsonSchemaExtensionData("description", "The author of the plugin.")]
        public required string Author { get; set; }

        [JsonSchemaExtensionData("description", "The description of the plugin.")]
        public required string Description { get; set; }

        [JsonSchemaExtensionData("description", "The dependencies for this release.")]
        public required List<string> Dependencies { get; set; }

        [JsonSchemaExtensionData("description", "The environments this release supports.")]
        public required List<string> Environments { get; set; }

        [JsonSchemaExtensionData("description", "True if this plugin is installed by default, false otherwise.")]
        public required bool IsDefault { get; set; }

        [JsonSchemaExtensionData("description", "True if this is an official plugin, false otherwise.")]
        public required bool IsOfficial { get; set; }

        [JsonSchemaExtensionData("description", "The total number of downloads for this plugin.")]
        public required int TotalDownloads { get; set; }

        [JsonSchemaExtensionData("description", "The list of releases for this plugin.")]
        public required List<ReleaseDetailsModel> Releases { get; set; }
    }
}
