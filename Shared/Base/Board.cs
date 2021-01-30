using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessVariants.Shared.Base
{
    public class Board
    {
        public Piece[,] pieces;

        public Piece this[Position pos]
        {
            get
            {
                return pieces[pos.x, pos.y];
            }

            set
            {
                pieces[pos.x, pos.y] = value;
            }
        }

        public Piece this[int x, int y]
        {
            get
            {
                return pieces[x, y];
            }

            set
            {
                pieces[x, y] = value;
            }
        }

        public int width;
        public int height;

        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            pieces = new Piece[width, height];
        }

        public bool inBounds(Position pos)
        {
            return pos.x > 0 && pos.x < width
                && pos.y > 0 && pos.y < height;
        }

        public bool inBounds(int x, int y)
        {
            return inBounds(new Position(x, y));
        }

        public void mirrorBoard()
        {
            Piece[,] newPieces = new Piece[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    newPieces[x, height - 1 - y] = pieces[x, y];
                }
            }

            this.pieces = newPieces;
        }

        public void mirrorMoves(List<Move> moves)
        {
            foreach (Move move in moves) 
            {
                mirrorPos(move.start);
                mirrorPos(move.end);
            };
        }

        public void mirrorPos(Position pos)
        {
            pos.y = this.height - 1 - pos.y;
        }
    }
}
