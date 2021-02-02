using ChessVariants.Shared.Base;
using ChessVariants.Shared.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessVariants.Server
{
    public class Match
    {
        public string Id { get; }
        public List<Player> Players { get; }
        public Player CurrentTurn { get => Players[game.currentTurn]; }
        public Game game { get; set; }

        public bool started;

        public Match(string id)
        {
            this.game = new Chess();
            this.Id = id;
            this.Players = new List<Player>();
        }
    }
}
