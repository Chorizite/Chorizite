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
    /// Set of information related to a chess game move
    /// </summary>
    public class GameMoveData : IACDataType {
        /// <summary>
        /// Type of move
        /// </summary>
        public int Type;

        /// <summary>
        /// Player making the move
        /// </summary>
        public uint PlayerId;

        /// <summary>
        /// Team making this move
        /// </summary>
        public int Team;

        /// <summary>
        /// Id of piece being moved
        /// </summary>
        public int IdPieceToMove;

        public int YGrid;

        /// <summary>
        /// x position to move the piece
        /// </summary>
        public int XTo;

        /// <summary>
        /// y position to move the piece
        /// </summary>
        public int YTo;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Type = reader.ReadInt32();
            PlayerId = reader.ReadUInt32();
            Team = reader.ReadInt32();
            switch((int)Type) {
                case 0x4:
                    IdPieceToMove = reader.ReadInt32();
                    YGrid = reader.ReadInt32();
                    break;
                case 0x5:
                    IdPieceToMove = reader.ReadInt32();
                    YGrid = reader.ReadInt32();
                    XTo = reader.ReadInt32();
                    YTo = reader.ReadInt32();
                    break;
                case 0x6:
                    IdPieceToMove = reader.ReadInt32();
                    break;
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Type);
            writer.Write(PlayerId);
            writer.Write(Team);
            switch((int)Type) {
                case 0x4:
                    writer.Write(IdPieceToMove);
                    writer.Write(YGrid);
                    break;
                case 0x5:
                    writer.Write(IdPieceToMove);
                    writer.Write(YGrid);
                    writer.Write(XTo);
                    writer.Write(YTo);
                    break;
                case 0x6:
                    writer.Write(IdPieceToMove);
                    break;
            }
        }

    }

}
