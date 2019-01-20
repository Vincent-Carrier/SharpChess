using System;
using System.Collections.Generic;
using System.Text;
using SharpChess;

namespace UnitTests {
    public static class TestUtils {
        public static void Print(this List<Square> squares) {
            var sb = new StringBuilder();
            sb.Append("  A B C D E F G H\n");
            for (var j = 0; j < 8; j++) {
                sb.Append($"{8 - j} ");
                for (var i = 0; i < 8; i++) {
                    sb.Append(' ');
                    sb.Append(squares.Contains((i, j)) ? 'X' : 'O');
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb);
        }
    }
}