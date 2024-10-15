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
using Chorizite.ACProtocol.Extensions;
namespace Chorizite.ACProtocol.Types {
    /// <summary>
    /// Set of information related to a salvage operation
    /// </summary>
    public class SalvageOperationsResultData : IACDataType {
        /// <summary>
        /// Which skill was used for the salvaging action
        /// </summary>
        public SkillId SkillUsed;

        /// <summary>
        /// Set of items that could not be salvaged
        /// </summary>
        public List<uint> NotSalvagable = new();

        /// <summary>
        /// Set of salvage returned
        /// </summary>
        public List<SalvageResult> SalvageResults = new();

        /// <summary>
        /// Amount of units due to your Ciandra&#39;s Fortune augmentation
        /// </summary>
        public int AugBonus;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            SkillUsed = (SkillId)reader.ReadInt32();
            NotSalvagable = reader.ReadPackableList<uint>();
            SalvageResults = reader.ReadPackableList<SalvageResult>();
            AugBonus = reader.ReadInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write((int)SkillUsed);
            writer.WritePackableList(NotSalvagable);
            writer.WritePackableList(SalvageResults);
            writer.Write(AugBonus);
        }

    }

}
