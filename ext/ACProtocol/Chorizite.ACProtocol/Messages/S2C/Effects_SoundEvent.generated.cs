using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C {
    /// <summary>
    /// Applies a sound effect.
    /// </summary>
    public class Effects_SoundEvent : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF750;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Effects_SoundEvent;

        /// <summary>
        /// Id of the object from which the effect originates. Can be you, another char/npc or an item.
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// The sound type Id, which is referenced in the Sound Table.
        /// </summary>
        public Sound SoundType;

        /// <summary>
        /// Volume to play the sound
        /// </summary>
        public float Volume;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            SoundType = (Sound)reader.ReadInt32();
            Volume = reader.ReadSingle();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write((int)SoundType);
            writer.Write(Volume);
        }

    }

}
