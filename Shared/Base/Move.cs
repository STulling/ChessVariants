﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared.Base
{
    public class Move : IEquatable<Move>
    {
        public Piece piece { get; set; }
        public Movement movement { get; set; }
        public Position start { get; set; }
        public Position end { get; set; }
        public bool legal = true;

        public Move() { }

        public Move(Piece piece, Movement movement, Position start, Position end)
        {
            this.piece = piece;
            this.movement = movement;
            this.start = start;
            this.end = end;
        }

        public virtual void Execute(Board board)
        {
            board[start] = null;
            board[end] = piece;
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
                   EqualityComparer<Movement>.Default.Equals(movement, other.movement) &&
                   EqualityComparer<Position>.Default.Equals(start, other.start) &&
                   EqualityComparer<Position>.Default.Equals(end, other.end) &&
                   legal == other.legal;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(piece, movement, start, end, legal);
        }

        public static bool operator ==(Move left, Move right)
        {
            return EqualityComparer<Move>.Default.Equals(left, right);
        }

        public static bool operator !=(Move left, Move right)
        {
            return !(left == right);
        }
    }

    public class IndirectCapturingMove : Move, IEquatable<IndirectCapturingMove>
    {
        public Position capture;
        public IndirectCapturingMove() { }

        public IndirectCapturingMove(Piece piece, Position start, Position end, Position capture)
        {
            this.piece = piece;
            this.start = start;
            this.end = end;
            this.capture = capture;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as IndirectCapturingMove);
        }

        public bool Equals(IndirectCapturingMove other)
        {
            return other != null &&
                   base.Equals(other) &&
                   EqualityComparer<Piece>.Default.Equals(piece, other.piece) &&
                   EqualityComparer<Movement>.Default.Equals(movement, other.movement) &&
                   EqualityComparer<Position>.Default.Equals(start, other.start) &&
                   EqualityComparer<Position>.Default.Equals(end, other.end) &&
                   legal == other.legal &&
                   EqualityComparer<Position>.Default.Equals(capture, other.capture);
        }

        public override void Execute(Board board)
        {
            board[capture] = null;
            base.Execute(board);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), piece, movement, start, end, legal, capture);
        }

        public override string ToString()
        {
            return $"{piece.GetType().Name}: {start} -> {end} , capturing:{capture}";
        }

        public static bool operator ==(IndirectCapturingMove left, IndirectCapturingMove right)
        {
            return EqualityComparer<IndirectCapturingMove>.Default.Equals(left, right);
        }

        public static bool operator !=(IndirectCapturingMove left, IndirectCapturingMove right)
        {
            return !(left == right);
        }
    }
}
