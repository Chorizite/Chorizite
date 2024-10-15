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
    /// The FellowInfo structure contains information about a fellowship member.
    /// </summary>
    public class Fellow : IACDataType {
        /// <summary>
        /// Perhaps cp stored up before distribution?
        /// </summary>
        public uint XPCached;

        /// <summary>
        /// Perhaps lum stored up before distribution?
        /// </summary>
        public uint LumCached;

        /// <summary>
        /// level of member
        /// </summary>
        public uint Level;

        /// <summary>
        /// Maximum Health
        /// </summary>
        public uint MaxHealth;

        /// <summary>
        /// Maximum Stamina
        /// </summary>
        public uint MaxStamina;

        /// <summary>
        /// Maximum Mana
        /// </summary>
        public uint MaxMana;

        /// <summary>
        /// Current Health
        /// </summary>
        public uint CurrentHealth;

        /// <summary>
        /// Current Stamina
        /// </summary>
        public uint CurrentStamina;

        /// <summary>
        /// Current Mana
        /// </summary>
        public uint CurrentMana;

        /// <summary>
        /// if 0 then noSharePhatLoot, if 16 (0x0010) then sharePhatLoot
        /// </summary>
        public bool ShareLoot;

        /// <summary>
        /// Name of Member
        /// </summary>
        public string Name;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            XPCached = reader.ReadUInt32();
            LumCached = reader.ReadUInt32();
            Level = reader.ReadUInt32();
            MaxHealth = reader.ReadUInt32();
            MaxStamina = reader.ReadUInt32();
            MaxMana = reader.ReadUInt32();
            CurrentHealth = reader.ReadUInt32();
            CurrentStamina = reader.ReadUInt32();
            CurrentMana = reader.ReadUInt32();
            ShareLoot = reader.ReadBool();
            Name = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(XPCached);
            writer.Write(LumCached);
            writer.Write(Level);
            writer.Write(MaxHealth);
            writer.Write(MaxStamina);
            writer.Write(MaxMana);
            writer.Write(CurrentHealth);
            writer.Write(CurrentStamina);
            writer.Write(CurrentMana);
            writer.Write(ShareLoot);
            writer.Write(Name);
        }

    }

}
