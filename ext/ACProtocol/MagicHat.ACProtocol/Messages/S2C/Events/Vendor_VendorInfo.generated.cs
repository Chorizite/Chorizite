using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Open the buy/sell panel for a merchant.
    /// </summary>
    public class Vendor_VendorInfo : ACGameEvent {
        /// <summary>
        /// the object Id of the merchant
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// the object Id of the merchant
        /// </summary>
        public VendorProfile Profile;

        /// <summary>
        /// Items available from the vendor
        /// </summary>
        public List<ItemProfile> Items = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            Profile = new VendorProfile();
            Profile.Read(reader);
            Items = reader.ReadPackableList<ItemProfile>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            Profile.Write(writer);
            writer.WritePackableList(Items);
        }

    }

}
