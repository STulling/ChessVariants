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
            Position origPos = new Position(1, 6);
            Position newPos = new Position(1, 4);
            Console.WriteLine(game.board.ToString());
            game.PlayMove(new Move(game.board[origPos], origPos, newPos));
            Console.WriteLine(game.board.ToString());
            List<Move> moves = game.GenerateMoves(newPos);
            Assert.AreEqual(new Position(1, 4), newPos);
            Console.WriteLine(game.board.ToString());
            Console.WriteLine(string.Join(", ", moves));
            foreach (Move move in moves)
            {
                Assert.AreEqual(newPos, move.start);
            }
        }
    }
}