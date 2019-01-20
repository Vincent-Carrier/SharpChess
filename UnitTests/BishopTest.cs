using System.Collections.Generic;
using NUnit.Framework;
using SharpChess;
using SharpChess.Pieces;

namespace UnitTests {
    [TestFixture]
    public class BishopTest {
        public Game Game = new Game(
            new Dictionary<Square, IPiece> {
                ["e4"] = new Bishop {Color = Color.White}
            }
        );

        [Test]
        public void MovesLikeABishop() {
            var moves = Game.LegalDestinations("e4");
            moves.Print();
        }
    }
}