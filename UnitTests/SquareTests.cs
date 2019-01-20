using System.Collections.Generic;
using NUnit.Framework;
using SharpChess;

namespace UnitTests {
    [TestFixture]
    public class SquareTests {
        Board _board = new Board();

        [Test]
        public void StringToSquare() {
            var e4 = new List<Square> {"e4"};
            e4.Print();
        }
    }
}