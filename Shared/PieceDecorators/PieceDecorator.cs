using ChessVariants.Shared.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared
{
    public abstract class PieceDecorator : Piece
    {
        public Piece piece;
        public PieceDecorator(Piece piece)
        {
            this.id = piece.id;
            this.name = piece.name;
            this.player = piece.player;
            this.image = piece.image;
            this.piece = piece;
        }
    }
}
