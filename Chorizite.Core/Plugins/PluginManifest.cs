using Autofac;
using Chorizite.Core.Serialization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Chorizite.Core.Plugins {
    public class PluginManifest {
        private static JsonSerializerOptions _serializerOptions = new JsonSerializerOptions {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            Converters = { new ChoriziteEnvironmentJsonConverter() }
        };

        public string Name { get; set; } = "";
        public string Author { get; set; } = "";
        public string Version { get; set; } = "";
        public string Description { get; set; } = "";
        public string Repo { get; set; } = "";
        public List<string> Dependencies { get; set; } = [];
        [JsonConverter(typeof(ChoriziteEnvironmentJsonConverter))]
        public ChoriziteEnvironment Environments { get; set; }
        public string EntryFile { get; set; } = "";

        [JsonIgnore]
        public string ManifestFile { get; set; } = "";

        public static bool TryLoadManifest<T>(string filename, out T manifest, out string? errorString) where T : PluginManifest {
            try {
                manifest = JsonSerializer.Deserialize<T>(File.ReadAllText(filename), _serializerOptions)!;
                if (manifest is not null) {
                    if (!manifest.Validate(out var errors)) {
                        errorString = $"Unable to parse plugin manifest: {filename}\n{string.Join("\n", errors)}";
                        return false;
                    }
                    manifest.ManifestFile = filename;
                    errorString = null;
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
