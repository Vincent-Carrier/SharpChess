using System;
using System.Collections.Generic;
using System.Linq;
using static SharpChess.Color;

namespace SharpChess.Pieces {
    public struct Pawn : IPiece {
        public List<Square> LegalDestinations(Game game, Square location) {
            var moves = new List<Square>();
            var (board, history) = game;
            var (x, y) = location;

            var pawnRow = Color == White ? 6 : 1;
            moves.Add((x, y + 1 * (int) Color));
            if (y == pawnRow) moves.Add((x, y + 2 * (int) Color));

            moves.AddRange(
                new[] {
                        (x - 1, y + 1 * (int) Color),
                        (x + 1, y + 1 * (int) Color)
                    }.Where(
                        square => {
                            var (x1, y1) = (Square) square;
                            return board[x1, y1]?.Color == game.PassivePlayer;
                        }
                    )
                    .Select(square => (Square) square)
            );

            return moves;
        }

        public void EnPassant() {
            throw new NotImplementedException();
        }

        public void Promote() { }

        public Color Color { get; set; }
        public Square StartingLocation { get; set; }
    }
}