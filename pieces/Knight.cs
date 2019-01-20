using System.Collections.Generic;

namespace SharpChess.Pieces {
    public struct Knight : IPiece {
        public List<Square> LegalDestinations(Game game, Square location) {
            var (x, y) = location;

            // Going clockwise starting down-right
            var moves = new List<Square> {
                (x + 1, y + 2),
                (x - 1, y + 2),
                (x - 2, y + 1),
                (x - 2, y - 1),
                (x - 1, y - 2),
                (x + 1, y - 2),
                (x + 2, y - 1),
                (x + 2, y + 1)
            };

            foreach (var move in moves) {
                if (!move.IsInBounds() || game.Board[move]?.Color == game.ActivePlayer)
                    moves.Remove(move);
            }

            return moves;
        }

        public Color Color { get; set; }
        public Square StartingLocation { get; set; }
    }
}