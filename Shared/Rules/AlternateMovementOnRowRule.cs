using ChessVariants.Shared.Base;
using System;
using System.Collections.Generic;

namespace ChessVariants.Shared.Rules
{
    public  class AlternateMovementOnRowRule : Rule
    {
        private List<Type> types;
        private List<Movement> movements;
        private List<int> ranks;

        public AlternateMovementOnRowRule(List<Type> types, List<Movement> movements, List<int> ranks)
        {
            this.types = types;
            this.movements = movements;
            this.ranks = ranks;
        }

        public AlternateMovementOnRowRule(Type type, List<Movement> movement, List<int> rank) : this(new List<Type> { type }, movement, rank)
        { }

        public AlternateMovementOnRowRule(List<Type> type, Movement movement, List<int> rank) : this(type, new List<Movement> { movement }, rank)
        { }

        public AlternateMovementOnRowRule(Type type, Movement movement, List<int> rank) : this(new List<Type> { type }, new List<Movement> { movement }, rank) 
        { }

        public override void OnGenerateSpecialMoves(Position pos, List<Move> moves, Game game)
        {
            if (game.board[pos] == null) return;

            Piece piece = game.board[pos];
            if (types.Contains(piece.GetType()))
            {
                if (ranks.Contains(pos.y))
                {
                    foreach (Movement movement in movements)
                    {
                        foreach (Position end in movement.getPositions(pos, game.board))
                        {
                            moves.Add(new Move(game.board[pos], movement, pos, end));
                        }
                    }
                }
            }

            base.OnGenerateSpecialMoves(pos, moves, game);
        }
    }
}