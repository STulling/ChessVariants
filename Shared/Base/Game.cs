using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessVariants.Shared.Base
{
    public abstract class Game
    {
        public string Id { get; }

        public int currentTurn;

        public List<Rule> rules;

        public Board board;

        public Game()
        {
            this.rules = new List<Rule>();
        }

        public void ExecuteMove(Move move)
        {
             
        }

        public bool VerifyMove(Move move)
        {
            Piece piece = board[move.start];
            if (piece == null) return true;

            List<Move> possibleMoves = GenerateMoves(move.start);

            if (possibleMoves.Contains(move))
            {
                ExecuteMove(move);
                foreach (Rule rule in rules)
                {
                    rule.OnMovePlayed(move.start, board, move);
                }
                return true;
            }
            return false;
        }

        private void Cleanup(Position pos, List<Move> moves)
        {
            foreach (Rule rule in rules)
            {
                rule.OnCleanup(pos, board, moves);
            }
            foreach (Move move in moves)
            {
                if (!move.legal)
                {
                    moves.Remove(move);
                }
            }
        }

        private List<Move> GenerateMoves(Position pos)
        {
            List<Move> moves = new List<Move>();
            foreach (Rule rule in rules)
            {
                rule.OnPreRegularMoveGen(pos, board);
            }
            moves.AddRange(GenerateRegularMoves(pos));
            foreach (Rule rule in rules)
            {
                rule.OnPostRegularMoveGen(pos, moves);
            }
            Cleanup(pos, moves);
            return moves;
        }

        private List<Move> GenerateRegularMoves(Position pos)
        {
            List<Position> positions = new List<Position>();
            List<Move> result = new List<Move>();
            foreach (Movement movement in board[pos].movements)
            {
                foreach (Rule rule in rules)
                {
                    rule.OnPreMoveBeingGenerated(pos, board);
                }
                positions.AddRange(movement.getPositions(pos, board));
                foreach (Position end in movement.getPositions(pos, board))
                {
                    Move move = new Move(pos, end);
                    foreach (Rule rule in rules)
                    {
                        rule.OnPostMoveBeingGenerated(pos, board, move);
                    }
                    result.Add(move);
                }
            }
            return result;
        }
    }
}
