using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Joins a chess game
    /// </summary>
    public class Game_Join : ACGameAction {
        /// <summary>
        /// Id of the game the player is joining
        /// </summary>
        public uint GameId;

        /// <summary>
        /// Which team the player is joining as
        /// </summary>
        public uint Team;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            GameId = reader.ReadUInt32();
            Team = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(GameId);
            writer.Write(Team);
        }

    }

}
