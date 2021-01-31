using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessVariants.Shared.Base;
using System;
using System.Collections.Generic;
using System.Text;
using ChessVariants.Shared.Games;

namespace ChessVariants.Shared.Base.Tests
{
    [TestClass()]
    public class GameTests
    {

        [TestMethod()]
        public void GenerateMovesTest()
        {
            Game game = new Chess();
            Position origPos = new Position(4, 1);
            Position newPos = new Position(4, 3);
            game.PlayMove(new Move(game.board[origPos], new Jump(new Position(0, 2)), origPos, newPos));
            game.PlayMove(new Move(game.board[4, 0], new Jump(new Position(0, 1)), new Position(4, 0), new Position(4, 1)));
        }
    }
}