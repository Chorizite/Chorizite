using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Spend XP to raise a skill.
    /// </summary>
    public class Train_TrainSkill : ACGameAction {
        /// <summary>
        /// The Id of the skill
        /// </summary>
        public SkillId Skill;

        /// <summary>
        /// The amount of XP being spent
        /// </summary>
        public uint Experience;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Skill = (SkillId)reader.ReadInt32();
            Experience = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((int)Skill);
            writer.Write(Experience);
        }

    }

}
