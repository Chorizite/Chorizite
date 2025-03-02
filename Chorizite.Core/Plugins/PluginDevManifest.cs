using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Chorizite.Core.Plugins {
    /// <summary>
    /// A plugin dev manifest
    /// </summary>
    public class PluginDevManifest {
        private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        /// The source directory for this plugin, used for live reloading
        /// </summary>
        public string Source { get; set; } = "";

        /// <summary>
        /// The bin directory for this plugin
        /// </summary>
        public string Bin { get; set; } = "";

        /// <summary>
        /// The absolute path to this manifest file
        /// </summary>
        [JsonIgnore]
        public string ManifestFile { get; set; } = "";

        /// <summary>
        /// Try to load a plugin dev manifest
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="manifest"></param>
        /// <param name="errorString"></param>
        /// <returns></returns>
        public static bool TryLoadManifest(string filename, out PluginDevManifest manifest, out string? errorString) {
            try {
                manifest = JsonSerializer.Deserialize<PluginDevManifest>(File.ReadAllText(filename), _serializerOptions)!;
                if (manifest is not null) {
                    manifest.ManifestFile = filename;
                    errorString = null;
                    return true;
                }
                else {
                    errorString = $"Unable to parse plugin dev manifest: {filename}";
                    return false;
                }
            }
            catch (Exception ex) {
                manifest = null!;
                errorString = $"Unable to parse plugin dev manifest: {filename}\n{ex.Message}";
                return false;
            }
        }
    }
}
