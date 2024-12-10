using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Types;
using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using XLua.Cast;

namespace Core.AC.API {
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
        /// The id of the parent container, or 0 if none
        /// </summary>
        [JsonIgnore]
        public uint ParentContainer => Value(PropertyInstanceId.Container);

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
        /// Type of item this is
        /// </summary>
        [JsonIgnore]
        public ItemType ItemType => (ItemType)Value(PropertyInt.ItemType);

        /// <summary>
        /// Object description
        /// </summary>
        public ObjectDescriptionFlag ObjectDescriptionFlags { get; set; }

        public ObjectDescription ObjectDescription { get; set; } = new ObjectDescription();

        public PhysicsDescription PhysicsDesc { get; set; } = new PhysicsDescription();

        /// <summary>
        /// Weenie creation header flags. These are flags for if data fields are present during a weenie description
        /// </summary>
        public WeenieHeaderFlag CreateFlags { get; set; }

        /// <summary>
        /// More weenie creation header flags. These are flags for if data fields are present during a weenie description
        /// </summary>
        public WeenieHeaderFlag2 CreateFlags2 { get; set; }

        /// <summary>
        /// ObjectClass, for decal compatibility / familiarity (also a bit more granular than ObjectType)
        /// </summary>
        [JsonIgnore]
        public ObjectClass ObjectClass {
            get {
                if (_objectClass == ObjectClass.Unknown) {
                    ObjectClass objectClass = ObjectClass.Unknown;

                    if (ItemType.HasFlag(ItemType.MeleeWeapon)) objectClass = ObjectClass.MeleeWeapon;
                    else if (ItemType.HasFlag(ItemType.Armor)) objectClass = ObjectClass.Armor;
                    else if (ItemType.HasFlag(ItemType.Clothing)) objectClass = ObjectClass.Clothing;
                    else if (ItemType.HasFlag(ItemType.Jewelry)) objectClass = ObjectClass.Jewelry;
                    else if (ItemType.HasFlag(ItemType.Creature)) objectClass = ObjectClass.Monster;
                    else if (ItemType.HasFlag(ItemType.Food)) objectClass = ObjectClass.Food;
                    else if (ItemType.HasFlag(ItemType.Money)) objectClass = ObjectClass.Money;
                    else if (ItemType.HasFlag(ItemType.Misc)) objectClass = ObjectClass.Misc;
                    else if (ItemType.HasFlag(ItemType.MissileWeapon)) objectClass = ObjectClass.MissileWeapon;
                    else if (ItemType.HasFlag(ItemType.Container)) objectClass = ObjectClass.Container;
                    else if (ItemType.HasFlag(ItemType.Useless)) objectClass = ObjectClass.Bundle;
                    else if (ItemType.HasFlag(ItemType.Gem)) objectClass = ObjectClass.Gem;
                    else if (ItemType.HasFlag(ItemType.SpellComponents)) objectClass = ObjectClass.SpellComponent;
                    else if (ItemType.HasFlag(ItemType.Key)) objectClass = ObjectClass.Key;
                    else if (ItemType.HasFlag(ItemType.Caster)) objectClass = ObjectClass.WandStaffOrb;
                    else if (ItemType.HasFlag(ItemType.Portal)) objectClass = ObjectClass.Portal;
                    else if (ItemType.HasFlag(ItemType.PromissoryNote)) objectClass = ObjectClass.TradeNote;
                    else if (ItemType.HasFlag(ItemType.ManaStone)) objectClass = ObjectClass.ManaStone;
                    else if (ItemType.HasFlag(ItemType.Service)) objectClass = ObjectClass.Services;
                    else if (ItemType.HasFlag(ItemType.MagicWieldable)) objectClass = ObjectClass.Plant;
                    else if (ItemType.HasFlag(ItemType.CraftCookingBase)) objectClass = ObjectClass.BaseCooking;
                    else if (ItemType.HasFlag(ItemType.CraftAlchemyBase)) objectClass = ObjectClass.BaseAlchemy;
                    else if (ItemType.HasFlag(ItemType.CraftFletchingBase)) objectClass = ObjectClass.BaseFletching;
                    else if (ItemType.HasFlag(ItemType.CraftFletchingIntermediate)) objectClass = ObjectClass.CraftedFletching;
                    else if (ItemType.HasFlag(ItemType.TinkeringTool)) objectClass = ObjectClass.Ust;
                    else if (ItemType.HasFlag(ItemType.TinkeringMaterial)) objectClass = ObjectClass.Salvage;

                    if (ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.Player)) objectClass = ObjectClass.Player;
                    else if (ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.Vendor)) objectClass = ObjectClass.Vendor;
                    else if (ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.Door)) objectClass = ObjectClass.Door;
                    else if (ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.Corpse)) objectClass = ObjectClass.Corpse;
                    else if (ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.LifeStone)) objectClass = ObjectClass.Lifestone;
                    else if (ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.Food)) objectClass = ObjectClass.Food;
                    else if (ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.Healer)) objectClass = ObjectClass.HealingKit;
                    else if (ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.Lockpick)) objectClass = ObjectClass.Lockpick;
                    else if (ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.Portal)) objectClass = ObjectClass.Portal;
                    else if (ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.RequiresPackSlot)) objectClass = ObjectClass.Foci;
                    else if (ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.Openable)) objectClass = ObjectClass.Container;

                    if (objectClass == ObjectClass.Unknown && ItemType.HasFlag(ItemType.Writable) && ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.Book)) {
                        if (ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.Inscribable)) objectClass = ObjectClass.Journal;
                        else if (ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.Stuck)) objectClass = ObjectClass.Sign;
                        else if (ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.Openable)) objectClass = ObjectClass.Book;
                    }

                    if (ItemType.HasFlag(ItemType.Writable) && CreateFlags.HasFlag(WeenieHeaderFlag.Spell)) objectClass = ObjectClass.Scroll;

                    if (objectClass == ObjectClass.Monster) {
                        if (!ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.Attackable)) objectClass = ObjectClass.Npc;
                        if (ObjectDescriptionFlags.HasFlag(ObjectDescriptionFlag.IncludesSecondHeader)) objectClass = ObjectClass.Npc;
                    }

                    _objectClass = objectClass;
                }

                return _objectClass;
            }
        }
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
    }
}