using System;
using System.Collections.Generic;

namespace ChessVariants.Shared.Pieces
{
    public class Board
    {
        public Piece[,] pieces;

        public Board(int width, int height)
        {
            pieces = new Piece[width, height];
        }

        private bool inbounds(Position pos)
        {
            return (pos.x < pieces.GetLength(0) && pos.x > 0
                && pos.y < pieces.GetLength(1) && pos.y > 0);
        }

        public Piece getPiece(Position pos)
        {
            if (inbounds(pos))
            {
                return pieces[pos.x, pos.y];
            }
            throw new ArgumentOutOfRangeException();
        }
    }
}