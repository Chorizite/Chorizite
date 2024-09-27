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
    public class ArmorProfile : IACDataType {
        /// <summary>
        /// relative protection against slashing damage (multiply by AL for actual protection)
        /// </summary>
        public float ProtSlashing;

        /// <summary>
        /// relative protection against piercing damage (multiply by AL for actual protection)
        /// </summary>
        public float ProtPiercing;

        /// <summary>
        /// relative protection against bludgeoning damage (multiply by AL for actual protection)
        /// </summary>
        public float ProtBludgeoning;

        /// <summary>
        /// relative protection against cold damage (multiply by AL for actual protection)
        /// </summary>
        public float ProtCold;

        /// <summary>
        /// relative protection against fire damage (multiply by AL for actual protection)
        /// </summary>
        public float ProtFire;

        /// <summary>
        /// relative protection against acid damage (multiply by AL for actual protection)
        /// </summary>
        public float ProtAcid;

        /// <summary>
        /// relative protection against nether damage (multiply by AL for actual protection)
        /// </summary>
        public float ProtNether;

        /// <summary>
        /// relative protection against lightning damage (multiply by AL for actual protection)
        /// </summary>
        public float ProtLightning;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            ProtSlashing = reader.ReadSingle();
            ProtPiercing = reader.ReadSingle();
            ProtBludgeoning = reader.ReadSingle();
            ProtCold = reader.ReadSingle();
            ProtFire = reader.ReadSingle();
            ProtAcid = reader.ReadSingle();
            ProtNether = reader.ReadSingle();
            ProtLightning = reader.ReadSingle();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(ProtSlashing);
            writer.Write(ProtPiercing);
            writer.Write(ProtBludgeoning);
            writer.Write(ProtCold);
            writer.Write(ProtFire);
            writer.Write(ProtAcid);
            writer.Write(ProtNether);
            writer.Write(ProtLightning);
        }

    }

}
