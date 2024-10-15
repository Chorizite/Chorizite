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
using Chorizite.ACProtocol.Extensions;
namespace Chorizite.ACProtocol.Types {
    /// <summary>
    /// Shortcut
    /// </summary>
    public class ShortCutData : IACDataType {
        /// <summary>
        /// Position
        /// </summary>
        public uint Index;

        /// <summary>
        /// Object Id
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// May not have been used in prod?  Maybe a remnet of before spell tabs?  I don&#39;t think you could put spells in shortcut spot...
        /// </summary>
        public LayeredSpellId SpellId;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Index = reader.ReadUInt32();
            ObjectId = reader.ReadUInt32();
            SpellId = new LayeredSpellId();
            SpellId.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Index);
            writer.Write(ObjectId);
            SpellId.Write(writer);
        }

    }

}
