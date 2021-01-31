using System.Collections.Generic;

namespace ChessVariants.Shared.Pieces
{
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

    public class King : Piece
    {
        public King()
        {
            movements = new List<Movement>
            {
                new Jump(0, 1),
                new Jump(1, 0),
                new Jump(1, 1),
                new Jump(0, -1),
                new Jump(-1, 0),
                new Jump(-1, -1),
                new Jump(-1, 1),
                new Jump(1, -1)
            };
        }
    }

    public class Knight : Piece
    {
        public Knight()
        {
            movements = new List<Movement>
            {
                new Jump(2, 1),
                new Jump(2, -1),
                new Jump(-2, 1),
                new Jump(-2, -1),
                new Jump(1, 2),
                new Jump(1, -2),
                new Jump(-1, 2),
                new Jump(-1, -2)
            };
        }
    }

    public class Bishop : Piece
    {
        public Bishop()
        {
            movements = new List<Movement>
            {
                new Slide(1, 1),
                new Slide(1, -1),
                new Slide(-1, 1),
                new Slide(-1, -1)
            };
        }
    }

    public class Tower : Piece
    {
        public Tower()
        {
            movements = new List<Movement>
            {
                new Slide(0, 1),
                new Slide(0, -1),
                new Slide(1, 0),
                new Slide(-1, 0)
            };
        }
    }

    public class Queen : Piece
    {
        public Queen()
        {
            movements = new List<Movement>
            {
                new Slide(0, 1),
                new Slide(0, -1),
                new Slide(1, 0),
                new Slide(-1, 0),
                new Slide(1, 1),
                new Slide(1, -1),
                new Slide(-1, 1),
                new Slide(-1, -1)
            };
        }
    }
}
