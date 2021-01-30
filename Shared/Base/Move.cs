using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared.Base
{
    public class Move
    {
        public Position start { get; set; }
        public Position end { get; set; }
        public bool legal = true;

        public Move() { }

        public Move(Position start, Position end)
        {
            this.start = start;
            this.end = end;
        }
    }
}
