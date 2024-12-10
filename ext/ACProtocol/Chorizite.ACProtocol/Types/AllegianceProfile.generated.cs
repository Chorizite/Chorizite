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
    /// Allegience information
    /// </summary>
    public class AllegianceProfile : IACDataType {
        /// <summary>
        /// The number of allegiance members.
        /// </summary>
        public uint TotalMembers;

        /// <summary>
        /// Your personal number of followers.
        /// </summary>
        public uint TotalVassals;

        public AllegianceHierarchy Hierarchy;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            TotalMembers = reader.ReadUInt32();
            TotalVassals = reader.ReadUInt32();
            Hierarchy = new AllegianceHierarchy();
            Hierarchy.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(TotalMembers);
            writer.Write(TotalVassals);
            Hierarchy.Write(writer);
        }

    }

}
