using NUnit.Framework;
using SharpChess;

namespace UnitTests {
    [TestFixture]
    public class GameTest {

        public Game Game = new Game();

        [Test]
        public void PawnToE4() {
            Game.Parse("e2-e4");
        }
    }
}