using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) : base("Pawn", "P", player, "pawn") { }

        public override List<Position> getValidMoves(Position position, Board board)
        {
            Position[] positions = new Position[]{
                position + new Position(1, 1),
                position + new Position(-1, 1)
            };
            List<Position> validPositions = new List<Position>();
            foreach (Position pos in positions)
            {
                try
                {
                    Piece piece = board.getPiece(pos);
                    if (piece != null)
                    {
                        validPositions.Add(pos);
                    }
                }
                catch (ArgumentOutOfRangeException)
                { }
            }
            Position[] positions2 = new Position[]{
                position + new Position(0, 1)
            };
            foreach (Position pos in positions)
            {
                try
                {
                    Piece piece = board.getPiece(pos);
                    if (piece == null)
                    {
                        validPositions.Add(pos);
                    }
                }
                catch (ArgumentOutOfRangeException)
                { }
            }

            return validPositions;
        }
    }
}
