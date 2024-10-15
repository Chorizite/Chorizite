using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Chorizite.Core.Serialization {
    public class ChoriziteEnvironmentJsonConverter : JsonConverter<ChoriziteEnvironment> {
        public override ChoriziteEnvironment Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            ChoriziteEnvironment env = ChoriziteEnvironment.Unknown;
            reader.Read(); // start array
            while (reader.TokenType != JsonTokenType.EndArray) {
                env |= Enum.Parse<ChoriziteEnvironment>(reader.GetString());
                reader.Read();
            }
            return env;
        }

        public override void Write(Utf8JsonWriter writer, ChoriziteEnvironment value, JsonSerializerOptions options) {
            
        }
    }
}
