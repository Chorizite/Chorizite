using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Buy a dwelling or pay maintenance
    /// </summary>
    public class House_HouseProfile : ACGameEvent {
        /// <summary>
        /// the object Id of the dwelling&#39;s covenant crystal
        /// </summary>
        public uint ObjectId;

        public HouseProfile Profile;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            Profile = new HouseProfile();
            Profile.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            Profile.Write(writer);
        }

    }

}
