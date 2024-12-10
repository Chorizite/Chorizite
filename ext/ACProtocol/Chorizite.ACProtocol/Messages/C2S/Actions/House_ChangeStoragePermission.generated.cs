using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Changes a specific players storage permission, /house storage add/remove
    /// </summary>
    public class House_ChangeStoragePermission : ACGameAction {
        /// <summary>
        /// Player name to boot from your house
        /// </summary>
        public string GuestName;

        /// <summary>
        /// Whether the player has permission on your storage
        /// </summary>
        public bool HasPermission;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            GuestName = reader.ReadString16L();
            HasPermission = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(GuestName);
            writer.Write(HasPermission);
        }

    }

}
