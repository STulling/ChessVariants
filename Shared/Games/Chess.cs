using ChessVariants.Shared.Base;
using ChessVariants.Shared.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared.Games
{
    public class Chess : Game
    {
        public Chess() : base()
        {
            board = new Board(8, 8);
            board[4, 4] = new Pawn();
            board[5, 5] = new Pawn();
            board[5, 5].owner = 1;

            rules.Add(new MirroredMovementRule());
        }
    }
}
