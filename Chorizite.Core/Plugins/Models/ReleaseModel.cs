using NJsonSchema.Annotations;
using System;
using System.Collections.Generic;

namespace Chorizite.Plugins.Models {
    /// <summary>
    /// Represents a release.
    /// </summary>
    public class ReleaseModel {
        /// <summary>
        /// The version of this release.
        /// </summary>
        [JsonSchemaExtensionData("description", "The version of this release.")]
        public required string Version { get; set; }

        /// <summary>
        /// The download URL for this release.
        /// </summary>
        [JsonSchemaExtensionData("description", "The download URL for this release.")]
        public required string DownloadUrl { get; set; }

        /// <summary>
        /// The SHA256 hash for this release.
        /// </summary>
        [JsonSchemaExtensionData("description", "The SHA256 hash for this release.")]
        public required string Sha256 { get; set; }

        /// <summary>
        /// Number of downloads for this release.
        /// </summary>
        [JsonSchemaExtensionData("description", "Number of downloads for this release.")]
        public required int Downloads { get; set; }

        /// <summary>
        /// The dependencies for this release.
        /// </summary>
        [JsonSchemaExtensionData("description", "The dependencies for this release.")]
        public required List<string> Dependencies { get; set; }

        /// <summary>
        /// The environments this release supports.
        /// </summary>
        [JsonSchemaExtensionData("description", "The environments this release supports.")]
        public required List<string> Environments { get; set; }

        /// <summary>
        /// The date this release was created.
        /// </summary>
        [JsonSchemaExtensionData("description", "The date this release was created.")]
        public required DateTime Created { get; set; }

        /// <summary>
        /// The date this release was updated.
        /// </summary>
        [JsonSchemaExtensionData("description", "The date this release was updated.")]
        public required DateTime Updated { get; set; }

        /// <summary>
        /// If this is true, the release asset files have been modified after the release was initially published.
        /// </summary>
        [JsonSchemaExtensionData("description", "If this is true, the release asset files have been modified after the release was initially published.")]
        public required bool HasReleaseModifications { get; set; }
    }
}