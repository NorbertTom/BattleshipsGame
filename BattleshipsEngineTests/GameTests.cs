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
            game.Initialize();

            string coordinates = "A5";
            IShot shot = game.PrepareShot(coordinates);
            Assert.NotNull(shot);

            bool shotResult = shot.Fire();
            Assert.False(shotResult);
            Assert.Null(shot.GetHitShip());
        }
    }
}