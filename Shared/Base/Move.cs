using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared.Base
{
    public class Move : IEquatable<Move>
    {
        public Piece piece { get; set; }
        public Position start { get; set; }
        public Position end { get; set; }
        public bool legal = true;

        public Move() { }

        public Move(Piece piece, Position start, Position end)
        {
            this.piece = piece;
            this.start = start;
            this.end = end;
        }

        public override string ToString()
        {
            return $"{piece.GetType().Name}: {start} -> {end}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Move);
        }

        public bool Equals(Move other)
        {
            return other != null &&
                   EqualityComparer<Piece>.Default.Equals(piece, other.piece) &&
                   EqualityComparer<Position>.Default.Equals(start, other.start) &&
                   EqualityComparer<Position>.Default.Equals(end, other.end) &&
                   legal == other.legal;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(piece, start, end, legal);
        }
    }
}
