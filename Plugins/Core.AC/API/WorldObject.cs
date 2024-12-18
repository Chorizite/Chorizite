using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Types;
using Chorizite.Common.Enums;
using Core.AC.API.WorldObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using XLua.Cast;

namespace Core.AC.API {
    [JsonDerivedType(typeof(WorldObject), typeDiscriminator: "WorldObject")]
    [JsonDerivedType(typeof(Character), typeDiscriminator: "Character")]
    [JsonDerivedType(typeof(Container), typeDiscriminator: "Container")]
    [JsonDerivedType(typeof(Creature), typeDiscriminator: "Creature")]
    [JsonDerivedType(typeof(Equipment), typeDiscriminator: "Equipment")]
    [JsonDerivedType(typeof(NPC), typeDiscriminator: "NPC")]
    [JsonDerivedType(typeof(Player), typeDiscriminator: "Player")]
    public class WorldObject {
        private ObjectClass _objectClass;

        /// <summary>
        /// The id of this world object
        /// </summary>
        public uint Id { get; set; }
        
        /// <summary>
        /// Weenie ClassId
        /// </summary>
        public uint ClassId { get; set; }

        /// <summary>
        /// The parent container, if any
        /// </summary>
        [JsonIgnore]
        public Container? ParentContainer => CoreACPlugin.Instance.Game.World.Get(Value(PropertyInstanceId.Container)) as Container;

        /// <summary>
        /// Icon effects, like border highlights
        /// </summary>
        [JsonIgnore]
        public UiEffects UIEffects => (UiEffects)Value(PropertyDataId.IconOverlaySecondary);

        /// <summary>
        /// Burden
        /// </summary>
        [JsonIgnore]
        public int Burden => Value(PropertyInt.EncumbranceVal);

        /// <summary>
        /// The name of this weenie object.
        /// </summary>
        [JsonIgnore]
        public string Name => Value(PropertyString.Name);

        /// <summary>
        /// The date this weenie was created at, in memory.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Wether or not this weenie has appraisal data from the server.
        /// </summary>
        public bool HasAppraisalData { get; set; }

        /// <summary>
        /// The last time we got appraisal data from the server
        /// </summary>
        public DateTime LastAppraisalTime { get; set; } = DateTime.MinValue;

        /// <summary>
        /// A dictionary of all int property values. Unless you are looping these, you should use <see cref="Value(PropertyInt, int)"/> instead.
        /// </summary>
        public Dictionary<PropertyInt, int> IntValues { get; set; } = [];

        /// <summary>
        /// A dictionary of all int64 property values. Unless you are looping these, you should use <see cref="Value(PropertyInt64, long)"/> instead.
        /// </summary>
        public Dictionary<PropertyInt64, long> Int64Values { get; set; } = [];

        /// <summary>
        /// A dictionary of all string property values. Unless you are looping these, you should use <see cref="Value(PropertyString, string)"/> instead.
        /// </summary>
        public Dictionary<PropertyString, string> StringValues { get; set; } = [];

        /// <summary>
        /// A dictionary of all bool property values. Unless you are looping these, you should use <see cref="Value(PropertyBool, bool)"/> instead.
        /// </summary>
        public Dictionary<PropertyBool, bool> BoolValues { get; set; } = [];

        /// <summary>
        /// A dictionary of all float property values. Unless you are looping these, you should use <see cref="Value(PropertyFloat, float)"/> instead.
        /// </summary>
        public Dictionary<PropertyFloat, float> FloatValues { get; set; } = [];

        /// <summary>
        /// A dictionary of all instance id property values. These ids refer to ingame objects. Unless you are looping these, you should use <see cref="Value(PropertyInstanceId, uint)"/> instead.
        /// </summary>
        public Dictionary<PropertyInstanceId, uint> InstanceValues { get; set; } = [];

