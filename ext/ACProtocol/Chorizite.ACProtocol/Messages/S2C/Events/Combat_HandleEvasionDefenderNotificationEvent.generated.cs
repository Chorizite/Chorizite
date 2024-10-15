using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// HandleEvasionDefenderNotificationEvent: You have evaded a creature&#39;s melee attack.
    /// </summary>
    public class Combat_HandleEvasionDefenderNotificationEvent : ACGameEvent {
        /// <summary>
        /// the name of the creature
        /// </summary>
        public string AttackerName;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            AttackerName = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(AttackerName);
        }

    }

}
