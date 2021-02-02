using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessVariants.Shared.Base
{
    public class Board
    {
        public Piece[,] pieces;
        public int width;
        public int height;

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

        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            pieces = new Piece[width, height];
        }

        public bool inBounds(Position pos)
        {
            return pos.x >= 0 && pos.x < width
                && pos.y >= 0 && pos.y < height;
        }

        public bool inBounds(int x, int y)
        {
            return inBounds(new Position(x, y));
        }

        public void Clear()
        {
            pieces = new Piece[width, height];
        }
        public override string ToString()
        {
            string result = "";
            for (int row = height - 1; row >= 0; row--)
            {
                for(int column = 0; column < width; column++)
                {
                    if (pieces[column, row] == null)
                    {
                        result += "0";

                    }
                    else
                    {
                        result += pieces[column, row].GetType().Name[0];
                    }
                }
                result += "\n";
            }
            return result;
        }
    }
}
