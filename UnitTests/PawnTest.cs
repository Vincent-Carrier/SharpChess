using System;
using NUnit.Framework;
using SharpChess;

namespace UnitTests {
    [TestFixture]
    public class PawnTest {
        public Game Game = new Game();

        [Test]
        public void ForwardPawn() {
            var moves = Game.LegalDestinations("e2");
            moves.Print();
            Assert.True(Game.Play(("e2", "e4")));
            Console.WriteLine(Game);
        }
    }
}