using System.Collections.Generic;

namespace SharpChess {
    public interface IPiece {
        Color Color { get; set; }
        Square StartingLocation { get; set; }
        List<Square> LegalDestinations(Game game, Square location);
    }

    public enum Color {
        White = -1,
        Black = 1
    }
}