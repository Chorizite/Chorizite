using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Types;
using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.AC.API {
    /// <summary>
    /// Represents an enchantment on a player
    /// </summary>
    public class Enchantment {
        /// <summary>
        /// The full layered id of this enchantment
        /// </summary>
        public LayeredSpellId LayeredId { get; set; }

        /// <summary>
        /// Spell id of this enchantment
        /// </summary>
        [JsonIgnore]
        public uint SpellId => LayeredId.Id;

        /// <summary>
        /// Layer of this enchantment. Higher layer values take priority.
        /// </summary>
        [JsonIgnore]
        public ushort Layer => LayeredId.Layer;

        /// <summary>
        /// Tru if this enchantment has a spell set associated with it
        /// </summary>
        public bool HasEquipmentSet { get; set; }

        /// <summary>
        /// The category of this enchantment
        /// </summary>
        public SpellCategory Category { get; set; }

        /// <summary>
        /// The spell power / difficulty of this enchantment spell
        /// </summary>
        public uint Power { get; set; }

        /// <summary>
        /// The time in seconds that the enchantment has been active before we heard about
        /// it from the server.
        /// </summary>
        public double StartTime { get; set; }

        /// <summary>
        /// The total duration in seconds this enchantment should last for
        /// </summary>
        public double Duration { get; set; }

        /// <summary>
        /// The id of the object who cast this enchantment (player / equipment / etc)
        /// </summary>
        public uint CasterId { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public float DegradeModifier { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public float DegradeLimit { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public double LastTimeDegraded { get; set; }

        /// <summary>
        /// Enchantment flags
        /// </summary>
        public EnchantmentTypeFlags Type { get; set; }

        /// <summary>
        /// The stat key this enchantment affects. Could be of type <see cref="AttributeId">, <see cref="VitalId">, or <see cref="SkillId"> depending on Flags
        /// </summary>
        public uint StatKey { get; set; }

        /// <summary>
        /// The stat value modifier of this enchantment
        /// </summary>
        public float StatValue { get; set; }

        /// <summary>
        /// The spell set id this enchantment comes from.  Only valid if HasSpellSetId is true.
        /// </summary>
        public EquipmentSet EquipmentSet { get; set; }

        /// <summary>
        /// The datetime this enchantment will expire. All times are in UTC.
        /// Formula is: (Duration &lt; 0) ? DateTime.MaxValue : ClientReceivedAt + TimeSpan.FromSeconds(Duration) - TimeSpan.FromSeconds(StartTime)
        /// </summary>
        [JsonIgnore]
        public DateTime ExpiresAt => (Duration < 0) ? DateTime.MaxValue : ClientReceivedAt + TimeSpan.FromSeconds(Duration) - TimeSpan.FromSeconds(StartTime);

        /// <summary>
        /// The datetime that the client recieved this enchantment from the server.
        /// </summary>
        public DateTime ClientReceivedAt { get; set; }

        public Enchantment() { }

        internal Enchantment(LayeredSpellId layeredId) {
            LayeredId = layeredId;
            ClientReceivedAt = DateTime.UtcNow;
        }

        internal static Enchantment FromMessage(Chorizite.ACProtocol.Types.Enchantment enchantmentData) {
            var enchantment = new Enchantment(enchantmentData.Id);

            enchantment.StartTime = enchantmentData.StartTime;
            enchantment.Power = enchantmentData.PowerLevel;
            enchantment.CasterId = enchantmentData.CasterId;
            enchantment.DegradeLimit = enchantmentData.DegradeLimit;
            enchantment.DegradeModifier = enchantmentData.DegradeModifier;
            enchantment.Duration = enchantmentData.Duration;
            enchantment.HasEquipmentSet = enchantmentData.HasEquipmentSet > 0;
            enchantment.EquipmentSet = enchantmentData.EquipmentSet;
            enchantment.LastTimeDegraded = enchantmentData.LastTimeDegraded;
            enchantment.Power = enchantmentData.PowerLevel;
            enchantment.Category = enchantmentData.SpellCategory;
            enchantment.StartTime = enchantmentData.StartTime;
            enchantment.Type = enchantmentData.StatMod.Type;
            enchantment.StatKey = enchantmentData.StatMod.Key;
            enchantment.StatValue = enchantmentData.StatMod.Value;

            return enchantment;
        }

        public override string ToString() {
            return $"Enchantment(Spell: {SpellId}, Set: {EquipmentSet}, Category: {Category}, Caster: {CasterId}, Power: {Power}, StartTime: {StartTime}, Duration: {Duration}, Flags: {Type}, StatKey: {StatKey}, StatValue: {StatValue})";
        }
    }
}
