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
        public bool checkCalculation = false;

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
                    rule.OnMovePlayed(move.start, move, this);
                }
                return true;
            }
            return false;
        }

        public List<Position> GetPiecePositions(Type pieceType, int owner)
        {
            List<Position> result = new List<Position>();
            for (int x = 0; x < board.width; x++)
            {
                for (int y = 0; y < board.height; y++)
                {
                    if (board[x, y] == null) continue;
                    Piece piece = board[x, y];
                    if (piece.owner == owner && piece.GetType().Equals(pieceType))
                    {
                        result.Add(new Position(x, y));
                    }
                }
            }
            return result;
        }

        private void Cleanup(Position pos, List<Move> moves)
        {
            foreach (Rule rule in rules)
            {
                rule.OnCleanup(pos, moves, this);
            }
            foreach (Rule rule in rules)
            {
                rule.OnUnmodifyBoard(pos, moves, this);
            }
            moves.RemoveAll(move => !move.legal);
        }

        public List<Position> GetAllOtherPiecePositions(int owner)
        {
            List<Position> result = new List<Position>();
            for (int x = 0; x < board.width; x++)
            {
                for (int y = 0; y < board.height; y++)
                {
                    if (board[x, y] == null) continue;
                    Piece piece = board[x, y];
                    if (piece.owner != owner)
                    {
                        result.Add(new Position(x, y));
                    }
                }
            }
            return result;
        }

        public List<Move> GenerateMoves(Position pos)
        {
            List<Move> moves = new List<Move>();
            if (board[pos] == null) return moves;
            foreach (Rule rule in rules)
            {
                rule.OnModifyBoard(pos, this);
            }
            foreach (Rule rule in rules)
            {
                rule.OnPreRegularMoveGen(pos, this);
            }
            moves.AddRange(GenerateRegularMoves(pos));
            foreach (Rule rule in rules)
            {
                rule.OnPostRegularMoveGen(pos, moves, this);
            }
            foreach (Rule rule in rules)
            {
                rule.OnGenerateSpecialMoves(pos, moves, this);
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
                    rule.OnPreMoveBeingGenerated(pos, this);
                }
                positions.AddRange(movement.getPositions(pos, board));
                foreach (Position end in movement.getPositions(pos, board))
                {
                    Move move = new Move(board[pos], movement, pos, end);
                    foreach (Rule rule in rules)
                    {
                        rule.OnPostMoveBeingGenerated(pos, move, this);
                    }
                    result.Add(move);
                }
            }
            return result;
        }
    }
}
