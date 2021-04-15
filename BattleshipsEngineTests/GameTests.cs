using System;
using Xunit;
using Moq;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class GameTests
    {
        [Fact]
        public void GetBattlefieldTest()
        {
            var battlefield = new Mock<IBattlefield>();
            var playerScore = new Mock<IPlayerScore>();

            var game = new Game(battlefield.Object, playerScore.Object);
            Assert.NotNull(game.GetBattlefield());
        }

        [Fact]
        public void ShouldKeepPlayingTest()
        {
            var battlefield = new Mock<IBattlefield>();
            var playerScore = new Mock<IPlayerScore>();
            playerScore.Setup(x => x.HasGameEnded()).Returns(false);

            var game = new Game(battlefield.Object, playerScore.Object);
            playerScore.Verify(x => x.HasGameEnded(), Times.Never());
            Assert.True(game.ShouldKeepPlaying());
            playerScore.Verify(x => x.HasGameEnded(), Times.Once());
        }

        [Fact]
        public void PrepareShotTest()
        {/* needs rework
            var battlefield = new Mock<IBattlefield>();
            var playerScore = new Mock<IPlayerScore>();

            var game = new Game(battlefield.Object, playerScore.Object);
            string coordinates = "A5";

            Assert.NotNull(game.TryShot(coordinates));*/
        }
    }
}