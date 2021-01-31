using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared
{
    public abstract class Piece
    {
        public List<Movement> movements;
        public string name;
        public int owner;
    }
}
