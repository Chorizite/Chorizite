using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C {
    /// <summary>
    /// Add or update a dat file Resource.
    /// </summary>
    public class DDD_InterrogationMessage : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7E5;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.DDD_InterrogationMessage;

        public uint ServersRegion;

        public uint NameRuleLanguage;

        public uint ProductId;

        public List<uint> SupportedLanguages = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ServersRegion = reader.ReadUInt32();
            NameRuleLanguage = reader.ReadUInt32();
            ProductId = reader.ReadUInt32();
            SupportedLanguages = reader.ReadPackableList<uint>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ServersRegion);
            writer.Write(NameRuleLanguage);
            writer.Write(ProductId);
            writer.WritePackableList(SupportedLanguages);
        }

    }

}
