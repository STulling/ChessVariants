using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessVariants.Server
{
    public class Player
    {
        public string ConnectionId { get; }

        public Player(string ConnectionId)
        {
            this.ConnectionId = ConnectionId;
        }
    }
}
