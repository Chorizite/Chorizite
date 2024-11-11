using Core.UI.Lib;
using Core.UI.Lib.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.UI {
    [JsonSourceGenerationOptions(WriteIndented = true, AllowTrailingCommas = true, UseStringEnumConverter = true)]
    [JsonSerializable(typeof(UIState))]
    internal partial class SourceGenerationContext : JsonSerializerContext {
    }
}
