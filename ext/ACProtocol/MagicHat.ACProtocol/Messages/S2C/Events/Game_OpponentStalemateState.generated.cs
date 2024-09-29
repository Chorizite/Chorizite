using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Opponent Stalemate State
    /// </summary>
    public class Game_OpponentStalemateState : ACGameEvent {
        /// <summary>
        /// Some kind of identifier for this game
        /// </summary>
        public uint GameId;

        /// <summary>
        /// Team
        /// </summary>
        public int Team;

        /// <summary>
        /// 1 = offering stalemate, 0 = retracting stalemate
        /// </summary>
        public bool On;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            GameId = reader.ReadUInt32();
            Team = reader.ReadInt32();
            On = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(GameId);
            writer.Write(Team);
            writer.Write(On);
        }

    }

}