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
                    rule.OnMovePlayed(move.start, move, this);
                }
                return true;
            }
            return false;
        }

        public bool InCheck(Position pos)
        {
            List<Position> otherPositions = GetAllOtherPiecePositions(board[pos].owner);
            foreach (Position piecePos in otherPositions)
            {
                List<Move> moves = GenerateMoves(piecePos, true);
                if (moves.Any(x => x.end == pos))
                {
                    return true;
                }
            }
            return false;
        }

        private void Cleanup(Position pos, List<Move> moves, bool check)
        {
            foreach (Rule rule in rules)
            {
                if (!check || (check && rule.useInCheckCalculation))
                    rule.OnCleanup(pos, moves, this);
            }
            foreach (Rule rule in rules)
            {
                if (!check || (check && rule.useInCheckCalculation))
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

        public List<Move> GenerateMoves(Position pos, bool check = false)
        {
            List<Move> moves = new List<Move>();
            if (board[pos] == null) return moves;
            foreach (Rule rule in rules)
            {
                if (!check || (check && rule.useInCheckCalculation))
                    rule.OnModifyBoard(pos, this);
            }
            foreach (Rule rule in rules)
            {
                if (!check || (check && rule.useInCheckCalculation))
                    rule.OnPreRegularMoveGen(pos, this);
            }
            moves.AddRange(GenerateRegularMoves(pos, check));
            foreach (Rule rule in rules)
            {
                if (!check || (check && rule.useInCheckCalculation))
                    rule.OnPostRegularMoveGen(pos, moves, this);
            }
            foreach (Rule rule in rules)
            {
                if (!check || (check && rule.useInCheckCalculation))
                    rule.OnGenerateSpecialMoves(pos, moves, this);
            }
            Cleanup(pos, moves, check);
            return moves;
        }

        private List<Move> GenerateRegularMoves(Position pos, bool check)
        {
            List<Position> positions = new List<Position>();
            List<Move> result = new List<Move>();
            foreach (Movement movement in board[pos].movements)
            {
                foreach (Rule rule in rules)
                {
                    if (!check || (check && rule.useInCheckCalculation))
                        rule.OnPreMoveBeingGenerated(pos, this);
                }
                positions.AddRange(movement.getPositions(pos, board));
                foreach (Position end in movement.getPositions(pos, board))
                {
                    Move move = new Move(board[pos], movement, pos, end);
                    foreach (Rule rule in rules)
                    {
                        if (!check || (check && rule.useInCheckCalculation))
                            rule.OnPostMoveBeingGenerated(pos, move, this);
                    }
                    result.Add(move);
                }
            }
            return result;
        }
    }
}
