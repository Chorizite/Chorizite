using Core.AC.API;
using Core.AC.Lib;
using System.Text.Json.Serialization;

namespace Core.AC {
    [JsonSourceGenerationOptions(WriteIndented = true, AllowTrailingCommas = true, UseStringEnumConverter = true)]
    [JsonSerializable(typeof(PluginState))]
    internal partial class SourceGenerationContext : JsonSerializerContext {
    }
}
