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

    public class Jump : Movement
    {
        private Position stepOffset;
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
    }

    public class JumpIfCapture : Movement
    {
        private Position stepOffset;
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
    }
}
