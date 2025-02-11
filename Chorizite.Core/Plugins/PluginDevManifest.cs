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
    public class PluginDevManifest {
        private static JsonSerializerOptions _serializerOptions = new JsonSerializerOptions {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        public string Source { get; set; } = "";
        public string Bin { get; set; } = "";
        
        [JsonIgnore]
        public string ManifestFile { get; set; } = "";

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