        /// <summary>
        /// A dictionary of all data id property values. These ids refer to dat DBObj file entries. Unless you are looping these, you should use <see cref="Value(PropertyDataId, uint)"/> instead.
        /// </summary>
        public Dictionary<PropertyDataId, uint> DataValues { get; set; } = [];

        /// <summary>
        /// A dictionary of all position property values. Unless you are looping these, you should use <see cref="Value(PropertyPosition, uint)"/> instead.
        /// </summary>
        public Dictionary<PropertyPosition, Position> PositionValues { get; set; } = [];

        /// <summary>
        /// A list of spells this item casts.
        /// </summary>
        public List<LayeredSpellId> SpellIds { get; set; } = [];

        /// <summary>
        /// A list of active enchantments on this item.
        /// </summary>
        public List<LayeredSpellId> EnchantmentIds { get; set; } = [];

        /// <summary>
        /// Type of item this is
        /// </summary>
        [JsonIgnore]
        public ItemType ItemType => (ItemType)Value(PropertyInt.ItemType);

        /// <summary>
        /// Object description
        /// </summary>
        public ObjectDescriptionFlag Behavior { get; set; }

        /// <summary>
        /// The id of the spell this item casts, if any
        /// </summary>
        public uint SpellId { get; set; }
        
        /// <summary>
        /// Object description that was used to create this weenie
        /// </summary>
        public ObjDesc ObjectDescription { get; set; } = new();

        /// <summary>
        /// Physics description that was used to create this weenie
        /// </summary>
        public PhysicsDesc PhysicsDesc { get; set; } = new();

        /// <summary>
        /// Weenie description that was used to create this weenie
        /// </summary>
        public PublicWeenieDesc WeenieDescription { get; set; } = new();

        public DateTime LastAccessTime { get; set; }

        /// <summary>
        /// ObjectClass, for decal compatibility / familiarity (also a bit more granular than ObjectType)
        /// </summary>
        [JsonIgnore]
        public ObjectClass ObjectClass {
            get {
                if (_objectClass == ObjectClass.Unknown) {
                    _objectClass = GetObjectClass(ItemType, Behavior, WeenieDescription.Header);
                }

                return _objectClass;
            }
        }

        /// <summary>
        /// True if this object is stackable
        /// </summary>b
        public bool IsStackable => Value(PropertyInt.MaxStackSize) != 0;

        /// <summary>
        /// True if this object is attuned to your character. (Can't be dropped / given to others)
        /// </summary>
        public bool IsAttuned => Value(PropertyInt.Attuned) != 0;
        #region Public API


        /// <summary>
        /// Check if this weenie has the specified PropertyInt defined.
        /// </summary>
        /// <param name="key">The PropertyInt to check</param>
        /// <returns>true if set, false if not set</returns>
        public bool HasValue(PropertyInt key) {
            return IntValues.ContainsKey(key);
        }

        /// <summary>
        /// Check if this weenie has the specified PropertyInt64 defined.
        /// </summary>
        /// <param name="key">The PropertyInt64 to check</param>
        /// <returns>true if set, false if not set</returns>
        public bool HasValue(PropertyInt64 key) {
            return Int64Values.ContainsKey(key);
        }

        /// <summary>
        /// Check if this weenie has the specified PropertyString defined.
        /// </summary>
        /// <param name="key">The PropertyString to check</param>
        /// <returns>true if set, false if not set</returns>
        public bool HasValue(PropertyString key) {
            return StringValues.ContainsKey(key);
        }

        /// <summary>
        /// Check if this weenie has the specified PropertyBool defined.
        /// </summary>
        /// <param name="key">The PropertyBool to check</param>
        /// <returns>true if set, false if not set</returns>
        public bool HasValue(PropertyBool  key) {
            return BoolValues.ContainsKey(key);
        }

