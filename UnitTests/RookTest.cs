using System.Collections.Generic;
using NUnit.Framework;
using SharpChess;
using SharpChess.Pieces;

namespace UnitTests {
    [TestFixture]
    public class RookTest {
        public Game Game = new Game(new Dictionary<Square, IPiece> {
            ["e4"] = new Rook {Color = Color.White}
        });



        [Test]
        public void MovesLikeARook() {
            var moves = Game.LegalDestinations("e4");
            moves.Print();
        }
    }
}