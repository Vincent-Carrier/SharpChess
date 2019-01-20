using System;
using System.Collections.Generic;
using System.Text;
using SharpChess.Pieces;
using static SharpChess.Color;
using static SharpChess.MoveType;

namespace SharpChess {
    public class Game {
        public readonly Board Board;

        public Game() {
            Board = new Board();
        }

        public Game(Dictionary<Square, IPiece> setup) {
            Board = new Board(setup);
        }

        public void Deconstruct(out Board board, out Stack<Move> history) {
            board = Board;
            history = History;
        }

        public bool Play(Move move) {
            if (!IsLegalMove(move)) return false;
            Execute(move);
            History.Push(move);
            UndoHistory.Clear();
            return true;
        }

        public bool IsLegalMove(Move move) {
            if (Board[move.From]?.Color != ActivePlayer ||
                !LegalDestinations(move.From).Contains(move.To)) return false;

            switch (move.Type) {
                case Normal:
                case EnPassant:
                case Promotion:
                    return !ExposesKing();
                case KingSideCastle:
                    throw new NotImplementedException();
                case QueenSideCastle:
                    throw new NotImplementedException();

                default:
                    throw new ArgumentException();
            }

            bool ExposesKing() {
                foreach (var piece in Board)
                    if (piece.Color == PassivePlayer &&
                        (piece is Bishop || piece is Rook || piece is Queen) &&
                        LegalDestinations(Board[piece]).Contains(King(ActivePlayer)))
                        return true;

                return false;

                Square King(Color color) {
                    return Board[new King {
                        Color = color,
                        StartingLocation = color == White ? "e1" : "e8"
                    }];
                }
            }
        }

        void Execute(Move move) {
            switch (move.Type) {
                case Normal:
                    move.Captured = Board[move.To];
                    Execute(move.From, move.To);
                    break;
                case EnPassant:
                    throw new NotImplementedException();
                    break;
                case KingSideCastle:
                    throw new NotImplementedException();
                    break;
                case QueenSideCastle:
                    throw new NotImplementedException();
                    break;
            }

            void Execute(Square from, Square to) {
                var (oldX, oldY) = from;
                var (x, y) = to;

                Board[x, y] = Board[from];
                Board[oldX, oldY] = null;
            }
        }

        public List<Square> LegalDestinations(Square location) {
            return Board[location].LegalDestinations(this, location);
        }

        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append("   A B C D E F G H\n");
            for (var j = 0; j < 8; j++) {
                sb.Append($"{8 - j} ");
                for (var i = 0; i < 8; i++) {
                    var piece = Board[i, j];
                    sb.Append(' ');
                    sb.Append(piece?.ToChar() ?? ' ');
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public bool IsCheckmate() {
            // TODO
            return false;
        }

        #region History

        public readonly Stack<Move> History = new Stack<Move>();
        public readonly Stack<Move> UndoHistory = new Stack<Move>();

        public Color ActivePlayer => History.Count % 2 == 0 ? White : Black;
        public Color PassivePlayer => History.Count % 2 == 1 ? White : Black;

        public void Undo() {
            if (History.Count == 0) return;
            var move = History.Pop();
            UndoHistory.Push(move);
            move.Undo(Board);
        }

        public void Redo() {
            if (UndoHistory.Count == 0) return;
            var move = UndoHistory.Pop();
            Execute(move);
            History.Push(move);
        }

        #endregion
    }
}