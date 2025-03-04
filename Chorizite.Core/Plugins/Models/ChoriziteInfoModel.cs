using NJsonSchema.Annotations;

namespace Chorizite.Plugins.Models {
    /// <summary>
    /// Chorizite release info
    /// </summary>
    [JsonSchemaExtensionData("description", "Chorizite release info")]
    public class ChoriziteInfoModel {
        /// <summary>
        /// Latest Chorizite release
        /// </summary>
        [JsonSchemaExtensionData("description", "Latest Chorizite release")]
        public required ReleaseModel Latest { get; set; }

        /// <summary>
        /// Latest Chorizite beta release
        /// </summary>
        [JsonSchemaExtensionData("description", "Latest Chorizite beta release")]
        public required ReleaseModel? LatestBeta { get; set; }
    }
}
