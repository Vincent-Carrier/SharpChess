using System.Collections.Generic;

namespace SharpChess {
    public interface IPiece {
        List<Square> LegalDestinations(Game game, Square location);
        Color Color { get; set; }
        Square StartingLocation { get; set; }
    }

    public enum Color {
        White = -1,
        Black = 1
    }
}