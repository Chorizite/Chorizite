using Core.AC.Lib;
using System.Text.Json.Serialization;

namespace Core.AC {
    [JsonSourceGenerationOptions(WriteIndented = true, AllowTrailingCommas = true, UseStringEnumConverter = true)]
    [JsonSerializable(typeof(ACState))]
    internal partial class SourceGenerationContext : JsonSerializerContext {
    }
}
