using System.Collections.Generic;

namespace SharpChess.Pieces {
    public struct King : IPiece {
        public List<Square> LegalDestinations(Game game, Square location) {
            var moves = new List<Square>();
            var (x, y) = location;

            for (var i = -1; i <= 1; i++)
            for (var j = -1; j <= 1; j++) {
                Square candidate = (x + i, y + j);
                if (candidate.IsInBounds() &&
                    game.Board[candidate]?.Color != game.ActivePlayer)
                    moves.Add(candidate);
            }

            // TODO: Avoid checks

            return moves;
        }

        public Color Color { get; set; }
        public Square StartingLocation { get; set; }
    }
}