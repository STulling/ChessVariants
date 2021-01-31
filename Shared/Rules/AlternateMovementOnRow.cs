using ChessVariants.Shared.Base;
using System;
using System.Collections.Generic;

namespace ChessVariants.Shared.Rules
{
    public  class AlternateMovementOnRow : Rule
    {
        private List<Type> types;
        private List<Movement> movements;
        private List<int> ranks;

        public AlternateMovementOnRow(List<Type> types, List<Movement> movements, List<int> ranks)
        {
            this.types = types;
            this.movements = movements;
            this.ranks = ranks;
        }

        public AlternateMovementOnRow(Type type, List<Movement> movement, List<int> rank) : this(new List<Type> { type }, movement, rank)
        { }

        public AlternateMovementOnRow(List<Type> type, Movement movement, List<int> rank) : this(type, new List<Movement> { movement }, rank)
        { }

        public AlternateMovementOnRow(Type type, Movement movement, List<int> rank) : this(new List<Type> { type }, new List<Movement> { movement }, rank) 
        { }

        public override void OnGenerateSpecialMoves(Position pos, Board board, List<Move> moves)
        {
            if (board[pos] == null) return;

            Piece piece = board[pos];
            if (types.Contains(piece.GetType()))
            {
                if (ranks.Contains(pos.y))
                {
                    foreach (Movement movement in movements)
                    {
                        foreach (Position end in movement.getPositions(pos, board))
                        {
                            moves.Add(new Move(board[pos], movement, pos, end));
                        }
                    }
                }
            }

            base.OnGenerateSpecialMoves(pos, board, moves);
        }
    }
}