        /// <summary>
        /// Check if this weenie has the specified PropertyFloat defined.
        /// </summary>
        /// <param name="key">The PropertyFloat to check</param>
        /// <returns>true if set, false if not set</returns>
        public bool HasValue(PropertyFloat  key) {
            return FloatValues.ContainsKey(key);
        }

        /// <summary>
        /// Check if this weenie has the specified PropertyInstanceId defined.
        /// </summary>
        /// <param name="key">The PropertyInstanceId to check</param>
        /// <returns>true if set, false if not set</returns>
        public bool HasValue(PropertyInstanceId key) {
            return InstanceValues.ContainsKey(key);
        }

        /// <summary>
        /// Check if this weenie has the specified PropertyDataId defined.
        /// </summary>
        /// <param name="key">The PropertyDataId to check</param>
        /// <returns>true if set, false if not set</returns>
        public bool HasValue(PropertyDataId key) {
            return DataValues.ContainsKey(key);
        }

        /// <summary>
        /// Check if this weenie has the specified PropertyPosition defined.
        /// </summary>
        /// <param name="key">The PropertyPosition to check</param>
        /// <returns>true if set, false if not set</returns>
        public bool HasValue(PropertyPosition key) {
            return PositionValues.ContainsKey(key);
        }

        /// <summary>
        /// Gets the value of the specified PropertyInt if it exists, or returns a default value.
        /// </summary>
        /// <param name="key">The PropertyInt value to get</param>
        /// <param name="default">The default value to return if no PropertyInt is defined</param>
        /// <returns>The value of the specified PropertyInt key, otherwise returns the specified default</returns>
        public int Value(PropertyInt key, int @default = 0) {
            if (IntValues.TryGetValue(key, out int value)) {
                return value;
            }

            return @default;
        }

        /// <summary>
        /// Gets the value of the specified PropertyInt64 if it exists, or returns a default value.
        /// </summary>
        /// <param name="key">The PropertyInt64 value to get</param>
        /// <param name="default">The default value to return if no PropertyInt64 is defined</param>
        /// <returns>The value of the specified PropertyInt64 key, otherwise returns the specified default</returns>
        public long Value(PropertyInt64 key, long @default = 0) {
            if (Int64Values.TryGetValue(key, out long value)) {
                return value;
            }

            return @default;
        }

        /// <summary>
        /// Gets the value of the specified PropertyString if it exists, or returns a default value.
        /// </summary>
        /// <param name="key">The PropertyString value to get</param>
        /// <param name="default">The default value to return if no PropertyString is defined</param>
        /// <returns>The value of the specified PropertyString key, otherwise returns the specified default</returns>
        public string Value(PropertyString key, string @default = "") {
            if (StringValues.TryGetValue(key, out var value)) {
                return value;
            }

            return @default;
        }

        /// <summary>
        /// Gets the value of the specified PropertyBool if it exists, or returns a default value.
        /// </summary>
        /// <param name="key">The PropertyBool value to get</param>
        /// <param name="default">The default value to return if no PropertyBool is defined</param>
        /// <returns>The value of the specified PropertyBool key, otherwise returns the specified default</returns>
        public bool Value(PropertyBool  key, bool @default = false) {
            if (BoolValues.TryGetValue(key, out bool value)) {
                return value;
            }

            return @default;
        }

        /// <summary>
        /// Gets the value of the specified PropertyFloat if it exists, or returns a default value.
        /// </summary>
        /// <param name="key">The PropertyFloat value to get</param>
        /// <param name="default">The default value to return if no PropertyFloat is defined</param>
        /// <returns>The value of the specified PropertyFloat key, otherwise returns the specified default</returns>
        public float Value(PropertyFloat  key, float @default = 0f) {
            if (FloatValues.TryGetValue(key, out float value)) {
                return value;
            }

            return @default;
        }

