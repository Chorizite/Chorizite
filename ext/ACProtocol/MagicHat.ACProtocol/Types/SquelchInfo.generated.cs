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
    /// Set of information related to a squelch entry
    /// </summary>
    public class SquelchInfo : IACDataType {
        public List<LogTextType> Filters = new();

        /// <summary>
        /// the name of the squelched player
        /// </summary>
        public string Name;

        /// <summary>
        /// Whether this squelch applies to the entire account
        /// </summary>
        public bool Account;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Filters = reader.ReadPackableList<LogTextType>();
            Name = reader.ReadString16L();
            Account = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.WritePackableList(Filters);
            writer.Write(Name);
            writer.Write(Account);
        }

    }

}
