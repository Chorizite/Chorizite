using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// HandleAttackerNotificationEvent: You have hit your target with a melee attack.
    /// </summary>
    public class Combat_HandleAttackerNotificationEvent : ACGameEvent {
        /// <summary>
        /// the name of your target
        /// </summary>
        public string DefenderName;

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
        /// critical hit: 0=no, 1=yes
        /// </summary>
        public bool Critical;

        /// <summary>
        /// additional information about the attack, such as whether it was a Sneak Attack, etc
        /// </summary>
        public AttackConditionsMask AttackConditions;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            DefenderName = reader.ReadString16L();
            Type = (DamageType)reader.ReadUInt32();
            DamagePercent = reader.ReadDouble();
            Damage = reader.ReadUInt32();
            Critical = reader.ReadBool();
            AttackConditions = (AttackConditionsMask)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(DefenderName);
            writer.Write((uint)Type);
            writer.Write(DamagePercent);
            writer.Write(Damage);
            writer.Write(Critical);
            writer.Write((uint)AttackConditions);
        }

    }

}
