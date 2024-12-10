using Chorizite.ACProtocol.Enums;
using System.Collections.Generic;
using System;
using Chorizite.Common.Enums;
using DatReaderWriter.Types;
using System.Text.Json.Serialization;
using System.Linq;

namespace Core.AC.API {
    public class SkillInfo {
        private WorldObject _weenie;
        private SkillAdvancementClass _training = SkillAdvancementClass.Unusable;
        private SkillFormula _formula;
        private SkillBase _dat;

        /// <summary>
        /// The skill type this is
        /// </summary>
        public SkillId Type { get; set; }

        /// <summary>
        /// How many points this skill has been raised.
        /// </summary>
        public uint PointsRaised { get; set; }

        public uint AdjustXP { get; set; }

        /// <summary>
        /// Total experience already spent on this skill
        /// </summary>
        public uint Experience { get; set; }

        /// <summary>
        /// The level this skill intialized at.
        /// </summary>
        public uint InitLevel { get; set; }

        public uint ResistanceOfLastCheck { get; set; }

        public float LastUsedTime { get; set; }

        /// <summary>
        /// The training type of this skill.
        /// </summary>
        public SkillAdvancementClass Training {
            get => _training;
            set {
                if ((uint)value >= Dat.MinLevel) {
                    _training = value;
                }
                else {
                    _training = SkillAdvancementClass.Unusable;
                }
            }
        }

        /// <summary>
        /// The formula for calculating this skill total
        /// </summary>
        [JsonIgnore]
        public SkillFormula Formula {
            get {
                if (_formula == null) {
                    var formula = Dat?.Formula;
                    if (formula is null) {
                        _formula = new SkillFormula(false, 1, 0, 0);
                    }
                    else {
                        _formula = new SkillFormula(formula.UseFormula, formula.Divisor, (AttributeId)formula.Attribute1, (AttributeId)formula.Attribute2);
                    }
                }
                return _formula;
            }
        }

        /// <summary>
        /// The base skill value. (no buffs, includes formula bonus ie missile weapons gets base coordination/2)
        /// </summary>
        [JsonIgnore]
        public int Base {
            get {
                if (_weenie is Character character) {
                    // logic from ACE
                    var _base = (int)(InitLevel + PointsRaised);

                    if (Training > SkillAdvancementClass.Unusable && Formula.UseFormula) {
                        var attrBonus = character.Attributes[Formula.Attribute1].Base;
                        if (Formula.Attribute2 != 0) {
                            attrBonus += character.Attributes[Formula.Attribute2].Base;
                        }

                        _base += (int)Math.Round(((float)attrBonus / Formula.Divisor));
                    }

                    _base += character.Value(PropertyInt.LumAugAllSkills);

                    if (MeleeSkills.Contains(Type))
                        _base += character.Value(PropertyInt.AugmentationSkilledMelee) * 10;
                    else if (MissileSkills.Contains(Type))
                        _base += character.Value(PropertyInt.AugmentationSkilledMissile) * 10;
                    else if (MagicSkills.Contains(Type))
                        _base += character.Value(PropertyInt.AugmentationSkilledMagic) * 10;

                    if (Training >= SkillAdvancementClass.Trained)
                        _base += character.Value(PropertyInt.Enlightenment);
                    return _base;
                }
                return 0;
            }
        }

        /// <summary>
        /// Effective skill. Includes buffs/debuffs/vitae/augmentations.
        /// </summary>
        [JsonIgnore]
        public int Current {
            get {
                if (_weenie is Character character) {
                    // logic from ACE
                    var effectiveBase = (int)(InitLevel + PointsRaised);
                    if (Training > SkillAdvancementClass.Unusable && Formula.UseFormula) {
                        var attrBonus = character.Attributes[Formula.Attribute1].Current;
                        if (Formula.Attribute2 != 0) {
                            attrBonus += character.Attributes[Formula.Attribute2].Current;
                        }

                        effectiveBase += (int)Math.Round(((float)attrBonus / Formula.Divisor));
                    }

                    effectiveBase += character.Value(PropertyInt.LumAugAllSkills);

                    if (MeleeSkills.Contains(Type))
                        effectiveBase += character.Value(PropertyInt.AugmentationSkilledMelee) * 10;
                    else if (MissileSkills.Contains(Type))
                        effectiveBase += character.Value(PropertyInt.AugmentationSkilledMissile) * 10;
                    else if (MagicSkills.Contains(Type))
                        effectiveBase += character.Value(PropertyInt.AugmentationSkilledMagic) * 10;

                    var multiplier = character.GetEnchantmentsMultiplierModifier(Type);
                    var fTotal = effectiveBase * multiplier;

                    if (character.Vitae < 1.0f) {
                        fTotal *= character.Vitae;
                    }

                    fTotal += character.Value(PropertyInt.AugmentationJackOfAllTrades) * 5;

                    if (Training == SkillAdvancementClass.Specialized)
                        fTotal += character.Value(PropertyInt.LumAugSkilledSpec) * 2;

                    var additives = character.GetEnchantmentsAdditiveModifier(Type);
                    return (int)Math.Max(Math.Round(fTotal + additives), 0);
                }

                return 0;
            }
        }