        /// <summary>
        /// Gets the value of the specified PropertyInstanceId if it exists, or returns a default value.
        /// </summary>
        /// <param name="key">The PropertyInstanceId value to get</param>
        /// <param name="default">The default value to return if no PropertyInstanceId is defined</param>
        /// <returns>The value of the specified PropertyInstanceId key, otherwise returns the specified default</returns>
        public uint Value(PropertyInstanceId key, uint @default = 0) {
            if (InstanceValues.TryGetValue(key, out uint value)) {
                return value;
            }

            return @default;
        }

        /// <summary>
        /// Gets the value of the specified PropertyDataId if it exists, or returns a default value.
        /// </summary>
        /// <param name="key">The PropertyDataId value to get</param>
        /// <param name="default">The default value to return if no PropertyDataId is defined</param>
        /// <returns>The value of the specified PropertyDataId key, otherwise returns the specified default</returns>
        public uint Value(PropertyDataId key, uint @default = 0) {
            if (DataValues.TryGetValue(key, out uint value)) {
                return value;
            }

            return @default;
        }

        /// <summary>
        /// Gets the value of the specified PropertyPosition if it exists, or returns a default value.
        /// </summary>
        /// <param name="key">The PropertyPosition value to get</param>
        /// <param name="default">The default value to return if no PropertyPosition is defined</param>
        /// <returns>The value of the specified PropertyPosition key, otherwise returns the specified default</returns>
        public Position Value(PropertyPosition key, Position? position = null) {
            if (PositionValues.TryGetValue(key, out var value)) {
                return value;
            }

            return position;
        }
        #endregion // Public API

