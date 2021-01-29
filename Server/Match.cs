using ChessVariants.Shared.Base;
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
        public Player CurrentTurn { get; set; }
        public Game game { get; set; }

        public Match(string id)
        {
            this.Id = id;
            this.Players = new List<Player>();
        }
    }
}
