using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Splits an item to a wield location.
    /// </summary>
    public class Inventory_StackableSplitToWield : ACGameAction {
        /// <summary>
        /// Id of object being split
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// Equip location to place the stack
        /// </summary>
        public EquipMask Slot;

        /// <summary>
        /// Amount of stack being split
        /// </summary>
        public int Amount;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            Slot = (EquipMask)reader.ReadUInt32();
            Amount = reader.ReadInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write((uint)Slot);
            writer.Write(Amount);
        }

    }

}