        internal static ObjectClass GetObjectClass(ItemType itemType, ObjectDescriptionFlag objDescFlags, WeenieHeaderFlag createFlags) {
            ObjectClass objectClass = ObjectClass.Unknown;

            if (itemType.HasFlag(ItemType.MeleeWeapon)) objectClass = ObjectClass.MeleeWeapon;
            else if (itemType.HasFlag(ItemType.Armor)) objectClass = ObjectClass.Armor;
            else if (itemType.HasFlag(ItemType.Clothing)) objectClass = ObjectClass.Clothing;
            else if (itemType.HasFlag(ItemType.Jewelry)) objectClass = ObjectClass.Jewelry;
            else if (itemType.HasFlag(ItemType.Creature)) objectClass = ObjectClass.Monster;
            else if (itemType.HasFlag(ItemType.Food)) objectClass = ObjectClass.Food;
            else if (itemType.HasFlag(ItemType.Money)) objectClass = ObjectClass.Money;
            else if (itemType.HasFlag(ItemType.Misc)) objectClass = ObjectClass.Misc;
            else if (itemType.HasFlag(ItemType.MissileWeapon)) objectClass = ObjectClass.MissileWeapon;
            else if (itemType.HasFlag(ItemType.Container)) objectClass = ObjectClass.Container;
            else if (itemType.HasFlag(ItemType.Useless)) objectClass = ObjectClass.Bundle;
            else if (itemType.HasFlag(ItemType.Gem)) objectClass = ObjectClass.Gem;
            else if (itemType.HasFlag(ItemType.SpellComponents)) objectClass = ObjectClass.SpellComponent;
            else if (itemType.HasFlag(ItemType.Key)) objectClass = ObjectClass.Key;
            else if (itemType.HasFlag(ItemType.Caster)) objectClass = ObjectClass.WandStaffOrb;
            else if (itemType.HasFlag(ItemType.Portal)) objectClass = ObjectClass.Portal;
            else if (itemType.HasFlag(ItemType.PromissoryNote)) objectClass = ObjectClass.TradeNote;
            else if (itemType.HasFlag(ItemType.ManaStone)) objectClass = ObjectClass.ManaStone;
            else if (itemType.HasFlag(ItemType.Service)) objectClass = ObjectClass.Services;
            else if (itemType.HasFlag(ItemType.MagicWieldable)) objectClass = ObjectClass.Plant;
            else if (itemType.HasFlag(ItemType.CraftCookingBase)) objectClass = ObjectClass.BaseCooking;
            else if (itemType.HasFlag(ItemType.CraftAlchemyBase)) objectClass = ObjectClass.BaseAlchemy;
            else if (itemType.HasFlag(ItemType.CraftFletchingBase)) objectClass = ObjectClass.BaseFletching;
            else if (itemType.HasFlag(ItemType.CraftFletchingIntermediate)) objectClass = ObjectClass.CraftedFletching;
            else if (itemType.HasFlag(ItemType.TinkeringTool)) objectClass = ObjectClass.Ust;
            else if (itemType.HasFlag(ItemType.TinkeringMaterial)) objectClass = ObjectClass.Salvage;

            if (objDescFlags.HasFlag(ObjectDescriptionFlag.Player)) objectClass = ObjectClass.Player;
            else if (objDescFlags.HasFlag(ObjectDescriptionFlag.Vendor)) objectClass = ObjectClass.Vendor;
            else if (objDescFlags.HasFlag(ObjectDescriptionFlag.Door)) objectClass = ObjectClass.Door;
            else if (objDescFlags.HasFlag(ObjectDescriptionFlag.Corpse)) objectClass = ObjectClass.Corpse;
            else if (objDescFlags.HasFlag(ObjectDescriptionFlag.LifeStone)) objectClass = ObjectClass.Lifestone;
            else if (objDescFlags.HasFlag(ObjectDescriptionFlag.Food)) objectClass = ObjectClass.Food;
            else if (objDescFlags.HasFlag(ObjectDescriptionFlag.Healer)) objectClass = ObjectClass.HealingKit;
            else if (objDescFlags.HasFlag(ObjectDescriptionFlag.Lockpick)) objectClass = ObjectClass.Lockpick;
            else if (objDescFlags.HasFlag(ObjectDescriptionFlag.Portal)) objectClass = ObjectClass.Portal;
            else if (objDescFlags.HasFlag(ObjectDescriptionFlag.RequiresPackSlot)) objectClass = ObjectClass.Foci;
            else if (objDescFlags.HasFlag(ObjectDescriptionFlag.Openable)) objectClass = ObjectClass.Container;

            if (objectClass == ObjectClass.Unknown && itemType.HasFlag(ItemType.Writable) && objDescFlags.HasFlag(ObjectDescriptionFlag.Book)) {
                if (objDescFlags.HasFlag(ObjectDescriptionFlag.Inscribable)) objectClass = ObjectClass.Journal;
                else if (objDescFlags.HasFlag(ObjectDescriptionFlag.Stuck)) objectClass = ObjectClass.Sign;
                else if (objDescFlags.HasFlag(ObjectDescriptionFlag.Openable)) objectClass = ObjectClass.Book;
            }

            if (itemType.HasFlag(ItemType.Writable) && createFlags.HasFlag(WeenieHeaderFlag.Spell)) objectClass = ObjectClass.Scroll;

            if (objectClass == ObjectClass.Monster) {
                if (!objDescFlags.HasFlag(ObjectDescriptionFlag.Attackable)) objectClass = ObjectClass.Npc;
                if (objDescFlags.HasFlag(ObjectDescriptionFlag.IncludesSecondHeader)) objectClass = ObjectClass.Npc;
            }

            return objectClass;
        }

        #region Property Methods
        internal void UpdateStatsTable(Dictionary<PropertyInstanceId, uint> statsTable) {
            foreach (var kv in statsTable) {
                AddOrUpdateValue(kv.Key, kv.Value);
            }
        }

        internal void UpdateStatsTable(Dictionary<PropertyPosition, Position> didStatsTable) {
            foreach (var kv in didStatsTable) {
                AddOrUpdateValue(kv.Key, kv.Value);
            }
        }

        internal void UpdateStatsTable(Dictionary<PropertyBool, bool> didStatsTable) {
            foreach (var kv in didStatsTable) {
                AddOrUpdateValue(kv.Key, kv.Value);
            }
        }

