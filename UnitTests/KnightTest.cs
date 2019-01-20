using System.Collections.Generic;
using NUnit.Framework;
using SharpChess;
using SharpChess.Pieces;

namespace UnitTests {
    [TestFixture]
    public class KnightTest {
        public Game Game = new Game(
            new Dictionary<Square, IPiece> {
                ["e4"] = new Knight {Color = Color.White}
            }
        );

        [Test]
        public void MovesLikeAKnight() {
            var moves = Game.LegalDestinations("e4");
            moves.Print();
        }
    }
}