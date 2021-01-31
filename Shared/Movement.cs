using ChessVariants.Shared.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared
{
    public abstract class Movement
    {
        public abstract List<Position> getPositions(Position position, Board board);
    }

    public class Jump : Movement, IEquatable<Jump>
    {
        private Position stepOffset { get; set; }
        public Jump(Position offset)
        {
            stepOffset = offset;
        }

        public Jump(int x, int y)
        {
            stepOffset = new Position(x, y);
        }

        public override List<Position> getPositions(Position position, Board board)
        {
            Position result = position + stepOffset;
            if (board.inBounds(result))
            {
                return new List<Position>() { result };
            }
            else
            {
                return new List<Position>();
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Jump);
        }

        public bool Equals(Jump other)
        {
            return other != null &&
                   EqualityComparer<Position>.Default.Equals(stepOffset, other.stepOffset);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(stepOffset);
        }

        public static bool operator ==(Jump left, Jump right)
        {
            return EqualityComparer<Jump>.Default.Equals(left, right);
        }

        public static bool operator !=(Jump left, Jump right)
        {
            return !(left == right);
        }
    }

    public class JumpNoCapture : Movement, IEquatable<JumpNoCapture>
    {
        private Position stepOffset { get; set; }
        public JumpNoCapture(Position offset)
        {
            stepOffset = offset;
        }

        public JumpNoCapture(int x, int y)
        {
            stepOffset = new Position(x, y);
        }

        public override List<Position> getPositions(Position position, Board board)
        {
            Position result = position + stepOffset;
            if (board.inBounds(result) && board[result] == null)
            {
                return new List<Position>() { result };
            }
            else
            {
                return new List<Position>();
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as JumpNoCapture);
        }

        public bool Equals(JumpNoCapture other)
        {
            return other != null &&
                   EqualityComparer<Position>.Default.Equals(stepOffset, other.stepOffset);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(stepOffset);
        }

        public static bool operator ==(JumpNoCapture left, JumpNoCapture right)
        {
            return EqualityComparer<JumpNoCapture>.Default.Equals(left, right);
        }

        public static bool operator !=(JumpNoCapture left, JumpNoCapture right)
        {
            return !(left == right);
        }
    }

    public class JumpIfCapture : Movement, IEquatable<JumpIfCapture>
    {
        private Position stepOffset { get; set; }
        public JumpIfCapture(Position offset)
        {
            stepOffset = offset;
        }
        public JumpIfCapture(int x, int y)
        {
            stepOffset = new Position(x, y);
        }

        public override List<Position> getPositions(Position position, Board board)
        {
            Position result = position + stepOffset;
            if (board.inBounds(result) && board[result] != null)
            {
                return new List<Position>() { result };
            }
            else
            {
                return new List<Position>();
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as JumpIfCapture);
        }

        public bool Equals(JumpIfCapture other)
        {
            return other != null &&
                   EqualityComparer<Position>.Default.Equals(stepOffset, other.stepOffset);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(stepOffset);
        }

        public static bool operator ==(JumpIfCapture left, JumpIfCapture right)
        {
            return EqualityComparer<JumpIfCapture>.Default.Equals(left, right);
        }

        public static bool operator !=(JumpIfCapture left, JumpIfCapture right)
        {
            return !(left == right);
        }
    }

    public class Slide : Movement, IEquatable<Slide>
    {
        private Position stepOffset { get; set; }
        public Slide(Position offset)
        {
            stepOffset = offset;
        }
        public Slide(int x, int y)
        {
            stepOffset = new Position(x, y);
        }

        public override List<Position> getPositions(Position position, Board board)
        {
            List<Position> allPositions = new List<Position>();
            Position sample = position + stepOffset;
            while (board.inBounds(sample) && board[sample] == null)
            {
                allPositions.Add(sample);
                sample += stepOffset;
            }
            return allPositions;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Slide);
        }

        public bool Equals(Slide other)
        {
            return other != null &&
                   EqualityComparer<Position>.Default.Equals(stepOffset, other.stepOffset);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(stepOffset);
        }

        public static bool operator ==(Slide left, Slide right)
        {
            return EqualityComparer<Slide>.Default.Equals(left, right);
        }

        public static bool operator !=(Slide left, Slide right)
        {
            return !(left == right);
        }
    }
}
