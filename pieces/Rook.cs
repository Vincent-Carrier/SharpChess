using System.Collections.Generic;

namespace SharpChess.Pieces {
    public struct Rook : IPiece {
        public List<Square> LegalDestinations(Game game, Square location) {
            var board = game.Board;
            var moves = new List<Square>();
            var (x, y) = location;

            // Clockwise starting from upward
            for (var i = y - 1; i >= 0; i--) {
                var color = board[x, i]?.Color;
                if (color == game.ActivePlayer) break;
                moves.Add((x, i));
                if (color == game.PassivePlayer) break;
            }

            for (var i = x + 1; i <= 7; i++) {
                var color = board[i, y]?.Color;
                if (color == game.ActivePlayer) break;
                moves.Add((i, y));
                if (color == game.PassivePlayer) break;
            }

            for (var i = y + 1; i <= 7; i++) {
                var color = board[x, i]?.Color;
                if (color == game.ActivePlayer) break;
                moves.Add((x, i));
                if (color == game.PassivePlayer) break;
            }

            for (var i = x - 1; i >= 0; i--) {
                var color = board[i, y]?.Color;
                if (color == game.ActivePlayer) break;
                moves.Add((i, y));
                if (color == game.PassivePlayer) break;
            }

            return moves;
        }

        public Color Color { get; set; }
        public Square StartingLocation { get; set; }
    }
}