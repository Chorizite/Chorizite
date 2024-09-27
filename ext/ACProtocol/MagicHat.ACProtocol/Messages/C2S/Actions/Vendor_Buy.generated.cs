using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Buy from a vendor
    /// </summary>
    public class Vendor_Buy : ACGameAction {
        /// <summary>
        /// Id of vendor being bought from
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// Items being purchased from the vendor
        /// </summary>
        public List<ItemProfile> Items = new();

        /// <summary>
        /// the type of alternate currency being used
        /// </summary>
        public uint AlternateCurrencyId;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            Items = reader.ReadPackableList<ItemProfile>();
            AlternateCurrencyId = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.WritePackableList(Items);
            writer.Write(AlternateCurrencyId);
        }

    }

}
