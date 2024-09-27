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
    /// The Skill structure contains information about a character skill.
    /// </summary>
    public class Skill : IACDataType {
        /// <summary>
        /// points raised
        /// </summary>
        public ushort PointsRaised;

        /// <summary>
        /// If this is not 0, it appears to trigger the initLevel to be treated as extra XP applied to the skill
        /// </summary>
        public ushort AdjustPP;

        /// <summary>
        /// skill state
        /// </summary>
        public SkillAdvancementClass TrainingLevel;

        /// <summary>
        /// XP spent on this skill
        /// </summary>
        public uint ExperienceSpent;

        /// <summary>
        /// starting point for advancement of the skill (eg bonus points)
        /// </summary>
        public uint InnatePoints;

        /// <summary>
        /// last use difficulty
        /// </summary>
        public uint ResistanceOfLastCheck;

        /// <summary>
        /// time skill was last used
        /// </summary>
        public double LastUsedTime;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            PointsRaised = reader.ReadUInt16();
            AdjustPP = reader.ReadUInt16();
            TrainingLevel = (SkillAdvancementClass)reader.ReadUInt32();
            ExperienceSpent = reader.ReadUInt32();
            InnatePoints = reader.ReadUInt32();
            ResistanceOfLastCheck = reader.ReadUInt32();
            LastUsedTime = reader.ReadDouble();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(PointsRaised);
            writer.Write(AdjustPP);
            writer.Write((uint)TrainingLevel);
            writer.Write(ExperienceSpent);
            writer.Write(InnatePoints);
            writer.Write(ResistanceOfLastCheck);
            writer.Write(LastUsedTime);
        }

    }

}
