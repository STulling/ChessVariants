using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared
{
    // S/o naar ariana grande
    public class Position
    {
        public int x;
        public int y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Position operator +(Position a, Position b)
        {
            return new Position(a.x + b.x, a.y + b.y);
        }
    }
}
