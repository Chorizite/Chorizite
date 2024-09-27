using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Store an item in a container.
    /// </summary>
    public class Item_ServerSaysContainId : ACGameEvent {
        /// <summary>
        /// the object Id of the item being stored
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// the object Id of the container the item is being stored in
        /// </summary>
        public uint ContainerId;

        /// <summary>
        /// the item slot within the container where the item is being placed (0-based)
        /// </summary>
        public uint SlotIndex;

        /// <summary>
        /// the type of item being stored (pack, foci or regular item)
        /// </summary>
        public ContainerProperties ContainerType;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            ContainerId = reader.ReadUInt32();
            SlotIndex = reader.ReadUInt32();
            ContainerType = (ContainerProperties)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write(ContainerId);
            writer.Write(SlotIndex);
            writer.Write((uint)ContainerType);
        }

    }

}
