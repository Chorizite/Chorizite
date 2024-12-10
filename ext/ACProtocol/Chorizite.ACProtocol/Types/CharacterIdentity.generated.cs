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
    /// Basic information for a character used at the Login screen
    /// </summary>
    public class CharacterIdentity : IACDataType {
        /// <summary>
        /// The character Id for this entry.
        /// </summary>
        public uint CharacterId;

        /// <summary>
        /// The name of this character.
        /// </summary>
        public string Name;

        /// <summary>
        /// When 0, this character is not being deleted (not shown crossed out). Otherwise, it&#39;s a countdown timer in the number of seconds until the character is submitted for deletion.
        /// </summary>
        public uint SecondsGreyedOut;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            CharacterId = reader.ReadUInt32();
            Name = reader.ReadString16L();
            SecondsGreyedOut = reader.ReadUInt32();
            if ((reader.BaseStream.Position % 4) != 0) {
                reader.BaseStream.Position += 4 - (reader.BaseStream.Position % 4);
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(CharacterId);
            writer.Write(Name);
            writer.Write(SecondsGreyedOut);
            if ((writer.BaseStream.Position % 4) != 0) {
                writer.BaseStream.Position += 4 - (writer.BaseStream.Position % 4);
            }
        }

    }

}
