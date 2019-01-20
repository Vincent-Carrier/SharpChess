using System.Collections.Generic;

namespace SharpChess.Pieces {
    public struct King : IPiece {
        public List<Square> LegalDestinations(Game game, Square location) {
            var moves = new List<Square>();
            var (x, y) = location;
            
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    moves.Add((x+i, y+j));
                }
            }
            
//            moves.Where()
            return moves;
        }

        public Color Color { get; set; }
        public Square StartingLocation { get; set; }
    }
}