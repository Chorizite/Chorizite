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
    /// Contains a list of emotes for NPCs? Unknown what this does currently.
    /// </summary>
    public class EmoteTable : IACDataType {
        /// <summary>
        /// Key may be an EmoteCategory?
        /// </summary>
        public Dictionary<EmoteCategory, EmoteSetList> Emotes = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Emotes = reader.ReadPackableHashTable<EmoteCategory, EmoteSetList>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.WritePackableHashTable(Emotes);
        }

    }

}
