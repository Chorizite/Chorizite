using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// HandleDefenderNotificationEvent: You have been hit by a creature&#39;s melee attack.
    /// </summary>
    public class Combat_HandleDefenderNotificationEvent : ACGameEvent {
        /// <summary>
        /// the name of the creature
        /// </summary>
        public string AttackerName;

        /// <summary>
        /// the type of damage done
        /// </summary>
        public DamageType Type;

        /// <summary>
        /// percentage of targets hp removed by damage. 0.0 (low) to 1.0 (high)
        /// </summary>
        public double DamagePercent;

        /// <summary>
        /// the amount of damage done
        /// </summary>
        public uint Damage;

        /// <summary>
        /// the location of the damage done
        /// </summary>
        public DamageLocation Location;

        /// <summary>
        /// critical hit: 0=no, 1=yes
        /// </summary>
        public bool Critical;

        /// <summary>
        /// additional information about the attack, such as whether it was a Sneak Attack, etc.
        /// </summary>
        public AttackConditionsMask AttackConditions;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            AttackerName = reader.ReadString16L();
            Type = (DamageType)reader.ReadUInt32();
            DamagePercent = reader.ReadDouble();
            Damage = reader.ReadUInt32();
            Location = (DamageLocation)reader.ReadUInt32();
            Critical = reader.ReadBool();
            AttackConditions = (AttackConditionsMask)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(AttackerName);
            writer.Write((uint)Type);
            writer.Write(DamagePercent);
            writer.Write(Damage);
            writer.Write((uint)Location);
            writer.Write(Critical);
            writer.Write((uint)AttackConditions);
        }

    }

}
