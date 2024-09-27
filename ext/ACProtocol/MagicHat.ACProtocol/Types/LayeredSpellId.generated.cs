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
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Extensions;
namespace MagicHat.ACProtocol.Types {
    /// <summary>
    /// Full spell Id combining the spell id with the spell layer.
    /// </summary>
    public class LayeredSpellId : IACDataType {
        /// <summary>
        /// Id of the spell
        /// </summary>
        public ushort Id;

        /// <summary>
        /// Layer of the spell, seperating multiple instances of the same spell
        /// </summary>
        public ushort Layer;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Id = reader.ReadUInt16();
            Layer = reader.ReadUInt16();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Id);
            writer.Write(Layer);
        }

    }

}
