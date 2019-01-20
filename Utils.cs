using SharpChess.Pieces;
using static SharpChess.MoveType;

namespace SharpChess {
    public static class Utils {
        public static bool IsInRange(this int n, int lower, int upper) => n >= lower && n <= upper;


        public static Move Parse(this Game game, string s) {
            var (board, _) = game;

            if (s == "O-O") return new Move {Type = KingSideCastle};
            if (s == "O-O-O") return new Move {Type = QueenSideCastle};

            var from = s.Substring(0, 2);
            var dest = s.Substring(3);
            var capture = board[dest];

            return new Move {
                From = from,
                To = dest,
                Type = Normal,
                Captured = capture
            };
        }

        public static char ToChar(this IPiece piece) {
            var letter = piece.GetType().Name[0];
            if (piece is Knight) letter = 'N';
            if (piece.Color == Color.Black) letter = char.ToLower(letter);
            return letter;
        }

        public static bool IsInBounds(this Square square) =>
            square.x.IsInRange(0, 7) && square.y.IsInRange(0, 7);
    }
}