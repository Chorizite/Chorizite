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
    /// Salvages items
    /// </summary>
    public class Inventory_CreateTinkeringTool : ACGameAction {
        public uint ToolId;

        /// <summary>
        /// Set of object Id&#39;s to be salvaged
        /// </summary>
        public List<uint> Items = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ToolId = reader.ReadUInt32();
            Items = reader.ReadPackableList<uint>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ToolId);
            writer.WritePackableList(Items);
        }

    }

}
