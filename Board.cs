using System.Collections;
using System.Collections.Generic;
using SharpChess.Pieces;
using static SharpChess.Color;

namespace SharpChess {
    public class Board : IEnumerable<IPiece> {
        readonly Dictionary<IPiece, Square> _pieces = new Dictionary<IPiece, Square>(16);
        readonly IPiece[,] _board = new IPiece[8, 8];


        static readonly IPiece[] WHITE_PIECES = {
            new Rook(), new Knight(), new Bishop(), new Queen(),
            new King(), new Bishop(), new Knight(), new Rook()
        };

        static readonly IPiece[] BLACK_PIECES = {
            new Rook(), new Knight(), new Bishop(), new Queen(),
            new King(), new Bishop(), new Knight(), new Rook()
        };

        static Board() {
            for (var i = 0; i < 8; i++) {
                var piece = WHITE_PIECES[i];
                piece.Color = White;
                piece.StartingLocation = (i, 7);
                piece = BLACK_PIECES[i];
                piece.Color = Black;
                piece.StartingLocation = (i, 0);
            }
        }

        public Board() {
            for (var i = 0; i < 8; i++) {
                this[i, 0] = BLACK_PIECES[i];
                this[i, 1] = new Pawn {Color = Black, StartingLocation = (i, 1)};
                this[i, 6] = new Pawn {Color = White, StartingLocation = (i, 6)};
                this[i, 7] = WHITE_PIECES[i];
            }
        }

        public Board(Dictionary<Square, IPiece> setup) {
            foreach (var entry in setup) {
                var (x, y) = entry.Key;
                var piece = entry.Value;
                this[x, y] = piece;
            }
        }

        public Square this[IPiece piece] => _pieces[piece];
        public IPiece this[Square square] {
            get => this[square.x, square.y];
            set => this[square.x, square.y] = value;
        }

        public IPiece this[int x, int y] {
            get => _board[x, y];
            set {
                var captured = _board[x, y];
                if (captured != null) _pieces.Remove(captured);
                _board[x, y] = value;
                if (value != null) _pieces[value] = (x, y);
            }
        }

        public IEnumerator<IPiece> GetEnumerator() => _pieces.Keys.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) _pieces).GetEnumerator();
    }
}