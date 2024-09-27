using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Applies an effect with visual and sound by providing the type to be looked up in the Physics Script Table
    /// </summary>
    public class Effects_PlayScriptType : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF755;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Effects_PlayScriptType;

        /// <summary>
        /// Id of the object from which the effect originates. Can be you, another char/npc or an item.
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// The script type id
        /// </summary>
        public int ScriptType;

        /// <summary>
        /// Speed to play the particle effect at.  1.0 is default, lower for slower, higher for faster.
        /// </summary>
        public float Speed;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            ScriptType = reader.ReadInt32();
            Speed = reader.ReadSingle();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write(ScriptType);
            writer.Write(Speed);
        }

    }

}
