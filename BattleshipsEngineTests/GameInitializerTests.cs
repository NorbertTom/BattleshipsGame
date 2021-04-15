using System;
using Xunit;
using Moq;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class GameInitializerTests
    {
        [Fact]
        public void createGame()
        {
            var random = new Random();
            var initializer = new GameInitializer(random);
            var game = initializer.createGame();
            Assert.NotNull(game);
            Assert.NotNull(game.GetBattlefield());
        }
    }
}