        internal void UpdateStatsTable(Dictionary<PropertyFloat, double> didStatsTable) {
            foreach (var kv in didStatsTable) {
                AddOrUpdateValue(kv.Key, (float)kv.Value);
            }
        }

        internal void UpdateStatsTable(Dictionary<PropertyInt, int> didStatsTable) {
            foreach (var kv in didStatsTable) {
                AddOrUpdateValue(kv.Key, kv.Value);
            }
        }

        internal void UpdateStatsTable(Dictionary<PropertyInt64, long> didStatsTable) {
            foreach (var kv in didStatsTable) {
                AddOrUpdateValue(kv.Key, kv.Value);
            }
        }

        internal void UpdateStatsTable(Dictionary<PropertyString, string> didStatsTable) {
            foreach (var kv in didStatsTable) {
                AddOrUpdateValue(kv.Key, kv.Value);
            }
        }

        internal void UpdateStatsTable(Dictionary<PropertyDataId, uint> didStatsTable) {
            foreach (var kv in didStatsTable) {
                AddOrUpdateValue(kv.Key, kv.Value);
            }
        }

        internal void AddOrUpdateValue(PropertyInt key, int value) {
            if (!IntValues.TryAdd(key, value)) {
                IntValues[key] = value;
            }
        }

        internal void AddOrUpdateValue(PropertyInt64 key, long value) {
            if (!Int64Values.TryAdd(key, value)) {
                Int64Values[key] = value;
            }
        }

        internal void AddOrUpdateValue(PropertyFloat key, float value) {
            if (!FloatValues.TryAdd(key, value)) {
                FloatValues[key] = value;
            }
        }

        internal void AddOrUpdateValue(PropertyString key, string value) {
            if (!StringValues.TryAdd(key, value)) {
                StringValues[key] = value;
            }
        }

        internal void AddOrUpdateValue(PropertyBool key, bool value) {
            if (!BoolValues.TryAdd(key, value)) {
                BoolValues[key] = value;
            }
        }

        internal void AddOrUpdateValue(PropertyDataId key, uint value) {
            if (!DataValues.TryAdd(key, value)) {
                DataValues[key] = value;
            }
        }

        internal void AddOrUpdateValue(PropertyPosition key, Position value) {
            if (!PositionValues.TryAdd(key, value)) {
                PositionValues[key] = value;
            }
        }

        internal void AddOrUpdateValue(PropertyInstanceId key, uint value) {
            if (InstanceValues.TryGetValue(key, out uint oldValue) && oldValue == value) {
                return;
            }
            if (!InstanceValues.TryAdd(key, value)) {
                InstanceValues[key] = value;
            }
        }

        internal void RemoveValue(PropertyBool key) {
            BoolValues.Remove(key);
        }

        internal void RemoveValue(PropertyFloat key) {
            FloatValues.Remove(key);
        }

        internal void RemoveValue(PropertyInt key) {
            IntValues.Remove(key);
        }

        internal void RemoveValue(PropertyInt64 key) {
            Int64Values.Remove(key);
        }

        internal void RemoveValue(PropertyInstanceId key) {
            InstanceValues.Remove(key);
        }

        internal void RemoveValue(PropertyString key) {
            StringValues.Remove(key);
        }

        internal void RemoveValue(PropertyDataId key) {
            DataValues.Remove(key);
        }

        internal void RemoveValue(PropertyPosition key) {
            PositionValues.Remove(key);
        }
        #endregion // Property Methods

        internal void UpdateObjDesc(ObjDesc objDesc) {
            if (objDesc == null)
                return;
            ObjectDescription = objDesc;
        }

