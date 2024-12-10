//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//                                                            //
//                          WARNING                           //
//                                                            //
//           DO NOT MAKE LOCAL CHANGES TO THIS FILE           //
//               EDIT THE .tt TEMPLATE INSTEAD                //
//                                                            //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//


using System;

namespace Chorizite.ACProtocol.Enums {
    /// <summary>
    /// Identifies the chess move attempt result.  Negative/0 values are failures.
    /// </summary>
    public enum ChessMoveResult : int {
        /// <summary>
        /// Its not your turn, please wait for your opponents move.
        /// </summary>
        FailureNotYourTurn = -3,

        /// <summary>
        /// The selected piece cannot move that direction
        /// </summary>
        FailureInvalidDirection = -100,

        /// <summary>
        /// The selected piece cannot move that far
        /// </summary>
        FailureInvalidDistance = -101,

        /// <summary>
        /// You tried to move an empty square
        /// </summary>
        FailureMovingEmptySquare = -102,

        /// <summary>
        /// The selected piece is not yours
        /// </summary>
        FailureMovingOpponentPiece = -103,

        /// <summary>
        /// You cannot move off the board
        /// </summary>
        FailureMovedPieceOffBoard = -104,

        /// <summary>
        /// You cannot attack your own pieces
        /// </summary>
        FailureAttackingOwnPiece = -105,

        /// <summary>
        /// That move would put you in check
        /// </summary>
        FailureCannotMoveIntoCheck = -106,

        /// <summary>
        /// You can only move through empty squares
        /// </summary>
        FailurePathBlocked = -107,

        /// <summary>
        /// You cannot castle out of check
        /// </summary>
        FailureCastleOutOfCheck = -108,

        /// <summary>
        /// You cannot castle through check
        /// </summary>
        FailureCastleThroughCheck = -109,

        /// <summary>
        /// You cannot castle after moving the King or Rook
        /// </summary>
        FailureCastlePieceMoved = -110,

        /// <summary>
        /// That move is invalid
        /// </summary>
        FailureInvalidMove = 0,

        /// <summary>
        /// Successful move.
        /// </summary>
        Success = 0x1,

        /// <summary>
        /// Your opponent is in Check.
        /// </summary>
        OpponentInCheck = 0x400,

        /// <summary>
        /// You have checkmated your opponent!
        /// </summary>
        CheckMatedOpponent = 0x800,

    };
}
