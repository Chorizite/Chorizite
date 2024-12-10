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
    /// Contains data for texture map changes
    /// </summary>
    public class TextureMapChange : IACDataType {
        /// <summary>
        /// the index of the model we are replacing the texture in
        /// </summary>
        public byte PartIndex;

        /// <summary>
        /// texture DataId (minus 0x05000000)
        /// </summary>
        public uint OldTexId;

        /// <summary>
        /// texture DataId (minus 0x05000000)
        /// </summary>
        public uint NewTexId;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            PartIndex = reader.ReadByte();
            OldTexId = reader.ReadPackedDWORD();
            NewTexId = reader.ReadPackedDWORD();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(PartIndex);
            writer.Write(OldTexId);
            writer.Write(NewTexId);
        }

    }

}
