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
    /// Contains information related to the spell in your spellbook
    /// </summary>
    public class SpellBookPage : IACDataType {
        /// <summary>
        /// Final value has 2.0 subtracted if network value &gt; 2.0.  Believe this is the charge of the spell which was unused later
        /// </summary>
        public float CastingLikelihood;

        /// <summary>
        /// Client skips this value
        /// </summary>
        public int Unknown;

        /// <summary>
        /// Replaces castingLikelihood
        /// </summary>
        public float CastingLikelihood2;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            CastingLikelihood = reader.ReadSingle();
            if (CastingLikelihood < 2.0) {
                Unknown = reader.ReadInt32();
                CastingLikelihood2 = reader.ReadSingle();
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(CastingLikelihood);
            if (CastingLikelihood < 2.0) {
                writer.Write(Unknown);
                writer.Write(CastingLikelihood2);
            }
        }

    }

}
