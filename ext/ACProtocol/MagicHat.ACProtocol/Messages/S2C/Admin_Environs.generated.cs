using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// This appears to be an admin command to change the environment (light, fog, sounds, colors)
    /// </summary>
    public class Admin_Environs : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xEA60;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Admin_Environs;

        /// <summary>
        /// Id of option set to change the environs
        /// </summary>
        public EnvrionChangeType EnvrionOption;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            EnvrionOption = (EnvrionChangeType)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((uint)EnvrionOption);
        }

    }

}
