using ChessVariants.Shared.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared.Rules
{
    public class NoCaptureOwnPiecesRule : Rule
    {
        public override void OnCleanup(Position pos, Board board, List<Move> moves)
        {
            foreach (Move move in moves)
            {
                Piece piece = board[move.end];
                if (piece != null && piece.owner == board[pos].owner)
                {
                    move.legal = false;
                }
            }
            base.OnCleanup(pos, board, moves);
        }
    }
}
