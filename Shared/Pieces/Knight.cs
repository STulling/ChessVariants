using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player) : base("Knight", "N", player, "knight") {}

        public override List<Position> getValidMoves(Position position, Board board)
        {
            List<Position> positions = new List<Position>{
                position + new Position(2, 1),
                position + new Position(2, -1),
                position + new Position(1, 2),
                position + new Position(1, -2),
                position + new Position(-2, 1),
                position + new Position(-2, -1),
                position + new Position(-1, 2),
                position + new Position(-1, -2),
            };
            return positions;
        }
    }
}
