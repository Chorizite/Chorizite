using NJsonSchema.Annotations;
using System;
using System.Collections.Generic;

namespace Chorizite.Plugins.Models {
    public class ReleaseModel {

        [JsonSchemaExtensionData("description", "The version of this release.")]
        public required string Version { get; set; }

        [JsonSchemaExtensionData("description", "The download URL for this release.")]
        public required string DownloadUrl { get; set; }

        [JsonSchemaExtensionData("description", "The SHA256 hash for this release.")]
        public required string Sha256 { get; set; }

        [JsonSchemaExtensionData("description", "Number of downloads for this release.")]
        public required int Downloads { get; set; }

        [JsonSchemaExtensionData("description", "The dependencies for this release.")]
        public required List<string> Dependencies { get; set; }

        [JsonSchemaExtensionData("description", "The environments this release supports.")]
        public required List<string> Environments { get; set; }

        [JsonSchemaExtensionData("description", "The date this release was created.")]
        public required DateTime Created { get; set; }

        [JsonSchemaExtensionData("description", "The date this release was updated.")]
        public required DateTime Updated { get; set; }

        [JsonSchemaExtensionData("description", "If this is true, the release asset files have been modified after initial release.")]
        public required bool HasReleaseModifications { get; set; }
    }
}