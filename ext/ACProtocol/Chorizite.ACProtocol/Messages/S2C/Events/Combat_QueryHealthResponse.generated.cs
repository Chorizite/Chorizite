using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// QueryHealthResponse: Update a creature&#39;s health bar.
    /// </summary>
    public class Combat_QueryHealthResponse : ACGameEvent {
        /// <summary>
        /// the object Id of the creature
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// the amount of health remaining, scaled from 0.0 (none) to 1.0 (full)
        /// </summary>
        public float Health;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            Health = reader.ReadSingle();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write(Health);
        }

    }

}
