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

    public class Pawn : Piece
    {
        public Pawn()
        {
            movements = new List<Movement>
            {
                new JumpNoCapture(0, 1),
                new JumpIfCapture(1, 1),
                new JumpIfCapture(-1, 1)
            };
        }
    }
}
