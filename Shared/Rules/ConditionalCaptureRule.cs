using ChessVariants.Shared.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared.Rules
{
    public class ConditionalCaptureRule : Rule
    {
        private List<Type> pieces;
        private List<Type> targets;
        private List<Movement> movements_of_targets;
        private Dictionary<Position, Movement> capturing_moves;

        public override void OnGenerateSpecialMovesInvolvingHistory(Position pos, Board board, List<Move> moves, List<Move> history)
        {
            if (history.Count > 0)
            {
                Move lastMove = history[^1];
                if (pieces.Contains(lastMove.piece.GetType()))
                {

                }
            }
            base.OnGenerateSpecialMovesInvolvingHistory(pos, board, moves, history);
        }
    }
}
