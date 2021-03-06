using System;
using Xunit;
using Moq;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class GameInitializerTests
    {
        [Fact]
        public void AfterCallingCreateGame_GameIsInitialized()
        {
            var random = new Random();
            var initializer = new GameInitializer(random);
            var game = initializer.CreateGame();
            Assert.NotNull(game);
            Assert.NotNull(game.Battlefield);
        }
    }
}
