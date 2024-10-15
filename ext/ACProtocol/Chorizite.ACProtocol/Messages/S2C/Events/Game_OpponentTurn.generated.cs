using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Opponent Turn
    /// </summary>
    public class Game_OpponentTurn : ACGameEvent {
        /// <summary>
        /// Some kind of identifier for this game
        /// </summary>
        public uint GameId;

        /// <summary>
        /// Team making this move
        /// </summary>
        public int Team;

        /// <summary>
        /// Data related to the piece move
        /// </summary>
        public GameMoveData GameMove;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            GameId = reader.ReadUInt32();
            Team = reader.ReadInt32();
            GameMove = new GameMoveData();
            GameMove.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(GameId);
            writer.Write(Team);
            GameMove.Write(writer);
        }

    }

}
