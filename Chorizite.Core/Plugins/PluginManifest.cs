using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Chorizite.Core.Plugins {
    /// <summary>
    /// A plugin manifest
    /// </summary>
    public class PluginManifest {
        private static JsonSerializerOptions _serializerOptions = new JsonSerializerOptions {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            Converters = { new ChoriziteEnvironmentJsonConverter() }
        };

        /// <summary>
        /// The id of the plugin. This is unique across all plugins.
        /// </summary>
        public string Id { get; set; } = "";

        /// <summary>
        /// The display name to use for the plugin
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// The author of the plugin
        /// </summary>
        public string Author { get; set; } = "";

        /// <summary>
        /// The version of the plugin
        /// </summary>
        public string Version { get; set; } = "";

        /// <summary>
        /// The description of the plugin
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// The repository url of the plugin
        /// </summary>
        public string Repo { get; set; } = "";

        /// <summary>
        /// Plugin icon path, relative to this manifest file
        /// </summary>
        public string Icon { get; set; } = "";

        /// <summary>
        /// The dependencies of the plugin
        /// </summary>
        public List<string> Dependencies { get; set; } = [];

        /// <summary>
        /// The environments supported by the plugin
        /// </summary>
        [JsonConverter(typeof(ChoriziteEnvironmentJsonConverter))]
        public ChoriziteEnvironment Environments { get; set; }

        /// <summary>
        /// The entry file of the plugin
        /// </summary>
        public string EntryFile { get; set; } = "";

        /// <summary>
        /// An absolute path to the manifest file
        /// </summary>
        [JsonIgnore]
        public string ManifestFile { get; set; } = "";

        /// <summary>
        /// An absolute path to the plugin base directory
        /// </summary>
        [JsonIgnore]
        public string BaseDirectory => Path.GetDirectoryName(ManifestFile)!;

        /// <summary>
        /// Try to load a plugin manifest
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <param name="manifest"></param>
        /// <param name="errorString"></param>
        /// <returns></returns>
        public static bool TryLoadManifest<T>(string filename, out T? manifest, out string? errorString) where T : PluginManifest {
            try {
                manifest = JsonSerializer.Deserialize<T>(File.ReadAllText(filename), _serializerOptions)!;
                if (manifest is not null) {
                    if (!manifest.Validate(out var errors)) {
                        errorString = $"Unable to parse plugin manifest: {filename}\n{string.Join("\n", errors)}";
                        return false;
                    }
                    manifest.ManifestFile = filename;
                    errorString = null;

                    // default id from name
                    if (string.IsNullOrWhiteSpace(manifest.Id)) {
                        manifest.Id = manifest.Name;
                    }

                    // default name from id
                    if (string.IsNullOrWhiteSpace(manifest.Name)) {
                        manifest.Name = manifest.Id;
                    }
                    return true;
                }
                else {
                    errorString = $"Unable to parse plugin manifest: {filename}";
                    return false;
                }
            }
            catch (Exception ex) {
                manifest = null!;
                errorString = $"Unable to parse plugin manifest: {filename}\n{ex.Message}";
                return false;
            }
        }

        /// <summary>
        /// Validate this manifest
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public virtual bool Validate(out List<string> errors) {
            errors = [];

            if (string.IsNullOrWhiteSpace(Name)) {
                errors.Add($"{nameof(Name)} cannot be null or whitespace");
            }

            if (string.IsNullOrWhiteSpace(Version)) {
                try {
                    new Version(Version);
                }
                catch (Exception ex) {
                    errors.Add($"Error parsing {nameof(Version)}: {ex.Message}");
                }
            }

            return errors.Count == 0;
        }
    }
}
