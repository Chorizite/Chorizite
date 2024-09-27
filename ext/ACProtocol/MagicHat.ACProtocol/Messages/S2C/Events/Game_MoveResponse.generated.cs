using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Move response
    /// </summary>
    public class Game_MoveResponse : ACGameEvent {
        /// <summary>
        /// Some kind of identifier for this game
        /// </summary>
        public uint GameId;

        /// <summary>
        /// If less than or equal to 0, then failure
        /// </summary>
        public ChessMoveResult MoveResult;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            GameId = reader.ReadUInt32();
            MoveResult = (ChessMoveResult)reader.ReadInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(GameId);
            writer.Write((int)MoveResult);
        }

    }

}
