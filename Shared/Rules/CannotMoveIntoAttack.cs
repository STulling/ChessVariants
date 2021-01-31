using ChessVariants.Shared.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared.Rules
{
    public class CannotMoveIntoAttack : Rule
    {
        private List<Type> pieces;

        private Piece[,] tmp;
        public CannotMoveIntoAttack(List<Type> pieces)
        {
            this.pieces = pieces;
            this.useInCheckCalculation = false;
        }

        public CannotMoveIntoAttack(Type piece) : this(new List<Type> { piece })
        { }

        public override void OnCleanup(Position pos, List<Move> moves, Game game)
        {
            if (pieces.Contains(game.board[pos].GetType()))
            {
                tmp = game.board.pieces.Clone() as Piece[,];
                foreach (Move move in moves)
                {
                    move.Execute(game.board);
                    if (game.InCheck(move.end))
                    {
                        move.legal = false;
                    }
                    game.board.pieces = tmp.Clone() as Piece[,];
                }
            }
            base.OnCleanup(pos, moves, game);
        }
    }
}
