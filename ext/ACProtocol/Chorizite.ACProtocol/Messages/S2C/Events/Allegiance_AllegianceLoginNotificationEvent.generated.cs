using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Display an allegiance login/logout message in the chat window.
    /// </summary>
    public class Allegiance_AllegianceLoginNotificationEvent : ACGameEvent {
        /// <summary>
        /// the object Id of the player logging in or out
        /// </summary>
        public uint CharacterId;

        /// <summary>
        /// 0=logout, 1=login
        /// </summary>
        public bool IsLoggedIn;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            CharacterId = reader.ReadUInt32();
            IsLoggedIn = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(CharacterId);
            writer.Write(IsLoggedIn);
        }

    }

}
