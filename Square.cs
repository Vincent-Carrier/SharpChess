using System;

namespace SharpChess {
    public struct Square {
        public readonly int x, y;

        public Square(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public void Deconstruct(out int x, out int y) {
            x = this.x;
            y = this.y;
        }

        public static implicit operator Square(ValueTuple<int, int> tuple) {
            var (x, y) = tuple;
            return new Square(x, y);
        }

        public static implicit operator Square(string s) {
            var x = int.Parse((s[0] - 'a').ToString());
            var y = 8 - int.Parse(s.Substring(1, 1));

            var square = new Square(x, y);
            if (!square.IsInBounds()) throw new ArgumentOutOfRangeException();

            return square;
        }

        public override string ToString() {
            return $"{(char) x + 'A'}{8 - y}";
        }
    }
}