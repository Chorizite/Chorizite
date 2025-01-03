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
    /// Set a title for the current character.
    /// </summary>
    public class Social_AddOrSetCharacterTitle : ACGameEvent {
        /// <summary>
        /// the title Id of the new title
        /// </summary>
        public uint NewTitle;

        /// <summary>
        /// true if the title should be made the current title, false if it should just be added to the title list
        /// </summary>
        public bool SetAsDisplayTitle;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            NewTitle = reader.ReadUInt32();
            SetAsDisplayTitle = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(NewTitle);
            writer.Write(SetAsDisplayTitle);
        }

    }

}
