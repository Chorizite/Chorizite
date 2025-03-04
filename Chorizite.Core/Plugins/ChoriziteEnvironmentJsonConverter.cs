using Chorizite.Common.Enums;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Chorizite.Core.Plugins {

    internal class ChoriziteEnvironmentJsonConverter : JsonConverter<ChoriziteEnvironment> {
        public override ChoriziteEnvironment Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            ChoriziteEnvironment env = ChoriziteEnvironment.Unknown;
            reader.Read(); // start array
            while (reader.TokenType != JsonTokenType.EndArray) {
                env |= reader.GetString() is not null ? Enum.Parse<ChoriziteEnvironment>(reader.GetString()!) : ChoriziteEnvironment.Unknown;
                reader.Read();
            }
            return env;
        }

        public override void Write(Utf8JsonWriter writer, ChoriziteEnvironment value, JsonSerializerOptions options) {

        }
    }
}