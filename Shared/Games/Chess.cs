using ChessVariants.Shared.Base;
using ChessVariants.Shared.Pieces;
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
                board[x, 6] = new Pawn { owner = 1};
            }
            board[1, 0] = new Knight();
            board[6, 0] = new Knight();
            board[1, 7] = new Knight { owner = 1 };
            board[6, 7] = new Knight { owner = 1 };

            board[0, 0] = new Tower();
            board[7, 0] = new Tower();
            board[0, 7] = new Tower { owner = 1 };
            board[7, 7] = new Tower { owner = 1 };

            board[2, 0] = new Bishop();
            board[5, 0] = new Bishop();
            board[2, 7] = new Bishop { owner = 1 };
            board[5, 7] = new Bishop { owner = 1 };

            board[4, 0] = new King();
            board[4, 7] = new King { owner = 1 };
            board[3, 0] = new Queen();
            board[3, 7] = new Queen { owner = 1 };

            rules.Add(new MirroredMovementRule());
            rules.Add(new AlternateMovementOnRow(typeof(Pawn), new JumpNoCapture(0, 2), new List<int> { 1 }));
            rules.Add(new NoCaptureOwnPiecesRule());
            rules.Add(new EnPassantRule());
        }
    }
}
