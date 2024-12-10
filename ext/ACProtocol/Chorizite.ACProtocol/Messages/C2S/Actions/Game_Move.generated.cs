using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Makes a chess move
    /// </summary>
    public class Game_Move : ACGameAction {
        /// <summary>
        /// Current x location of piece being moved
        /// </summary>
        public int XFrom;

        /// <summary>
        /// Current y location of piece being moved
        /// </summary>
        public int YFrom;

        /// <summary>
        /// Destination x location of piece being moved
        /// </summary>
        public int XTo;

        /// <summary>
        /// Destination y location of piece being moved
        /// </summary>
        public int YTo;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            XFrom = reader.ReadInt32();
            YFrom = reader.ReadInt32();
            XTo = reader.ReadInt32();
            YTo = reader.ReadInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(XFrom);
            writer.Write(YFrom);
            writer.Write(XTo);
            writer.Write(YTo);
        }

    }

}
