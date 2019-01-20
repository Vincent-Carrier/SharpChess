using System.Collections.Generic;

namespace SharpChess.Pieces {
    public struct Queen : IPiece {
        public List<Square> LegalDestinations(Game game, Square location) {
            var rookMoves = new Rook {Color = Color}.LegalDestinations(game, location);
            var bishopMoves = new Bishop {Color = Color}.LegalDestinations(game, location);

            rookMoves.AddRange(bishopMoves);

            return rookMoves;
        }

        public Color Color { get; set; }
        public Square StartingLocation { get; set; }
    }
}