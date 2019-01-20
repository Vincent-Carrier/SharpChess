using System;
using static SharpChess.MoveType;

namespace SharpChess {
    public struct Move {
        public Square From { get; set; }
        public Square To { get; set; }
        public MoveType Type { get; set; }
        public IPiece Captured { get; set; }

        public void Deconstruct(out Square from, out Square to, out MoveType type, out IPiece captured) {
            from = From;
            to = To;
            type = Type;
            captured = Captured;
        }

        public void Undo(Board board) {
            switch (Type) {
                case Normal:
                    var moved = board[To];
                    board[To] = Captured;
                    board[From] = moved;
                    break;

                // TODO
                case QueenSideCastle: break;
                case KingSideCastle: break;
                case EnPassant: break;
                case Promotion: break;
                default: throw new ArgumentOutOfRangeException();
            }
        }


        public static implicit operator Move(ValueTuple<Square, Square> tuple) {
            var (from, to) = tuple;
            return new Move {From = from, To = to, Type = Normal};
        }
    }

    public enum MoveType {
        Normal,
        QueenSideCastle,
        KingSideCastle,
        EnPassant,
        Promotion
    }
}