        internal void UpdatePhysicsDesc(PhysicsDesc physicsDesc) {
            if (physicsDesc == null)
                return;
            PhysicsDesc = physicsDesc;

            if ((physicsDesc.Flags & 0x00000020) != 0)
                AddOrUpdateValue(PropertyInstanceId.Wielder, physicsDesc.ParentId);
        }

        internal void UpdateWeenieDesc(PublicWeenieDesc wdesc) {
            if (wdesc == null)
                return;

            WeenieDescription = wdesc;

            ClassId = wdesc.WeenieClassId;
            Behavior = wdesc.Behavior;
            SpellId = wdesc.SpellId;
            AddOrUpdateValue(PropertyString.Name, wdesc.Name);
            AddOrUpdateValue(PropertyDataId.Icon, wdesc.Icon);
            AddOrUpdateValue(PropertyInt.ItemType, (int)wdesc.Type);

            var flag1 = wdesc.Header;
            var flag2 = wdesc.Header2;

            if ((flag1 & WeenieHeaderFlag.AmmoType) != 0)
                AddOrUpdateValue(PropertyInt.AmmoType, (int)wdesc.AmmunitionType);

            if ((flag1 & WeenieHeaderFlag.RadarBlipColor) != 0)
                AddOrUpdateValue(PropertyInt.RadarBlipColor, (int)wdesc.BlipColor);

            if ((flag1 & WeenieHeaderFlag.CombatUse) != 0)
                AddOrUpdateValue(PropertyInt.CombatUse, (int)wdesc.CombatUse);

            if ((flag1 & WeenieHeaderFlag.ContainersCapacity) != 0)
                AddOrUpdateValue(PropertyInt.ContainersCapacity, wdesc.ContainerCapacity);

            if ((flag1 & WeenieHeaderFlag.Container) != 0)
                AddOrUpdateValue(PropertyInstanceId.Container, wdesc.ContainerId);

            if ((flag2 & WeenieHeaderFlag2.CooldownDuration) != 0)
                AddOrUpdateValue(PropertyFloat.CooldownDuration, wdesc.CooldownDuration);

            if ((flag2 & WeenieHeaderFlag2.Cooldown) != 0)
                AddOrUpdateValue(PropertyInt.SharedCooldown, (int)wdesc.CooldownId);

            if ((flag1 & WeenieHeaderFlag.HookType) != 0)
                AddOrUpdateValue(PropertyInt.HookType, (int)wdesc.HookType);

            if ((flag1 & WeenieHeaderFlag.HookableOn) != 0)
                AddOrUpdateValue(PropertyInt.HookItemType, (int)wdesc.HookItemTypes);

            if ((flag1 & WeenieHeaderFlag.IconOverlay) != 0)
                AddOrUpdateValue(PropertyDataId.IconOverlay, wdesc.IconOverlay);

            if ((flag2 & WeenieHeaderFlag2.IconUnderlay) != 0)
                AddOrUpdateValue(PropertyDataId.IconUnderlay, wdesc.IconUnderlay);

            if ((flag1 & WeenieHeaderFlag.ItemsCapacity) != 0)
                AddOrUpdateValue(PropertyInt.ItemsCapacity, wdesc.ItemsCapacity);

            if ((flag1 & WeenieHeaderFlag.CurrentlyWieldedLocation) != 0)
                AddOrUpdateValue(PropertyInt.CurrentWieldedLocation, (int)wdesc.Slot);

            if ((flag1 & WeenieHeaderFlag.MaterialType) != 0)
                AddOrUpdateValue(PropertyInt.MaterialType, (int)wdesc.Material);

            if ((flag1 & WeenieHeaderFlag.MaxStackSize) != 0)
                AddOrUpdateValue(PropertyInt.MaxStackSize, wdesc.MaxStackSize);

            if ((flag1 & WeenieHeaderFlag.MaxUses) != 0)
                AddOrUpdateValue(PropertyInt.MaxStructure, wdesc.MaxStructure);

            if ((flag1 & WeenieHeaderFlag.Monarch) != 0)
                AddOrUpdateValue(PropertyInstanceId.Monarch, wdesc.MonarchId);

            if ((flag1 & WeenieHeaderFlag.PluralName) != 0)
                AddOrUpdateValue(PropertyString.PluralName, wdesc.PluralName);

            if ((flag1 & WeenieHeaderFlag.Owner) != 0)
                AddOrUpdateValue(PropertyInstanceId.Owner, wdesc.OwnerId);

            if ((flag2 & WeenieHeaderFlag2.PetOwner) != 0)
                AddOrUpdateValue(PropertyInstanceId.PetOwner, wdesc.PetOwnerId);

            if ((flag1 & WeenieHeaderFlag.PhysicsScript) != 0)
                AddOrUpdateValue(PropertyDataId.PhysicsScript, wdesc.PhysicsScript);

            if ((flag1 & WeenieHeaderFlag.Coverage) != 0)
                AddOrUpdateValue(PropertyInt.ClothingPriority, (int)wdesc.Priority);

            if ((flag1 & WeenieHeaderFlag.RadarBehavior) != 0)
                AddOrUpdateValue(PropertyInt.ShowableOnRadar, (int)wdesc.RadarEnum);

            if ((flag1 & WeenieHeaderFlag.Spell) != 0)
                AddOrUpdateValue(PropertyDataId.Spell, wdesc.SpellId);

            if ((flag1 & WeenieHeaderFlag.StackSize) != 0)
                AddOrUpdateValue(PropertyInt.StackSize, wdesc.StackSize);

            if ((flag1 & WeenieHeaderFlag.Uses) != 0)
                AddOrUpdateValue(PropertyInt.Structure, wdesc.Structure);

            if ((flag1 & WeenieHeaderFlag.TargetType) != 0)
                AddOrUpdateValue(PropertyInt.TargetType, (int)wdesc.TargetType);

            if ((flag1 & WeenieHeaderFlag.Usable) != 0)
                AddOrUpdateValue(PropertyInt.ItemUseable, (int)wdesc.Useability);

            if ((flag1 & WeenieHeaderFlag.UseRadius) != 0)
                AddOrUpdateValue(PropertyFloat.UseRadius, wdesc.UseRadius);

            if ((flag1 & WeenieHeaderFlag.ValidEquipLocations) != 0)
                AddOrUpdateValue(PropertyInt.ValidLocations, (int)wdesc.ValidSlots);

            if ((flag1 & WeenieHeaderFlag.Value) != 0)
                AddOrUpdateValue(PropertyInt.Value, (int)wdesc.Value);

            if ((flag1 & WeenieHeaderFlag.Wielder) != 0)
                AddOrUpdateValue(PropertyInstanceId.Wielder, wdesc.WielderId);

            if ((flag1 & WeenieHeaderFlag.Workmanship) != 0)
                AddOrUpdateValue(PropertyInt.ItemWorkmanship, (int)wdesc.Workmanship);

            if ((flag1 & WeenieHeaderFlag.Burden) != 0)
                AddOrUpdateValue(PropertyInt.EncumbranceVal, (int)wdesc.Burden);

            if ((flag1 & WeenieHeaderFlag.UiEffects) != 0)
                AddOrUpdateValue(PropertyDataId.IconOverlaySecondary, (uint)wdesc.Effects);
        }

        internal void UpdateSpells(List<LayeredSpellId> spellBook) {
            if (spellBook == null || spellBook == null)
                return;

            SpellIds.Clear();
            EnchantmentIds.Clear();

            foreach (var spellId in spellBook) {
                if (spellId.Layer == 0x8000) {
                    EnchantmentIds.Add(spellId);
                }
                else {
                    SpellIds.Add(spellId);
                }
            }
        }

        public override string ToString() {
            return $"{Name}({GetType().Name})[0x{Id:X8} {ItemType}//{ObjectClass}]";
        }
    }
}