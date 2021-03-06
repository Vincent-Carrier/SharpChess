using System.Collections.Generic;
using NUnit.Framework;
using SharpChess;
using SharpChess.Pieces;

namespace UnitTests {
    [TestFixture]
    public class QueenTest {
        public Game Game = new Game(new Dictionary<Square, IPiece> {
            ["e4"] = new Queen {Color = Color.White}
        });


        [Test]
        public void MovesLikeAQueen() {
            var moves = Game.LegalDestinations("e4");
            moves.Print();
        }
    }
}