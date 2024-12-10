//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//                                                            //
//                          WARNING                           //
//                                                            //
//           DO NOT MAKE LOCAL CHANGES TO THIS FILE           //
//               EDIT THE .tt TEMPLATE INSTEAD                //
//                                                            //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//


using System;
using System.Numerics;
using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.Common.Enums;
using Chorizite.ACProtocol.Extensions;
namespace Chorizite.ACProtocol.Types {
    /// <summary>
    /// The HousePayment structure contains information about a house purchase or maintenance item.
    /// </summary>
    public class HousePayment : IACDataType {
        /// <summary>
        /// the quantity required
        /// </summary>
        public uint Required;

        /// <summary>
        /// the quantity paid
        /// </summary>
        public uint Paid;

        /// <summary>
        /// the item&#39;s object type
        /// </summary>
        public uint WeenieClassId;

        /// <summary>
        /// the name of this item
        /// </summary>
        public string Name;

        /// <summary>
        /// the plural name of this item (if not specified, use &lt;name&gt; followed by &#39;s&#39; or &#39;es&#39;)
        /// </summary>
        public string PluralName;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Required = reader.ReadUInt32();
            Paid = reader.ReadUInt32();
            WeenieClassId = reader.ReadUInt32();
            Name = reader.ReadString16L();
            PluralName = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Required);
            writer.Write(Paid);
            writer.Write(WeenieClassId);
            writer.Write(Name);
            writer.Write(PluralName);
        }

    }

}
