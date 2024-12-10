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
using Chorizite.ACProtocol.Enums;
using Chorizite.Common.Enums;
using Chorizite.ACProtocol.Extensions;
namespace Chorizite.ACProtocol.Types {
    /// <summary>
    /// The PlayerModule structure contains character options.
    /// </summary>
    public class PlayerModule : IACDataType {
        public uint Flags;

        public CharacterOptions1 Options;

        /// <summary>
        /// List of short cuts.
        /// </summary>
        public List<ShortCutData> Shortcuts = new();

        public List<LayeredSpellId> Tab1Spells = new();

        public List<LayeredSpellId> Tab2Spells = new();

        public List<LayeredSpellId> Tab3Spells = new();

        public List<LayeredSpellId> Tab4Spells = new();

        public List<LayeredSpellId> Tab5Spells = new();

        public List<LayeredSpellId> Tab6Spells = new();

        public List<LayeredSpellId> Tab7Spells = new();

        public List<LayeredSpellId> Tab8Spells = new();

        /// <summary>
        /// A dictionary of comps to fill with the key being the component weenie class id, and the value being the fill number
        /// </summary>
        public Dictionary<uint, uint> FillComps = new();

        public uint SpellBookFilters;

        public uint OptionFlags;

        public uint Unknown100_1;

        public Dictionary<uint, string> OptionStrings = new();

        public GameplayOptions GameplayOptions;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Flags = reader.ReadUInt32();
            Options = (CharacterOptions1)reader.ReadUInt32();
            if (((uint)Flags & (uint)0x00000001) != 0) {
                Shortcuts = reader.ReadPackableList<ShortCutData>();
            }
            Tab1Spells = reader.ReadPackableList<LayeredSpellId>();
            Tab2Spells = reader.ReadPackableList<LayeredSpellId>();
            Tab3Spells = reader.ReadPackableList<LayeredSpellId>();
            Tab4Spells = reader.ReadPackableList<LayeredSpellId>();
            Tab5Spells = reader.ReadPackableList<LayeredSpellId>();
            Tab6Spells = reader.ReadPackableList<LayeredSpellId>();
            Tab7Spells = reader.ReadPackableList<LayeredSpellId>();
            Tab8Spells = reader.ReadPackableList<LayeredSpellId>();
            if (((uint)Flags & (uint)0x00000008) != 0) {
                FillComps = reader.ReadPackableHashTable<uint, uint>();
            }
            if (((uint)Flags & (uint)0x00000020) != 0) {
                SpellBookFilters = reader.ReadUInt32();
            }
            if (((uint)Flags & (uint)0x00000040) != 0) {
                OptionFlags = reader.ReadUInt32();
            }
            if (((uint)Flags & (uint)0x00000100) != 0) {
                Unknown100_1 = reader.ReadUInt32();
                OptionStrings = reader.ReadPackableHashTable<uint, string>();
            }
            if (((uint)Flags & (uint)0x00000200) != 0) {
                GameplayOptions = new GameplayOptions();
                GameplayOptions.Read(reader);
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Flags);
            writer.Write((uint)Options);
            if (((uint)Flags & (uint)0x00000001) != 0) {
                writer.WritePackableList(Shortcuts);
            }
            writer.WritePackableList(Tab1Spells);
            writer.WritePackableList(Tab2Spells);
            writer.WritePackableList(Tab3Spells);
            writer.WritePackableList(Tab4Spells);
            writer.WritePackableList(Tab5Spells);
            writer.WritePackableList(Tab6Spells);
            writer.WritePackableList(Tab7Spells);
            writer.WritePackableList(Tab8Spells);
            if (((uint)Flags & (uint)0x00000008) != 0) {
                writer.WritePackableHashTable(FillComps);
            }
            if (((uint)Flags & (uint)0x00000020) != 0) {
                writer.Write(SpellBookFilters);
            }
            if (((uint)Flags & (uint)0x00000040) != 0) {
                writer.Write(OptionFlags);
            }
            if (((uint)Flags & (uint)0x00000100) != 0) {
                writer.Write(Unknown100_1);
                writer.WritePackableHashTable(OptionStrings);
            }
            if (((uint)Flags & (uint)0x00000200) != 0) {
                GameplayOptions.Write(writer);
            }
        }

    }

}
