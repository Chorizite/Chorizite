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
    public class FriendData : IACDataType {
        public uint FriendId;

        public bool Online;

        public bool AppearOffline;

        public string Name;

        public List<uint> OutFriends = new();

        public List<uint> InFriends = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            FriendId = reader.ReadUInt32();
            Online = reader.ReadBool();
            AppearOffline = reader.ReadBool();
            Name = reader.ReadString16L();
            OutFriends = reader.ReadPackableList<uint>();
            InFriends = reader.ReadPackableList<uint>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(FriendId);
            writer.Write(Online);
            writer.Write(AppearOffline);
            writer.Write(Name);
            writer.WritePackableList(OutFriends);
            writer.WritePackableList(InFriends);
        }

    }

}
