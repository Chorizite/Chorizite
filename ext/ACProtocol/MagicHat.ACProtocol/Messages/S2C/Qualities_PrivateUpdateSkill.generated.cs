using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Set or update a Character Skill value
    /// </summary>
    public class Qualities_PrivateUpdateSkill : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0x02DD;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Qualities_PrivateUpdateSkill;

        /// <summary>
        /// sequence number
        /// </summary>
        public byte Sequence;

        /// <summary>
        /// skill Id
        /// </summary>
        public SkillId Key;

        /// <summary>
        /// skill information
        /// </summary>
        public Skill Value;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Sequence = reader.ReadByte();
            Key = (SkillId)reader.ReadInt32();
            Value = new Skill();
            Value.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Sequence);
            writer.Write((int)Key);
            Value.Write(writer);
        }

    }

}