        [JsonIgnore]
        public SkillBase Dat {
            get {
                if (_dat is null) {
                    if (CoreACPlugin.Instance.Dat.SkillTable.Skills.TryGetValue((DatReaderWriter.Enums.SkillId)Type, out SkillBase skillBase)) {
                        _dat = skillBase;
                    }
                    else {
                        _dat = new SkillBase();
                    }
                }
                return _dat;
            }
        }

        [JsonIgnore]
        public SkillAdvancementClass MinTraining => AlwaysTrained.Contains(Type) ? SkillAdvancementClass.Trained : SkillAdvancementClass.Unusable;

        [JsonIgnore]
        public SkillAdvancementClass MaxTraining => Type == SkillId.Salvaging ? SkillAdvancementClass.Trained : SkillAdvancementClass.Specialized;

        [JsonIgnore]
        public int CostToIncreaseTraining {
            get {
                if (Type == SkillId.Salvaging)
                    return 0;
                else if (Training == SkillAdvancementClass.Specialized)
                    return 0;
                else if (Training == SkillAdvancementClass.Trained)
                    return (Dat.SpecializedCost - Dat.TrainedCost);
                else
                    return Dat.TrainedCost;
            }
        }

        [JsonIgnore]
        protected SkillCG? HeritageSkill {
            get {
                if (_heritageSkill is null) {
                    var myHeritage = (HeritageGroup)_weenie.Value(PropertyInt.HeritageGroup, 0);
                    if (CoreACPlugin.Instance.Dat.Portal.CharGen?.HeritageGroups?.TryGetValue((uint)myHeritage, out var heritage) == true) {
                        _heritageSkill = heritage.Skills.FirstOrDefault(f => (SkillId)f.Id == Type);
                    }
                }
                return _heritageSkill;
            }
        }

        [JsonIgnore]
        public int TrainedCost => (HeritageSkill == null ? Dat.TrainedCost : HeritageSkill.NormalCost);
        [JsonIgnore]
        public int SpecializedCost => (HeritageSkill == null ? (Dat.SpecializedCost - Dat.TrainedCost) : HeritageSkill.PrimaryCost);

        /// <summary>
        /// True if this skill can be lowered
        /// </summary>
        [JsonIgnore]
        public bool CanLower => (_weenie is Character) && Training > MinTraining;

        /// <summary>
        /// True if this skill can be raised
        /// </summary>
        [JsonIgnore]
        public bool CanRaise => (_weenie is Character) && Training < MaxTraining;

        [JsonIgnore]
        public int CreditsSpent {
            get {
                if (Training == MinTraining)
                    return 0;
                else if (Training == SkillAdvancementClass.Specialized)
                    return TrainedCost + SpecializedCost;
                else
                    return TrainedCost;
            }
        }

        public SkillInfo() { }


        internal SkillInfo(SkillId skillId, WorldObject weenie) {
            Type = skillId;
            _weenie = weenie;
        }

        /// <summary>
        /// A list of melee skills, including legacy skills
        /// </summary>
        public static List<SkillId> MeleeSkills = new List<SkillId>()
        {
            SkillId.LightWeapons,
            SkillId.HeavyWeapons,
            SkillId.FinesseWeapons,
            SkillId.DualWield,
            SkillId.TwoHandedCombat,

            // legacy
            SkillId.Axe,
            SkillId.Dagger,
            SkillId.Mace,
            SkillId.Spear,
            SkillId.Staff,
            SkillId.Sword,
            SkillId.UnarmedCombat
        };

        /// <summary>
        /// A list of missile skills, including legacy skills
        /// </summary>
        public static List<SkillId> MissileSkills = new List<SkillId>()
        {
            SkillId.MissleWeapons,

            // legacy
            SkillId.Bow,
            SkillId.Crossbow,
            SkillId.Sling,
            SkillId.ThrownWeapons
        };

        /// <summary>
        /// A list of magic skills
        /// </summary>
        public static List<SkillId> MagicSkills = new List<SkillId>()
        {
            SkillId.CreatureEnchantment,
            SkillId.ItemEnchantment,
            SkillId.LifeMagic,
            SkillId.VoidMagic,
            SkillId.WarMagic
        };

        /// <summary>
        /// A list of skills that are always trained
        /// </summary>
        public static List<SkillId> AlwaysTrained = new List<SkillId>()
        {
            SkillId.ArcaneLore,
            SkillId.Jump,
            SkillId.Loyalty,
            SkillId.MagicDefense,
            SkillId.Run,
            SkillId.Salvaging
        };

        /// <summary>
        /// Skills that require augmentation to specialize.
        /// </summary>
        public static List<SkillId> AugSpecSkills = new List<SkillId>()
        {
            SkillId.ArmorTinkering,
            SkillId.ItemTinkering,
            SkillId.MagicItemTinkering,
            SkillId.WeaponTinkering,
            SkillId.Salvaging
        };
        private SkillCG? _heritageSkill;
    }
}