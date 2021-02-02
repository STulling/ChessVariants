using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessVariants.Shared.Base;
using System;
using System.Collections.Generic;
using System.Text;
using ChessVariants.Shared.Games;
using ChessVariants.Shared.Pieces;

namespace ChessVariants.Shared.Base.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void PinnedPawnTest()
        {
            Game game = new Chess();
            game.board.Clear();
            game.board[0, 0] = new King();
            game.board[1, 1] = new Pawn();
            game.board[3, 3] = new Queen { owner = 1 };
            List<Move> moves = game.GenerateMoves(new Position(1, 1));
            Assert.AreEqual(0, moves.Count);
        }
    }
}