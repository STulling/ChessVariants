using ChessVariants.Shared.Base;
using ChessVariants.Shared.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessVariants.Shared.Rules
{
    public class EnPassantRule : ConditionalCaptureRule
    {
        public EnPassantRule() :
            base(
                new List<Type> { typeof(Pawn) },
                new List<Type> { typeof(Pawn) },
                new List<Movement>{ new LimitedSlideNoCapture(0, 1, 2) }, 
                new Dictionary<Position, Movement>()
                {
                    { new Position(1, 0),  new Jump(1,1)},
                    { new Position(-1, 0), new Jump(-1,1)}
                }
            )
        {
        }
    }
}
