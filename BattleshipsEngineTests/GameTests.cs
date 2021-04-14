using System;
using Xunit;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class GameTests
    {
        [Fact]
        public void gameInitializer()
        {
            var game = new Game();
            Assert.Null(game.GetBattlefield());
            game.Initialize();
            Assert.NotNull(game.GetBattlefield());
            Assert.NotNull(game.GetBattlefield().GetField(0, 5));
        }

        [Fact]
        public void shooting()
        {
            var game = new Game();
            string coordinates = "A5";
            //game.shoot(coordinates); void or what?
        }
    }
}
