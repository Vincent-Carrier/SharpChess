using System.Collections.Generic;

namespace SharpChess.Pieces {
    public struct Bishop : IPiece {
        public List<Square> LegalDestinations(Game game, Square location) {
            var moves = new List<Square>();
            var (x, y) = location;

            // Clockwise starting from up-right
            for (int i = x + 1, j = y - 1; i <= 7 && j >= 0; i++, j--) {
                var color = game.Board[i, j]?.Color;
                if (color == game.ActivePlayer) break;
                moves.Add((i, j));
                if (color == game.PassivePlayer) break;
            }

            for (int i = x + 1, j = y + 1; i <= 7 && j <= 7; i++, j++) {
                var color = game.Board[i, j]?.Color;
                if (color == game.ActivePlayer) break;
                moves.Add((i, j));
                if (color == game.PassivePlayer) break;
            }

            for (int i = x - 1, j = y + 1; i >= 0 && j <= 7; i--, j++) {
                var color = game.Board[i, j]?.Color;
                if (color == game.ActivePlayer) break;
                moves.Add((i, j));
                if (color == game.PassivePlayer) break;
            }

            for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--) {
                var color = game.Board[i, j]?.Color;
                if (color == game.ActivePlayer) break;
                moves.Add((i, j));
                if (color == game.PassivePlayer) break;
            }

            return moves;
        }

        public Color Color { get; set; }
        public Square StartingLocation { get; set; }
    }
}