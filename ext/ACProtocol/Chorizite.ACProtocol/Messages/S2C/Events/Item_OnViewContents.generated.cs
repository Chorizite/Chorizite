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
    /// Set Pack Contents
    /// </summary>
    public class Item_OnViewContents : ACGameEvent {
        /// <summary>
        /// The pack we are setting the contents of. This pack objects and the contained objects may be created before or after the message.
        /// </summary>
        public uint ContainerId;

        public List<ContentProfile> Items = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ContainerId = reader.ReadUInt32();
            Items = reader.ReadPackableList<ContentProfile>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ContainerId);
            writer.WritePackableList(Items);
        }

    }

}
