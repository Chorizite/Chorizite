using NJsonSchema.Annotations;

namespace Chorizite.Plugins.Models {

    [JsonSchemaExtensionData("description", "Chorizite release info")]
    public class ChoriziteInfoModel {
        [JsonSchemaExtensionData("description", "Latest Chorizite release")]
        public required ReleaseModel Latest { get; set; }

        [JsonSchemaExtensionData("description", "Latest Chorizite beta release")]
        public required ReleaseModel? LatestBeta { get; set; }
    }
}
