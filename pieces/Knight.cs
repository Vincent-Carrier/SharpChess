using System.Collections.Generic;
using System.Linq;

namespace SharpChess.Pieces {
    public struct Knight : IPiece {
        public List<Square> LegalDestinations(Game game, Square location) {
            var (x, y) = location;

            // Going clockwise starting down-right
            Square[] destinations = {
                (x + 1, y + 2),
                (x - 1, y + 2),
                (x - 2, y + 1),
                (x - 2, y - 1),
                (x - 1, y - 2),
                (x + 1, y - 2),
                (x + 2, y - 1),
                (x + 2, y + 1)
            };

            return destinations.Where(
                    move => move.IsInBounds() &&
                            game.Board[move]
                                ?.Color != game.ActivePlayer
                )
                .ToList();
        }

        public Color Color { get; set; }
        public Square StartingLocation { get; set; }
    }
}