using ChessVariants.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessVariants.Shared.Rules
{
    public class CannotMoveIntoAttackRule : Rule
    {
        private List<Type> pieces;

        private Piece[,] tmp;
        public CannotMoveIntoAttackRule(List<Type> pieces)
        {
            this.pieces = pieces;
            this.useInCheckCalculation = false;
        }

        public CannotMoveIntoAttackRule(Type piece) : this(new List<Type> { piece })
        { }

        public override void OnCleanup(Position pos, List<Move> moves, Game game)
        {
            int owner = game.board[pos].owner;
            tmp = game.board.pieces.Clone() as Piece[,];
            foreach (Type pieceType in pieces)
            {
                foreach (Move move in moves)
                {
                    move.Execute(game.board);
                    foreach (Position targetPos in game.GetPiecePositions(pieceType, owner))
                    {
                        if (InCheck(targetPos, game))
                        {
                            move.legal = false;
                        }
                    }
                    game.board.pieces = tmp.Clone() as Piece[,];
                }
            }
            base.OnCleanup(pos, moves, game);
        }

        private bool InCheck(Position pos, Game game)
        {
            List<Rule> rules = Clone(game.rules) as List<Rule>;
            game.rules = game.rules.FindAll(x => x.GetType() != this.GetType());
            List<Position> otherPositions = game.GetAllOtherPiecePositions(game.board[pos].owner);
            foreach (Position piecePos in otherPositions)
            {
                List<Move> moves = game.GenerateMoves(piecePos);
                if (moves.Any(x => x.end == pos))
                {
                    game.rules = rules;
                    return true;
                }
            }
            game.rules = rules;
            return false;
        }
        private IList<T> Clone<T>(IList<T> listToClone)
        {
            return listToClone.Select(item => item).ToList();
        }

    }
}
