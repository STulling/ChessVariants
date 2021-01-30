using ChessVariants.Shared.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared.Rules
{
    public class MirroredMovementRule : Rule
    {
        public override void OnCleanup(Position pos, Board board, List<Move> moves)
        {
            if (board[pos].owner == 1)
            {
                board.mirrorBoard();
                board.mirrorMoves(moves);
                board.mirrorPos(pos);
            }
            base.OnCleanup(pos, board, moves);
        }

        public override void OnPreRegularMoveGen(Position pos, Board board)
        {
            if (board[pos].owner == 1)
            {
                board.mirrorBoard();
                board.mirrorPos(pos);
            }
            base.OnPreRegularMoveGen(pos, board);
        }
    }
}
