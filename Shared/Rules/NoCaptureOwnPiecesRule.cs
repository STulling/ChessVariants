using ChessVariants.Shared.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared.Rules
{
    public class NoCaptureOwnPiecesRule : Rule
    {
        public override void OnCleanup(Position pos, List<Move> moves, Game game)
        {
            foreach (Move move in moves)
            {
                Piece piece = game.board[move.end];
                if (piece != null && piece.owner == game.board[pos].owner)
                {
                    move.legal = false;
                }
            }
            base.OnCleanup(pos, moves, game);
        }
    }
}
