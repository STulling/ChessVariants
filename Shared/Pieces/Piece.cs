using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared.Pieces
{
    public abstract class Piece
    {
        public string name; //full name of the piece
        public string id; //few letters as abbreviation
        public Player player;
        public string image;

        public Piece(string name, string id, Player player, string image)
        {
            this.name = name; 
            this.id = id;
            this.player = player;
            this.image = image;
        }

        public abstract List<Position> getValidMoves(Position position, Board board);
        public virtual string getImage()
        {
            return $"{image}_{player.tag}.svg";
        }
    }
}
