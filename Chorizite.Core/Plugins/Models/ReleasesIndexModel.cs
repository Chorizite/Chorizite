using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Chorizite.Plugins.Models {
    /// <summary>
    /// The model for the plugin releases index
    /// </summary>
    public class ReleasesIndexModel {
        /// <summary>
        /// json schema
        /// </summary>
        [JsonPropertyName("$schema")]
        public string Schema => "https://chorizite.github.io/plugin-index/schemas/release-index-schema.json";

        /// <summary>
        /// Chorizite release info
        /// </summary>
        public required ChoriziteInfoModel Chorizite { get; set; }

        /// <summary>
        /// List of plugins
        /// </summary>
        public required List<PluginListingModel> Plugins { get; set; }
    }
}
