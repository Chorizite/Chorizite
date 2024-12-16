using Chorizite.Common.Enums;
using Core.AC.API;
using Core.AC.Lib;
using Core.AC.Lib.Screens;
using Core.AC.UIModels;
using System.Text.Json.Serialization;

namespace Core.AC {
    [JsonSourceGenerationOptions(WriteIndented = true, AllowTrailingCommas = true, UseStringEnumConverter = true)]
    [JsonSerializable(typeof(PluginState))]
    [JsonSerializable(typeof(GameScreen))]
    [JsonSerializable(typeof(CharSelectScreenModel))]
    [JsonSerializable(typeof(CharacterInfo))]
    [JsonSerializable(typeof(TooltipModel))]
    [JsonSerializable(typeof(Game))]
    [JsonSerializable(typeof(Character))]
    [JsonSerializable(typeof(AttributeId), TypeInfoPropertyName = "AttributeIdCommon")]
    [JsonSerializable(typeof(SkillFormula), TypeInfoPropertyName = "SkillFormulaCommon")]
    internal partial class SourceGenerationContext : JsonSerializerContext {
    }
}
