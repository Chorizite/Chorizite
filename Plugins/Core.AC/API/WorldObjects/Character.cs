using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages.C2S;
using Chorizite.ACProtocol.Messages.S2C;
using Chorizite.ACProtocol.Messages.S2C.Events;
using Chorizite.ACProtocol.Types;
using Chorizite.Common;
using Chorizite.Common.Enums;
using Chorizite.Core.Net;
using Core.AC.API.WorldObjects;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Core.AC.API {
    public class Character : Player, IDisposable {
        private readonly ILogger _log;
        private readonly NetworkParser _net;
        private readonly ushort VITAE_SPELL_ID = 666;

        // this ensures level 8 item self spells always take precedence over level 8 item other spells
        private static HashSet<uint> Level8AuraSelfSpells = new HashSet<uint> {
            4395u, //(uint)SpellId.BloodDrinkerSelf8,
            4400u, //(uint)SpellId.DefenderSelf8,
            4405u, //(uint)SpellId.HeartSeekerSelf8,
            4414u, //(uint)SpellId.SpiritDrinkerSelf8,
            4417u, //(uint)SpellId.SwiftKillerSelf8,
            4418u, //(uint)SpellId.HermeticLinkSelf8,
        };

        // from ACE
        private HashSet<uint> _setSpells = null;
        private HashSet<uint> SetSpells {
            get {
                if (_setSpells == null) {
                    _setSpells = new HashSet<uint>();
                    foreach (var spellSet in CoreACPlugin.Instance.Dat.SpellTable.SpellsSets.Values) {
                        foreach (var tier in spellSet.SpellSetTiers.Values) {
                            foreach (var spell in tier.Spells) {
                                // cutoff for enchantment manager bug fix sorting
                                if (spell >= 4730u/*(uint)SpellId.SetCoordination1*/)
                                    _setSpells.Add(spell);
                            }
                        }
                    }
                }

                return _setSpells;
            }
        }

        internal float _vitae = 1f;

        /// <summary>
        /// Character Options
        /// </summary>
        public CharacterOptions1 Options1 { get; set; }

        /// <summary>
        /// A dictionary of all skills
        /// </summary>
        public Dictionary<SkillId, SkillInfo> Skills { get; set; } = [];

        /// <summary>
        /// A dictionary of all attributes
        /// </summary>
        public Dictionary<AttributeId, AttributeInfo> Attributes { get; set; } = [];

        /// <summary>
        /// A dictionary of all vitals
        /// </summary>
        public Dictionary<VitalId, VitalInfo> Vitals { get; set; } = [];

        /// <summary>
        /// Character's current vitae
        /// 1 = no vitea, 0.95 = 5% vitae
        /// </summary>
        public float Vitae {
            get => _vitae;
            set {
                if (_vitae != value) {
                    var old = _vitae;
                    _vitae = value;
                    _OnVitaeChanged.Invoke(this, new VitaeChangedEventArgs(value, old));
                }
            }
        }

        /// <summary>
        /// Wether or not the currently logged in character is in portal space
        /// </summary>
        public bool InPortalSpace { get; set; } = true; // portal space while logging in

        /// <summary>
        /// A list of *all* enchantments on this character. This includes enchantments that may be overriden by other enchantments.
        /// </summary>
        public Dictionary<LayeredSpellId, Enchantment> AllEnchantments { get; set; } = [];

        /// <summary>
        /// A list of all shared object cooldowns on this character.
        /// </summary>
        [JsonIgnore]
        public Dictionary<LayeredSpellId, SharedCooldown> SharedCooldowns { get; set; } = [];

        #region Events
        /// <summary>
        /// Fired when your character's vitae changes
        /// </summary>
        public event EventHandler<VitaeChangedEventArgs> OnVitaeChanged {
            add => _OnVitaeChanged.Subscribe(value);
            remove => _OnVitaeChanged.Unsubscribe(value);
        }
        private WeakEvent<VitaeChangedEventArgs> _OnVitaeChanged = new();

        /// <summary>
        /// Fired when a vital changes
        /// </summary>
        public event EventHandler<VitalChangedEventArgs> OnVitalChanged {
            add => _OnVitalChanged.Subscribe(value);
            remove => _OnVitalChanged.Unsubscribe(value);
        }
        private WeakEvent<VitalChangedEventArgs> _OnVitalChanged = new();

        /// <summary>
        /// Fired when an enchantment is added or expires
        /// </summary>
        public event EventHandler<EnchantmentsChangedEventArgs> OnEnchantmentChanged {
            add => _OnEnchantmentChanged.Subscribe(value);
            remove => _OnEnchantmentChanged.Unsubscribe(value);
        }
        private WeakEvent<EnchantmentsChangedEventArgs> _OnEnchantmentChanged = new();

        /// <summary>
        /// Fired when a shared cooldown is added or expires
        /// </summary>
        public event EventHandler<SharedCooldownsChangedEventArgs> OnSharedCooldownChanged {
            add => _OnSharedCooldownChanged.Subscribe(value);
            remove => _OnSharedCooldownChanged.Unsubscribe(value);
        }
        private WeakEvent<SharedCooldownsChangedEventArgs> _OnSharedCooldownChanged = new();

        /// <summary>
        /// Fired when your character enters portal space. This is not fired during login, so the
        /// first portal event you will receive is when you exit portal space.
        /// </summary>
        public event EventHandler<EventArgs> OnPortalSpaceEntered {
            add => _OnPortalSpaceEntered.Subscribe(value);
            remove => _OnPortalSpaceEntered.Unsubscribe(value);
        }
        private WeakEvent<EventArgs> _OnPortalSpaceEntered = new();

        /// <summary>
        /// Fired when your character exits portal space
        /// </summary>
        public event EventHandler<EventArgs> OnPortalSpaceExited {
            add => _OnPortalSpaceExited.Subscribe(value);
            remove => _OnPortalSpaceExited.Unsubscribe(value);
        }
        private WeakEvent<EventArgs> _OnPortalSpaceExited = new();

        /// <summary>
        /// Fired when your character dies
        /// </summary>
        public event EventHandler<DeathEventArgs> OnDeath {
            add => _OnDeath.Subscribe(value);
            remove => _OnDeath.Unsubscribe(value);
        }
        private WeakEvent<DeathEventArgs> _OnDeath = new();
        #endregion // Events

        public Character() {
            _log = CoreACPlugin.Log;
            _net = CoreACPlugin.Instance.Net;

            _net.C2S.OnLogin_SendEnterWorld += OnLogin_SendEnterWorld;
            _net.S2C.OnLogin_PlayerDescription += OnLogin_PlayerDescription;
            _net.S2C.OnLogin_LogOffCharacter += OnLogin_LogOffCharacter;

            _net.S2C.OnEffects_PlayerTeleport += OnEffects_PlayerTeleport;
            _net.S2C.OnItem_SetState += OnItem_SetState;

            _net.S2C.OnCombat_HandlePlayerDeathEvent += OnCombat_HandlePlayerDeathEvent;

            _net.S2C.OnQualities_PrivateRemoveBoolEvent += OnQualities_PrivateRemoveBoolEvent;
            _net.S2C.OnQualities_PrivateUpdateBool += OnQualities_PrivateUpdateBool;
            _net.S2C.OnQualities_PrivateRemoveIntEvent += OnQualities_PrivateRemoveIntEvent;
            _net.S2C.OnQualities_PrivateUpdateInt += OnQualities_PrivateUpdateInt;
            _net.S2C.OnQualities_PrivateRemoveInt64Event += OnQualities_PrivateRemoveInt64Event;
            _net.S2C.OnQualities_PrivateUpdateInt64 += OnQualities_PrivateUpdateInt64;
            _net.S2C.OnQualities_PrivateRemoveFloatEvent += OnQualities_PrivateRemoveFloatEvent;
            _net.S2C.OnQualities_PrivateUpdateFloat += OnQualities_PrivateUpdateFloat;
            _net.S2C.OnQualities_PrivateRemoveStringEvent += OnQualities_PrivateRemoveStringEvent;
            _net.S2C.OnQualities_PrivateUpdateString += OnQualities_PrivateUpdateString;
            _net.S2C.OnQualities_PrivateRemoveInstanceIdEvent += OnQualities_PrivateRemoveInstanceIdEvent;
            _net.S2C.OnQualities_PrivateUpdateInstanceId += OnQualities_PrivateUpdateInstanceId;
            _net.S2C.OnQualities_PrivateRemoveDataIdEvent += OnQualities_PrivateRemoveDataIdEvent;
            _net.S2C.OnQualities_PrivateUpdateDataId += OnQualities_PrivateUpdateDataId;
            _net.S2C.OnQualities_PrivateUpdateAttribute2ndLevel += OnQualities_PrivateUpdateAttribute2ndLevel;
            _net.S2C.OnQualities_PrivateUpdateAttribute2nd += OnQualities_PrivateUpdateAttribute2nd;
            _net.S2C.OnQualities_PrivateUpdateAttributeLevel += OnQualities_PrivateUpdateAttributeLevel;
            _net.S2C.OnQualities_PrivateUpdateAttribute += OnQualities_PrivateUpdateAttribute;
            _net.S2C.OnQualities_PrivateUpdateSkillAC += OnQualities_PrivateUpdateSkillAC;
            _net.S2C.OnQualities_PrivateUpdateSkillLevel += OnQualities_PrivateUpdateSkillLevel;
            _net.S2C.OnQualities_PrivateUpdateSkill += OnQualities_PrivateUpdateSkill;
            _net.S2C.OnQualities_PrivateRemovePositionEvent += OnQualities_PrivateRemovePositionEvent;
            _net.S2C.OnQualities_PrivateUpdatePosition += OnQualities_PrivateUpdatePosition;

            _net.S2C.OnMagic_DispelEnchantment += OnMagic_DispelEnchantment;
            _net.S2C.OnMagic_DispelMultipleEnchantments += OnMagic_DispelMultipleEnchantments;
            _net.S2C.OnMagic_PurgeBadEnchantments += OnMagic_PurgeBadEnchantments;
            _net.S2C.OnMagic_PurgeEnchantments += OnMagic_PurgeEnchantmentst;
            _net.S2C.OnMagic_RemoveEnchantment += OnMagic_RemoveEnchantment;
            _net.S2C.OnMagic_RemoveMultipleEnchantments += OnMagic_RemoveMultipleEnchantments;
            _net.S2C.OnMagic_UpdateEnchantment += OnMagic_UpdateEnchantment;
            _net.S2C.OnMagic_UpdateMultipleEnchantments += OnMagic_UpdateMultipleEnchantments;
        }

        #region Public API
        /// <summary>
        /// A list of active enchantments on this character. Does not include overlapping enchantments
        /// </summary>
        /// <returns>A list of enchantments</returns>
        public IList<Enchantment> GetActiveEnchantments() {
            return AllEnchantments.Values
                .GroupBy(enchantment => enchantment.Category)
                .Select(category => {
                    return category
                    .OrderByDescending(enchantment => enchantment.Power)
                    .ThenByDescending(enchantment => Level8AuraSelfSpells.Contains(enchantment.SpellId))
                    .ThenByDescending(c => SetSpells.Contains(c.SpellId) ? c.SpellId : c.StartTime)
                    .First();
                }).ToList();
        }

        /// <summary>
        /// Gets a list of active enchantments on this character that affect the specified skill.
        /// </summary>
        /// <param name="skillId">The skill id to filter by</param>
        /// <returns>A list of enchantments</returns>
        public IList<Enchantment> GetActiveEnchantments(SkillId skillId) {
            return AllEnchantments.Values
                .Where(enchantment => enchantment.Type.HasFlag(EnchantmentTypeFlags.Skill) && enchantment.StatKey == (uint)skillId)
                .GroupBy(enchantment => enchantment.Category)
                .Select(category => {
                    return category
                        .OrderByDescending(enchantment => enchantment.Power)
                        .ThenByDescending(enchantment => Level8AuraSelfSpells.Contains(enchantment.SpellId))
                        .ThenByDescending(c => SetSpells.Contains(c.SpellId) ? c.SpellId : c.StartTime)
                        .First();
                }).ToList();
        }

        /// <summary>
        /// Gets a list of active enchantments on this character that affect the specified attribute
        /// </summary>
        /// <param name="attributeId">the attribute id to filter by</param>
        /// <returns>A list of enchantments</returns>
        public IList<Enchantment> GetActiveEnchantments(AttributeId attributeId) {
            return AllEnchantments.Values
                .Where((enchantment) => {
                    return (enchantment.Type.HasFlag(EnchantmentTypeFlags.Attribute) &&
                        (enchantment.StatKey == (uint)attributeId || enchantment.Type.HasFlag(EnchantmentTypeFlags.MultipleStat)));
                })
                .GroupBy(enchantment => enchantment.Category)
                .Select(category => {
                    return category
                    .OrderByDescending(enchantment => enchantment.Power)
                    .ThenByDescending(enchantment => Level8AuraSelfSpells.Contains(enchantment.SpellId))
                    .ThenByDescending(c => SetSpells.Contains(c.SpellId) ? c.SpellId : c.StartTime)
                    .First();
                }).ToList();
        }

        /// <summary>
        /// Gets a list of active enchantments on this character that affect the specified vital
        /// </summary>
        /// <param name="vitalId">The vital id to filter by</param>
        /// <returns>A list of enchantments</returns>
        public IList<Enchantment> GetActiveEnchantments(VitalId vitalId) {
            return AllEnchantments.Values
                .Where(enchantment => enchantment.Type.HasFlag(EnchantmentTypeFlags.SecondAtt) && enchantment.StatKey == (uint)vitalId)
                .GroupBy(enchantment => enchantment.Category)
                .Select(category => {
                    return category
                        .OrderByDescending(enchantment => enchantment.Power)
                        .ThenByDescending(enchantment => Level8AuraSelfSpells.Contains(enchantment.SpellId))
                        .ThenByDescending(c => SetSpells.Contains(c.SpellId) ? c.SpellId : c.StartTime)
                        .First();
                }).ToList();
        }

        /// <summary>
        /// Get the enchantments additive modifier for the specified attribute based on the characters active enchantments
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetEnchantmentsAdditiveModifier(AttributeId type) {
            return GetActiveEnchantments(type)
                .Where(e => e.Type.HasFlag(EnchantmentTypeFlags.Additive))
                .Sum(e => (int)e.StatValue);
        }

        /// <summary>
        /// Get the enchantments additive modifier for the specified skill based on the characters active enchantments
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetEnchantmentsAdditiveModifier(SkillId type) {
            return GetActiveEnchantments(type)
                .Where(e => e.Type.HasFlag(EnchantmentTypeFlags.Additive))
                .Sum(e => (int)e.StatValue);
        }

        /// <summary>
        /// Get the enchantments additive modifier for the specified vital based on the characters active enchantments
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetEnchantmentsAdditiveModifier(VitalId type) {
            return GetActiveEnchantments(type)
                .Where(e => e.Type.HasFlag(EnchantmentTypeFlags.Additive))
                .Sum(e => (int)e.StatValue);
        }

        /// <summary>
        /// Get the enchantments multiplier modifier for the specified attribute based on the characters active enchantments
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public float GetEnchantmentsMultiplierModifier(AttributeId type) {
            var multiplier = 1.0f;
            foreach (var enchantment in GetActiveEnchantments(type).Where(e => e.Type.HasFlag(EnchantmentTypeFlags.Multiplicative))) {
                multiplier *= enchantment.StatValue;
            }

            return multiplier;
        }

        /// <summary>
        /// Get the enchantments multiplier modifier for the specified skill based on the characters active enchantments
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public float GetEnchantmentsMultiplierModifier(SkillId type) {
            var multiplier = 1.0f;
            foreach (var enchantment in GetActiveEnchantments(type).Where(e => e.Type.HasFlag(EnchantmentTypeFlags.Multiplicative))) {
                multiplier *= enchantment.StatValue;
            }

            return multiplier;
        }

        /// <summary>
        /// Get the enchantments multiplier modifier for the specified vital based on the characters active enchantments
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public float GetEnchantmentsMultiplierModifier(VitalId type) {
            var multiplier = 1.0f;
            foreach (var enchantment in GetActiveEnchantments(type).Where(e => e.Type.HasFlag(EnchantmentTypeFlags.Multiplicative))) {
                multiplier *= enchantment.StatValue;
            }

            return multiplier;
        }
        #endregion // Public API

        private void OnCombat_HandlePlayerDeathEvent(object? sender, Combat_HandlePlayerDeathEvent e) {
            if (e.KilledId == Id) {
                _OnDeath?.Invoke(this, new DeathEventArgs(e.Message, e.KillerId));
            }
        }

        #region Event Handlers
        private void OnLogin_SendEnterWorld(object? sender, Login_SendEnterWorld e) {
            Id = e.CharacterId;
        }

        private void OnLogin_PlayerDescription(object? sender, Login_PlayerDescription e) {
            Options1 = e.PlayerModule.Options;

            if (e.BaseQualities.Flags.HasFlag(ACBaseQualitiesFlags.PropertyInt)) {
                UpdateStatsTable(e.BaseQualities.IntProperties);
            }
            if (e.BaseQualities.Flags.HasFlag(ACBaseQualitiesFlags.PropertyInt64)) {
                UpdateStatsTable(e.BaseQualities.Int64Properties);
            }
            if (e.BaseQualities.Flags.HasFlag(ACBaseQualitiesFlags.PropertyBool)) {
                UpdateStatsTable(e.BaseQualities.BoolProperties);
            }
            if (e.BaseQualities.Flags.HasFlag(ACBaseQualitiesFlags.PropertyFloat)) {
                UpdateStatsTable(e.BaseQualities.FloatProperties);
            }
            if (e.BaseQualities.Flags.HasFlag(ACBaseQualitiesFlags.PropertyString)) {
                UpdateStatsTable(e.BaseQualities.StringProperties);
            }
            if (e.BaseQualities.Flags.HasFlag(ACBaseQualitiesFlags.PropertyDataId)) {
                UpdateStatsTable(e.BaseQualities.DataProperties);
            }
            if (e.BaseQualities.Flags.HasFlag(ACBaseQualitiesFlags.PropertyInstanceId)) {
                UpdateStatsTable(e.BaseQualities.InstanceProperties);
            }
            if (e.BaseQualities.Flags.HasFlag(ACBaseQualitiesFlags.PropertyPosition)) {
                UpdateStatsTable(e.BaseQualities.PositionProperties);
            }


            if (e.Qualities.Flags.HasFlag(ACQualitiesFlags.Attributes)) {
                UpdateAttribute(AttributeId.Coordination, e.Qualities.Attributes.Coordination);
                UpdateAttribute(AttributeId.Endurance, e.Qualities.Attributes.Endurance);
                UpdateAttribute(AttributeId.Focus, e.Qualities.Attributes.Focus);
                UpdateAttribute(AttributeId.Quickness, e.Qualities.Attributes.Quickness);
                UpdateAttribute(AttributeId.Self, e.Qualities.Attributes.Self);
                UpdateAttribute(AttributeId.Strength, e.Qualities.Attributes.Strength);

                UpdateVital(VitalId.Health, e.Qualities.Attributes.Health, true);
                UpdateVital(VitalId.Mana, e.Qualities.Attributes.Mana, true);
                UpdateVital(VitalId.Stamina, e.Qualities.Attributes.Stamina, true);
            }

            if (e.Qualities.Flags.HasFlag(ACQualitiesFlags.Skills)) {
                foreach (var kv in e.Qualities.Skills) {
                    UpdateSkill(kv.Key, kv.Value);
                }
            }

            if (e.Qualities.Flags.HasFlag(ACQualitiesFlags.Enchantments)) {
                var enchantmentRegistry = e.Qualities.Enchantments;
                if (enchantmentRegistry.Flags.HasFlag(EnchantmentRegistryFlags.LifeSpells)) {
                    foreach (var enchantment in enchantmentRegistry.LifeSpells) {
                        ApplyEnchantment(enchantment);
                    }
                }
                if (enchantmentRegistry.Flags.HasFlag(EnchantmentRegistryFlags.CreatureSpells)) {
                    foreach (var enchantment in enchantmentRegistry.CreatureSpells) {
                        ApplyEnchantment(enchantment);
                    }
                }
                if (enchantmentRegistry.Flags.HasFlag(EnchantmentRegistryFlags.Vitae)) {
                    ApplyEnchantment(enchantmentRegistry.Vitae);
                }
                if (enchantmentRegistry.Flags.HasFlag(EnchantmentRegistryFlags.Cooldowns)) {
                    foreach (var enchantment in enchantmentRegistry.Cooldowns) {
                        ApplyEnchantment(enchantment);
                    }
                }
            }
        }

        private void OnLogin_LogOffCharacter(object? sender, Chorizite.ACProtocol.Messages.S2C.Login_LogOffCharacter e) {
            Clear();
        }

        private void OnItem_SetState(object? sender, Item_SetState e) {
            if (e.ObjectId == Id && !e.NewState.HasFlag(PhysicsState.Hidden)) {
                InPortalSpace = false;
                _OnPortalSpaceExited?.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnEffects_PlayerTeleport(object? sender, Effects_PlayerTeleport e) {
            InPortalSpace = true;
            _OnPortalSpaceEntered?.Invoke(this, EventArgs.Empty);
        }

        private void OnQualities_PrivateUpdatePosition(object? sender, Qualities_PrivateUpdatePosition e) {
            AddOrUpdateValue(e.Key, e.Value);
        }

        private void OnQualities_PrivateRemovePositionEvent(object? sender, Qualities_PrivateRemovePositionEvent e) {
            RemoveValue(e.Type);
        }

        private void OnQualities_PrivateUpdateSkill(object? sender, Qualities_PrivateUpdateSkill e) {
            UpdateSkill(e.Key, e.Value);
        }

        private void OnQualities_PrivateUpdateSkillLevel(object? sender, Qualities_PrivateUpdateSkillLevel e) {
            UpdateSkillPointsRaised(e.Key, e.Value);
        }

        private void OnQualities_PrivateUpdateSkillAC(object? sender, Qualities_PrivateUpdateSkillAC e) {
            UpdateSkillTraining(e.Key, e.Value);
        }

        private void OnQualities_PrivateUpdateAttribute(object? sender, Qualities_PrivateUpdateAttribute e) {
            UpdateAttribute(e.Key, e.Value);
        }
        private void OnQualities_PrivateUpdateAttributeLevel(object? sender, Qualities_PrivateUpdateAttributeLevel e) {
            UpdateAttributePointsRaised(e.Key, e.Value);
        }

        private void OnQualities_PrivateUpdateAttribute2nd(object? sender, Qualities_PrivateUpdateAttribute2nd e) {
            UpdateVital(e.Key, e.Value);
        }

        private void OnQualities_PrivateUpdateAttribute2ndLevel(object? sender, Qualities_PrivateUpdateAttribute2ndLevel e) {
            UpdateVitalCurrent((VitalId)e.Key, e.Value);
        }

        private void OnQualities_PrivateUpdateDataId(object? sender, Qualities_PrivateUpdateDataId e) {
            AddOrUpdateValue(e.Key, e.Value);
        }

        private void OnQualities_PrivateRemoveDataIdEvent(object? sender, Qualities_PrivateRemoveDataIdEvent e) {
            RemoveValue(e.Type);
        }

        private void OnQualities_PrivateUpdateInstanceId(object? sender, Qualities_PrivateUpdateInstanceId e) {
            AddOrUpdateValue(e.Key, e.Value);
        }

        private void OnQualities_PrivateRemoveInstanceIdEvent(object? sender, Qualities_PrivateRemoveInstanceIdEvent e) {
            RemoveValue(e.Type);
        }

        private void OnQualities_PrivateUpdateString(object? sender, Qualities_PrivateUpdateString e) {
            AddOrUpdateValue(e.Key, e.Value);
        }

        private void OnQualities_PrivateRemoveStringEvent(object? sender, Qualities_PrivateRemoveStringEvent e) {
            RemoveValue(e.Type);
        }

        private void OnQualities_PrivateUpdateFloat(object? sender, Qualities_PrivateUpdateFloat e) {
            AddOrUpdateValue(e.Key, e.Value);
        }

        private void OnQualities_PrivateRemoveFloatEvent(object? sender, Qualities_PrivateRemoveFloatEvent e) {
            RemoveValue(e.Type);
        }

        private void OnQualities_PrivateUpdateInt64(object? sender, Qualities_PrivateUpdateInt64 e) {
            AddOrUpdateValue(e.Key, e.Value);
        }

        private void OnQualities_PrivateRemoveInt64Event(object? sender, Qualities_PrivateRemoveInt64Event e) {
            RemoveValue(e.Type);
        }

        private void OnQualities_PrivateUpdateInt(object? sender, Qualities_PrivateUpdateInt e) {
            AddOrUpdateValue(e.Key, e.Value);
        }

        private void OnQualities_PrivateRemoveIntEvent(object? sender, Qualities_PrivateRemoveIntEvent e) {
            RemoveValue(e.Type);
        }

        private void OnQualities_PrivateUpdateBool(object? sender, Qualities_PrivateUpdateBool e) {
            AddOrUpdateValue(e.Key, e.Value);
        }

        private void OnQualities_PrivateRemoveBoolEvent(object? sender, Qualities_PrivateRemoveBoolEvent e) {
            RemoveValue(e.Type);
        }

        private void OnMagic_UpdateMultipleEnchantments(object? sender, Magic_UpdateMultipleEnchantments e) {
            foreach (var enchantment in e.Enchantments) {
                ApplyEnchantment(enchantment);
            }
        }

        private void OnMagic_UpdateEnchantment(object? sender, Magic_UpdateEnchantment e) {
            ApplyEnchantment(e.Enchantment);
        }

        private void OnMagic_RemoveMultipleEnchantments(object? sender, Magic_RemoveMultipleEnchantments e) {
            foreach (var enchantment in e.Enchantments) {
                RemoveEnchantment(enchantment);
            }
        }

        private void OnMagic_RemoveEnchantment(object? sender, Magic_RemoveEnchantment e) {
            RemoveEnchantment(e.SpellId);
        }

        private void OnMagic_PurgeEnchantmentst(object? sender, Magic_PurgeEnchantments e) {
            var enchantments = AllEnchantments.Values.ToArray();
            foreach (var enchantment in enchantments) {
                if (enchantment.Duration > 0) {
                    RemoveEnchantment(enchantment.LayeredId);
                }
            }
        }

        private void OnMagic_PurgeBadEnchantments(object? sender, Magic_PurgeBadEnchantments e) {
            var enchantments = AllEnchantments.Values.ToArray();
            foreach (var enchantment in enchantments) {
                if (enchantment.Duration > 0 && enchantment.StatValue < 0) {
                    RemoveEnchantment(enchantment.LayeredId);
                }
            }
        }

        private void OnMagic_DispelMultipleEnchantments(object? sender, Magic_DispelMultipleEnchantments e) {
            foreach (var layeredId in e.Enchantments) {
                RemoveEnchantment(layeredId);
            }
        }

        private void OnMagic_DispelEnchantment(object? sender, Magic_DispelEnchantment e) {
            RemoveEnchantment(e.SpellId);
        }
        #endregion // Event Handlers

        internal void ApplyEnchantment(Chorizite.ACProtocol.Types.Enchantment enchantment) {
            if (enchantment.Id.Id == VITAE_SPELL_ID) {
                Vitae = enchantment.StatMod.Value;
                return;
            }

            if (enchantment.StatMod.Type.HasFlag(EnchantmentTypeFlags.Cooldown)) {
                var cooldown = SharedCooldown.FromMessage(enchantment);
                if (SharedCooldowns.ContainsKey(enchantment.Id)) {
                    SharedCooldowns[enchantment.Id] = cooldown;
                }
                else {
                    SharedCooldowns.Add(enchantment.Id, cooldown);
                }
                _OnSharedCooldownChanged?.Invoke(this, new SharedCooldownsChangedEventArgs(AddRemoveEventType.Added, cooldown));
            }
            else {
                var en = Enchantment.FromMessage(enchantment);
                if (AllEnchantments.ContainsKey(enchantment.Id)) {
                    AllEnchantments[enchantment.Id] = en;
                }
                else {
                    AllEnchantments.Add(enchantment.Id, en);
                }
                _OnEnchantmentChanged?.Invoke(this, new EnchantmentsChangedEventArgs(AddRemoveEventType.Added, en));
            }
        }

        internal void RemoveEnchantment(LayeredSpellId layeredSpellId) {
            if (layeredSpellId.Id == VITAE_SPELL_ID) {
                Vitae = 1;
                return;
            }

            if (AllEnchantments.Remove(layeredSpellId, out var enchantment)) {
                _OnEnchantmentChanged?.Invoke(this, new EnchantmentsChangedEventArgs(AddRemoveEventType.Removed, enchantment));
            }

            if (SharedCooldowns.Remove(layeredSpellId, out var cooldown)) {
                _OnSharedCooldownChanged?.Invoke(this, new SharedCooldownsChangedEventArgs(AddRemoveEventType.Removed, cooldown));
            }
        }

        internal SkillInfo AddOrCreateSkill(SkillId key) {
            if (!Skills.TryGetValue(key, out var skill)) {
                skill = new SkillInfo(key, this);
                Skills.Add(key, skill);
            }

            return skill;
        }

        internal void UpdateSkill(SkillId key, Skill value) {
            if (value == null)
                return;
            SkillInfo skill = AddOrCreateSkill(key);

            skill.AdjustXP = value.AdjustPP;
            skill.InitLevel = value.InnatePoints;
            skill.LastUsedTime = (float)value.LastUsedTime;
            skill.PointsRaised = value.PointsRaised;
            skill.ResistanceOfLastCheck = value.ResistanceOfLastCheck;
            skill.Training = value.TrainingLevel;
            skill.Type = key;
            skill.Experience = value.ExperienceSpent;
        }

        internal AttributeInfo AddOrCreateAttribute(AttributeId key) {
            if (!Attributes.TryGetValue(key, out var attribute)) {
                attribute = new AttributeInfo(key, this);
                Attributes.Add(key, attribute);
            }

            return attribute;
        }

        internal void UpdateAttribute(AttributeId key, Chorizite.ACProtocol.Types.AttributeInfo value) {
            var attribute = AddOrCreateAttribute(key);
            attribute.InnatePoints = value.InnatePoints;
            attribute.PointsRaised = value.PointsRaised;
            attribute.Experience = value.ExperienceSpent;
        }

        internal void UpdateAttributePointsRaised(AttributeId key, uint value) {
            AttributeInfo attribute = AddOrCreateAttribute(key);
            attribute.PointsRaised = value;
        }

        private VitalInfo AddOrCreateVital(VitalId key) {
            if (((int)key % 2) == 0)
                key -= 1;

            if (!Vitals.TryGetValue(key, out var vital)) {
                vital = new VitalInfo(key, this);
                Vitals.Add(key, vital);
            }

            return vital;
        }

        internal void UpdateVital(VitalId key, SecondaryAttributeInfo value, bool isInitialUpdate = true) {
            if (value == null)
                return;
            VitalInfo vital = AddOrCreateVital(key);
            vital.InitLevel = value.Attribute.InnatePoints;
            vital.PointsRaised = value.Attribute.PointsRaised;
            vital.Experience = value.Attribute.ExperienceSpent;

            if ((int)value.Current != vital.Current && (isInitialUpdate || ((int)key % 2) == 0)) {
                key -= 1;
                var old = vital.Current;
                vital.Current = (int)value.Current;
                if (!isInitialUpdate) {
                    _OnVitalChanged?.Invoke(this, new VitalChangedEventArgs(key, vital.Current, old));
                }
            }
        }

        internal void UpdateVitalPointsRaised(VitalId key, uint value) {
            VitalInfo vital = AddOrCreateVital(key);
            vital.PointsRaised = value;
        }

        internal void UpdateVitalCurrent(VitalId key, uint value) {
            VitalInfo vital = AddOrCreateVital(key);

            if ((int)value != vital.Current && ((int)key % 2) == 0) {
                key -= 1;
                var old = vital.Current;
                vital.Current = (int)value;
                _OnVitalChanged?.Invoke(this, new VitalChangedEventArgs(key, vital.Current, old));
            }
        }

        internal void UpdateSkillTraining(SkillId key, SkillAdvancementClass value) {
            SkillInfo skill = AddOrCreateSkill(key);
            skill.Training = value;
        }

        internal void UpdateSkillPointsRaised(SkillId key, uint value) {
            SkillInfo skill = AddOrCreateSkill(key);
            skill.PointsRaised = value;
        }

        internal void SetWielded(WorldObject weenie, EquipMask slot) {
            weenie.AddOrUpdateValue(PropertyInstanceId.Wielder, CoreACPlugin.Instance.Game.Character.Id);
            weenie.AddOrUpdateValue(PropertyInt.CurrentWieldedLocation, (int)slot);

            //Equipment.Add(weenie);
        }

        private void Clear() {
            Id = 0;
            Options1 = 0;
            Vitae = 1f;

            Skills.Clear();
            Attributes.Clear();
            Vitals.Clear();

            IntValues.Clear();
            Int64Values.Clear();
            BoolValues.Clear();
            FloatValues.Clear();
            StringValues.Clear();
            InstanceValues.Clear();
            DataValues.Clear();

            SharedCooldowns.Clear();
            AllEnchantments.Clear();
        }

        public void Dispose() {
            _net.C2S.OnLogin_SendEnterWorld -= OnLogin_SendEnterWorld;
            _net.S2C.OnLogin_PlayerDescription -= OnLogin_PlayerDescription;
            _net.S2C.OnLogin_LogOffCharacter -= OnLogin_LogOffCharacter;

            _net.S2C.OnEffects_PlayerTeleport -= OnEffects_PlayerTeleport;
            _net.S2C.OnItem_SetState -= OnItem_SetState;

            _net.S2C.OnCombat_HandlePlayerDeathEvent -= OnCombat_HandlePlayerDeathEvent;

            _net.S2C.OnQualities_PrivateRemoveBoolEvent -= OnQualities_PrivateRemoveBoolEvent;
            _net.S2C.OnQualities_PrivateUpdateBool -= OnQualities_PrivateUpdateBool;
            _net.S2C.OnQualities_PrivateRemoveIntEvent -= OnQualities_PrivateRemoveIntEvent;
            _net.S2C.OnQualities_PrivateUpdateInt -= OnQualities_PrivateUpdateInt;
            _net.S2C.OnQualities_PrivateRemoveInt64Event -= OnQualities_PrivateRemoveInt64Event;
            _net.S2C.OnQualities_PrivateUpdateInt64 -= OnQualities_PrivateUpdateInt64;
            _net.S2C.OnQualities_PrivateRemoveFloatEvent -= OnQualities_PrivateRemoveFloatEvent;
            _net.S2C.OnQualities_PrivateUpdateFloat -= OnQualities_PrivateUpdateFloat;
            _net.S2C.OnQualities_PrivateRemoveStringEvent -= OnQualities_PrivateRemoveStringEvent;
            _net.S2C.OnQualities_PrivateUpdateString -= OnQualities_PrivateUpdateString;
            _net.S2C.OnQualities_PrivateRemoveInstanceIdEvent -= OnQualities_PrivateRemoveInstanceIdEvent;
            _net.S2C.OnQualities_PrivateUpdateInstanceId -= OnQualities_PrivateUpdateInstanceId;
            _net.S2C.OnQualities_PrivateRemoveDataIdEvent -= OnQualities_PrivateRemoveDataIdEvent;
            _net.S2C.OnQualities_PrivateUpdateDataId -= OnQualities_PrivateUpdateDataId;
            _net.S2C.OnQualities_PrivateUpdateAttribute2ndLevel -= OnQualities_PrivateUpdateAttribute2ndLevel;
            _net.S2C.OnQualities_PrivateUpdateAttribute2nd -= OnQualities_PrivateUpdateAttribute2nd;
            _net.S2C.OnQualities_PrivateUpdateAttributeLevel -= OnQualities_PrivateUpdateAttributeLevel;
            _net.S2C.OnQualities_PrivateUpdateAttribute -= OnQualities_PrivateUpdateAttribute;
            _net.S2C.OnQualities_PrivateUpdateSkillAC -= OnQualities_PrivateUpdateSkillAC;
            _net.S2C.OnQualities_PrivateUpdateSkillLevel -= OnQualities_PrivateUpdateSkillLevel;
            _net.S2C.OnQualities_PrivateUpdateSkill -= OnQualities_PrivateUpdateSkill;
            _net.S2C.OnQualities_PrivateRemovePositionEvent -= OnQualities_PrivateRemovePositionEvent;
            _net.S2C.OnQualities_PrivateUpdatePosition -= OnQualities_PrivateUpdatePosition;

            _net.S2C.OnMagic_DispelEnchantment -= OnMagic_DispelEnchantment;
            _net.S2C.OnMagic_DispelMultipleEnchantments -= OnMagic_DispelMultipleEnchantments;
            _net.S2C.OnMagic_PurgeBadEnchantments -= OnMagic_PurgeBadEnchantments;
            _net.S2C.OnMagic_PurgeEnchantments -= OnMagic_PurgeEnchantmentst;
            _net.S2C.OnMagic_RemoveEnchantment -= OnMagic_RemoveEnchantment;
            _net.S2C.OnMagic_RemoveMultipleEnchantments -= OnMagic_RemoveMultipleEnchantments;
            _net.S2C.OnMagic_UpdateEnchantment -= OnMagic_UpdateEnchantment;
            _net.S2C.OnMagic_UpdateMultipleEnchantments -= OnMagic_UpdateMultipleEnchantments;
        }
    }
}