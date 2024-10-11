using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MagicHat.Core.Serialization {
    public class MagicHatEnvironmentJsonConverter : JsonConverter<MagicHatEnvironment> {
        public override MagicHatEnvironment Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            MagicHatEnvironment env = MagicHatEnvironment.Unknown;
            reader.Read(); // start array
            while (reader.TokenType != JsonTokenType.EndArray) {
                env |= Enum.Parse<MagicHatEnvironment>(reader.GetString());
                reader.Read();
            }
            return env;
        }

        public override void Write(Utf8JsonWriter writer, MagicHatEnvironment value, JsonSerializerOptions options) {
            
        }
    }
}
