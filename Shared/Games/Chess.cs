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
            for (int x = 0; x < 8; x++)
            {
                board[x, 1] = new Pawn();
                board[x, 6] = new Pawn
                {
                    owner = 1
                };
            }

            rules.Add(new MirroredMovementRule());
            rules.Add(new AlternateMovementOnRow(typeof(Pawn), new JumpNoCapture(0, 2), new List<int> { 1 }));
            rules.Add(new NoCaptureOwnPiecesRule());
        }
    }
}
