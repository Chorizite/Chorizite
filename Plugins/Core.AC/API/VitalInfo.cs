using Chorizite.ACProtocol.Enums;
using Chorizite.Common.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json.Serialization;

namespace Core.AC.API {
    public class VitalInfo {
        private Character character => CoreACPlugin.Instance.Game.Character;
        private SkillFormula _formula;

        /// <summary>
        /// The type of vital this represents
        /// </summary>
        public VitalId Type { get; set; }

        /// <summary>
        /// The amount of points this vital has been raised by
        /// </summary>
        public uint PointsRaised { get; set; }

        /// <summary>
        /// The initial level of this vital
        /// </summary>
        public uint InitLevel { get; set; }

        /// <summary>
        /// Total experience spent in this vital
        /// </summary>
        public uint Experience { get; set; }

        /// <summary>
        /// The formula to use when calculating this vital
        /// </summary>
        [JsonIgnore]
        public virtual SkillFormula Formula {
            get {
                if (_formula is null) {
                    DatReaderWriter.Types.SkillFormula formula = null;
                    switch (Type) {
                        case VitalId.Health:
                            formula = CoreACPlugin.Instance.Dat.VitalTable.Health;
                            break;
                        case VitalId.Stamina:
                            formula = CoreACPlugin.Instance.Dat.VitalTable.Stamina;
                            break;
                        case VitalId.Mana:
                            formula = CoreACPlugin.Instance.Dat.VitalTable.Mana;
                            break;
                    }

                    if (formula != null) {
                        _formula = new SkillFormula(formula.UseFormula, formula.Divisor, (AttributeId)formula.Attribute1, (AttributeId)formula.Attribute2);
                    }
                    else {
                        _formula = new SkillFormula(false, 1, 0, 0);
                    }
                }
                return _formula;
            }
        }

        /// <summary>
        /// The base value of this vital
        /// </summary>
        [JsonIgnore]
        public virtual int Base {
            get {
                var _base = (int)(InitLevel + PointsRaised);
                // todo: health ratings from gear
                if (Formula.UseFormula) {
                    var attrBonus = character.Attributes[Formula.Attribute1].Base;
                    if (Formula.Attribute1 == AttributeId.Endurance) {
                        attrBonus += 1;
                    }
                    if (Formula.Attribute2 != 0) {
                        attrBonus += character.Attributes[Formula.Attribute2].Base;
                    }

                    _base += (int)Math.Round(((float)attrBonus / Formula.Divisor));
                }
                return _base;
            }
        }

        /// <summary>
        /// The max value for this vital. This includes enchantments/vitae
        /// </summary>
        [JsonIgnore]
        public virtual int Max {
            get {
                // logic from ACE
                var max = (int)(InitLevel + PointsRaised);
                if (Type == VitalId.Health) {
                    if (character.Value(PropertyInt.Enlightenment) > 0)
                        max += character.Value(PropertyInt.Enlightenment) * 2;
                    max += character.Value(PropertyInt.GearMaxHealth);
                }

                if (Formula.UseFormula) {
                    var attrBonus = character.Attributes[Formula.Attribute1].Current;
                    if (Formula.Attribute2 != 0) {
                        attrBonus += character.Attributes[Formula.Attribute2].Current;
                    }

                    max += (int)Math.Floor(((float)attrBonus / Formula.Divisor) + 0.5f);
                }

                var multiplier = character.GetEnchantmentsMultiplierModifier(Type);
                var fTotal = max * multiplier;

                if (character.Vitae < 1.0f && character.Vitae > 0.0f) {
                    fTotal *= character.Vitae;
                }

                var additives = character.GetEnchantmentsAdditiveModifier(Type);
                var iTotal = (int)Math.Floor(fTotal + (float)additives + 0.5f);
                var minVital = max >= 5 ? 5 : 1;

                iTotal = Math.Max(minVital, iTotal);

                return iTotal;
            }
        }

        /// <summary>
        /// The current value of this vital
        /// </summary>
        public int Current { get; set; }

        public VitalInfo() {
            
        }

        internal VitalInfo(VitalId vitalId) {
            Type = vitalId;
        }

        public override string ToString() {
            return $"[Vital: {Type}, Base: {Base}, Max: {Max}, Current: {Current}]";
        }
    }
}