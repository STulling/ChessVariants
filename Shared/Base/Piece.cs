using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared
{
    public abstract class Piece
    {
        public List<Movement> movements { get; set; }
        public string name { get; set; }
        public int owner { get; set; }

        public string GetFileName()
        {
            return $"{owner}_{name}.svg";
        }
    }
}
