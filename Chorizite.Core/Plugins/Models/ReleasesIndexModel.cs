using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Chorizite.Plugins.Models {
    public class ReleasesIndexModel {
        [JsonPropertyName("$schema")]
        public string Schema => "https://chorizite.github.io/plugin-index/schemas/release-index-schema.json";
        public required ChoriziteInfoModel Chorizite { get; set; }
        public required List<PluginListingModel> Plugins { get; set; }
    }
}
