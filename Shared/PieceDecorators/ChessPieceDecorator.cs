using ChessVariants.Shared.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared.PieceDecorators
{
    public class ChessPieceDecorator : PieceDecorator
    {
        public override List<Position> getValidMoves(Position position, Board board)
        {
            List<Position> positions = this.piece.getValidMoves(position, board);
            List<Position> validPositions = new List<Position>();
            foreach (Position pos in positions)
            {
                try
                {
                    Piece piece = board.getPiece(pos);
                    if (piece == null || piece.player != this.player)
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
