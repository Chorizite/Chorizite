using Autofac;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MagicHat.Service.Lib.Plugins {
    public class PluginManifest {
        private static JsonSerializerOptions _serializerOptions = new JsonSerializerOptions {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        public string Name { get; set; } = "";
        public string Author { get; set; } = "";
        public string Version { get; set; } = "";
        public string Description { get; set; } = "";
        public string Repo { get; set; } = "";
        public List<string> Dependencies { get; set; } = [];
        public string EntryFile { get; set; } = "";

        [JsonIgnore]
        public string ManifestFile { get; set; } = "";

        public static bool TryLoadManifest<T>(string filename, out T manifest) where T : PluginManifest {
            try {
                manifest = JsonSerializer.Deserialize<T>(File.ReadAllText(filename), _serializerOptions)!;
                if (manifest is not null) {
                    if (!manifest.Validate(out var errors)) {
                        MagicHatService.Container?.Resolve<ILogger<PluginManager>>()?.LogError($"Unable to load plugin manifest ({filename}): {string.Join(", ", errors)}");
                        return false;
                    }
                    manifest.ManifestFile = filename;
                }
                return manifest is not null;
            }
            catch (Exception ex) {
                MagicHatService.Container?.Resolve<ILogger<PluginManager>>()?.LogError(ex, $"Unable to load plugin manifest ({filename}): {ex.Message}");
            }
            manifest = null!;
            return false;
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
