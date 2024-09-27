//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//                                                            //
//                          WARNING                           //
//                                                            //
//           DO NOT MAKE LOCAL CHANGES TO THIS FILE           //
//               EDIT THE .tt TEMPLATE INSTEAD                //
//                                                            //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//


using System;
using System.Numerics;
using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Extensions;
namespace MagicHat.ACProtocol.Types {
    /// <summary>
    /// The ACQualities structure contains character property lists.
    /// </summary>
    public class ACQualities : IACDataType {
        /// <summary>
        /// determines which property vector types appear in the message
        /// </summary>
        public ACQualitiesFlags Flags;

        /// <summary>
        /// seems to indicate this object has health attribute
        /// </summary>
        public bool HasHealth;

        /// <summary>
        /// The character attributes
        /// </summary>
        public AttributeCache Attributes;

        public Dictionary<Skill, Skill> Skills = new();

        public Body Body;

        /// <summary>
        /// Spells in the characters spellbook
        /// </summary>
        public Dictionary<LayeredSpellId, SpellBookPage> SpellBook = new();

        /// <summary>
        /// The enchantments active on the character
        /// </summary>
        public EnchantmentRegistry Enchantments;

        /// <summary>
        /// Some kind of event filter
        /// </summary>
        public EventFilter EventFilter;

        public EmoteTable Emotes;

        public List<CreationProfile> CreationProfile = new();

        public PageDataList PageData;

        public GeneratorTable Generators;

        public GeneratorRegistry GeneratorRegistry;

        public GeneratorQueue GeneratorQueue;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Flags = (ACQualitiesFlags)reader.ReadUInt32();
            HasHealth = reader.ReadBool();
            if (Flags.HasFlag(ACQualitiesFlags.Attributes)) {
                Attributes = new AttributeCache();
                Attributes.Read(reader);
            }
            if (Flags.HasFlag(ACQualitiesFlags.Skills)) {
                Skills = reader.ReadPackableHashTable<Skill, Skill>();
            }
            if (Flags.HasFlag(ACQualitiesFlags.Body)) {
                Body = new Body();
                Body.Read(reader);
            }
            if (Flags.HasFlag(ACQualitiesFlags.SpellBook)) {
                SpellBook = reader.ReadPackableHashTable<LayeredSpellId, SpellBookPage>();
            }
            if (Flags.HasFlag(ACQualitiesFlags.Enchantments)) {
                Enchantments = new EnchantmentRegistry();
                Enchantments.Read(reader);
            }
            if (Flags.HasFlag(ACQualitiesFlags.EventFilter)) {
                EventFilter = new EventFilter();
                EventFilter.Read(reader);
            }
            if (Flags.HasFlag(ACQualitiesFlags.Emotes)) {
                Emotes = new EmoteTable();
                Emotes.Read(reader);
            }
            if (Flags.HasFlag(ACQualitiesFlags.CreationProfile)) {
                CreationProfile = reader.ReadPackableList<CreationProfile>();
            }
            if (Flags.HasFlag(ACQualitiesFlags.PageData)) {
                PageData = new PageDataList();
                PageData.Read(reader);
            }
            if (Flags.HasFlag(ACQualitiesFlags.Generators)) {
                Generators = new GeneratorTable();
                Generators.Read(reader);
            }
            if (Flags.HasFlag(ACQualitiesFlags.GeneratorRegistry)) {
                GeneratorRegistry = new GeneratorRegistry();
                GeneratorRegistry.Read(reader);
            }
            if (Flags.HasFlag(ACQualitiesFlags.GeneratorQueue)) {
                GeneratorQueue = new GeneratorQueue();
                GeneratorQueue.Read(reader);
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write((uint)Flags);
            writer.Write(HasHealth);
            if (Flags.HasFlag(ACQualitiesFlags.Attributes)) {
                Attributes.Write(writer);
            }
            if (Flags.HasFlag(ACQualitiesFlags.Skills)) {
                writer.WritePackableHashTable(Skills);
            }
            if (Flags.HasFlag(ACQualitiesFlags.Body)) {
                Body.Write(writer);
            }
            if (Flags.HasFlag(ACQualitiesFlags.SpellBook)) {
                writer.WritePackableHashTable(SpellBook);
            }
            if (Flags.HasFlag(ACQualitiesFlags.Enchantments)) {
                Enchantments.Write(writer);
            }
            if (Flags.HasFlag(ACQualitiesFlags.EventFilter)) {
                EventFilter.Write(writer);
            }
            if (Flags.HasFlag(ACQualitiesFlags.Emotes)) {
                Emotes.Write(writer);
            }
            if (Flags.HasFlag(ACQualitiesFlags.CreationProfile)) {
                writer.WritePackableList(CreationProfile);
            }
            if (Flags.HasFlag(ACQualitiesFlags.PageData)) {
                PageData.Write(writer);
            }
            if (Flags.HasFlag(ACQualitiesFlags.Generators)) {
                Generators.Write(writer);
            }
            if (Flags.HasFlag(ACQualitiesFlags.GeneratorRegistry)) {
                GeneratorRegistry.Write(writer);
            }
            if (Flags.HasFlag(ACQualitiesFlags.GeneratorQueue)) {
                GeneratorQueue.Write(writer);
            }
        }

    }

}
