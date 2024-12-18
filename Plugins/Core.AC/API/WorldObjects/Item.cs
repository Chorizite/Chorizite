using Chorizite.ACProtocol.Types;
using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.AC.API.WorldObjects {
    public class Item : WorldObject {
        /// <summary>
        /// True if this item is stackable
        /// </summary>
        public bool IsStackable => Value(PropertyInt.MaxStackSize, 1) != 1;

        /// <summary>
        /// True if this item is attuned to your character. (Can't be dropped / given to others)
        /// </summary>
        public bool IsAttuned => Value(PropertyInt.Attuned) != 0;

        /// <summary>
        /// Bonded items will not be dropped on death
        /// </summary>
        public bool IsBonded => Value(PropertyInt.Bonded) != 0;

        /// <summary>
        /// The id of the spell this item casts, if any
        /// </summary>
        public uint SpellId { get; set; }

        /// <summary>
        /// A list of spells this item casts.
        /// </summary>
        public List<LayeredSpellId> SpellIds { get; set; } = [];

        /// <summary>
        /// A list of active enchantments on this item.
        /// </summary>
        public List<LayeredSpellId> EnchantmentIds { get; set; } = [];

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
        /// Is this item owned by you (in your backpack or one of your side packs).
        /// </summary>
        [JsonIgnore]
        public bool IsOwnedByMe => ParentContainer?.Id == CoreACPlugin.Instance.Game.Character.Id || ParentContainer?.ParentContainer?.Id == CoreACPlugin.Instance.Game.Character.Id;

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
    }
}
