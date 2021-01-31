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

        public ConditionalCaptureRule(List<Type> pieces, List<Type> targets, List<Movement> movements_of_targets, Dictionary<Position, Movement> capturing_moves)
        {
            this.pieces = pieces;
            this.targets = targets;
            this.movements_of_targets = movements_of_targets;
            this.capturing_moves = capturing_moves;
        }

        public override void OnGenerateSpecialMoves(Position pos, List<Move> moves, Game game)
        {
            if (game.history.Count > 0)
            {
                Move lastMove = game.history[^1];
                if (movements_of_targets.Contains(lastMove.movement) && targets.Contains(lastMove.piece.GetType()) && pieces.Contains(game.board[pos].GetType()))
                {
                    Position offset = lastMove.end - pos;
                    if (capturing_moves.TryGetValue(offset, out Movement newMovement))
                    {
                        foreach (Position end in newMovement.getPositions(pos, game.board))
                        {
                            moves.Add(new IndirectCapturingMove(game.board[pos], pos, end, lastMove.end));
                        }
                    }
                }
            }
            base.OnGenerateSpecialMoves(pos, moves, game);
        }
    }
}
