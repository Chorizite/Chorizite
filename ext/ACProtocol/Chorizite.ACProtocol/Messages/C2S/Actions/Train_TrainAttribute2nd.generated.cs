using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Spend XP to raise a vital.
    /// </summary>
    public class Train_TrainAttribute2nd : ACGameAction {
        /// <summary>
        /// The Id of the vital
        /// </summary>
        public VitalId Type;

        /// <summary>
        /// The amount of XP being spent
        /// </summary>
        public uint Experience;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Type = (VitalId)reader.ReadUInt32();
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
