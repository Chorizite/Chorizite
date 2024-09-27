using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S {
    /// <summary>
    /// Ordered game action
    /// </summary>
    public class Ordered_GameAction : ACC2SMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7B1;

        /// <inheritdoc />
        public override C2SMessageType MessageType => C2SMessageType.Ordered_GameAction;

        public uint OrderedSequence;

        public GameActionType ActionType;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            OrderedSequence = reader.ReadUInt32();
            ActionType = (GameActionType)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(OrderedSequence);
            writer.Write((uint)ActionType);
        }

    }

}
