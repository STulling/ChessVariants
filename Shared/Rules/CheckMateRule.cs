﻿using ChessVariants.Shared.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared.Rules
{
    public class CheckMateRule : CannotMoveIntoAttackRule
    {

        public CheckMateRule(List<Type> pieces) : base(pieces)
        { }

        public CheckMateRule(Type piece) : base(new List<Type> { piece })
        { }

        public override Game.Completion isGameOver(Game game)
        {
            /*Can any pieces move*/
            List<Position> piecePositions = game.GetOwnerPiecePositions(game.currentTurn);

            foreach (Position piecePos in piecePositions)
            {
                List<Move> moves = game.GenerateMoves(piecePos);
                if (moves.Count != 0) 
                {
                    return Game.Completion.None;
                }
            }

            /*Am I in check*/
            /*Yes: Mate*/
            foreach (Position piecePos in piecePositions)
            {
                if (pieces.Contains(game.board[piecePos].GetType())) 
                {
                    if (InCheck(piecePos, game))
                    {
                        return Game.Completion.Lose;
                    }
                }
            }
            /*No: Stalemate*/

            return Game.Completion.Draw;
        }
    }
}