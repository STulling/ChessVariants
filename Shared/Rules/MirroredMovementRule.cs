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
            if (board[pos] != null && board[pos].owner == 1)
            {
                mirrorBoard(board);
                mirrorPos(board, pos);
                mirrorMoves(board, moves);
            }
            base.OnCleanup(pos, board, moves);
        }

        public override void OnPreRegularMoveGen(Position pos, Board board)
        {
            if (board[pos] != null && board[pos].owner == 1)
            {
                mirrorBoard(board);
                mirrorPos(board, pos);
            }
            base.OnPreRegularMoveGen(pos, board);
        }

        public void mirrorBoard(Board board)
        {
            Piece[,] newPieces = new Piece[board.width, board.height];

            for (int x = 0; x < board.width; x++)
            {
                for (int y = 0; y < board.height; y++)
                {
                    newPieces[x, y] = board.pieces[(board.width - 1) - x, (board.height - 1) - y];
                }
            }

            board.pieces = newPieces;
        }

        public void mirrorMoves(Board board, List<Move> moves)
        {
            foreach (Move move in moves)
            {
                mirrorPos(board, move.end);
            };
        }

        public void mirrorPos(Board board, Position pos)
        {
            pos.y = (board.height - 1) - pos.y;
            pos.x = (board.width - 1) - pos.x;
        }
    }
}
