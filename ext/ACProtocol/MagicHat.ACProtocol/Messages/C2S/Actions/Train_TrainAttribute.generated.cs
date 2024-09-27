using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Spend XP to raise an attribute.
    /// </summary>
    public class Train_TrainAttribute : ACGameAction {
        /// <summary>
        /// The Id of the attribute
        /// </summary>
        public AttributeId Type;

        /// <summary>
        /// The amount of XP being spent
        /// </summary>
        public uint Experience;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Type = (AttributeId)reader.ReadUInt32();
            Experience = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((uint)Type);
            writer.Write(Experience);
        }

    }

}
