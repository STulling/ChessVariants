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

        public List<Move> history;

        public Board board;

        public Game()
        {
            this.rules = new List<Rule>();
            this.history = new List<Move>();
        }

        private void ExecuteMove(Move move)
        {
            move.Execute(board);
        }

        public bool PlayMove(Move move)
        {
            Piece piece = board[move.start];
            if (piece == null) return false;

            List<Move> possibleMoves = GenerateMoves(move.start);

            if (possibleMoves.Contains(move))
            {
                ExecuteMove(move);
                history.Add(move);
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
                rule.OnCleanup(pos, board, moves, history);
            }
            moves.RemoveAll(move => !move.legal);
        }

        public List<Move> GenerateMoves(Position pos)
        {
            List<Move> moves = new List<Move>();
            if (board[pos] == null) return moves;

            foreach (Rule rule in rules)
            {
                rule.OnPreRegularMoveGen(pos, board, history);
            }
            moves.AddRange(GenerateRegularMoves(pos));
            foreach (Rule rule in rules)
            {
                rule.OnPostRegularMoveGen(pos, moves);
            }
            foreach (Rule rule in rules)
            {
                rule.OnGenerateSpecialMoves(pos, board, moves);
            }
            foreach (Rule rule in rules)
            {
                rule.OnGenerateSpecialMovesInvolvingHistory(pos, board, moves, history);
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
                    Move move = new Move(board[pos], movement, pos, end);
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
