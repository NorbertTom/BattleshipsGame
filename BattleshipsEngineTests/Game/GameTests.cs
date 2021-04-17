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
            Assert.NotNull(game.Battlefield);
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

        [Theory]
        [InlineData("A0", 0, 0)]
        [InlineData("C2", 2, 2)]
        [InlineData("F1", 5, 1)]
        [InlineData("J9", 9, 9)]
        public void IfFieldWassAlreadyShot_PreparingShotReturnsNull(string coordinates, int coordX, int coordY)
        {
            var battlefield = new Mock<IBattlefield>();
            var playerScore = new Mock<IPlayerScore>();
            var field = new Mock<IField>();
            battlefield.Setup(x => x.GetField(coordX, coordY)).Returns(field.Object);
            field.Setup(x => x.IfShot()).Returns(true);

            var game = new Game(battlefield.Object, playerScore.Object);

            Assert.Null(game.PrepareShot(coordinates));
        }

        [Theory]
        [InlineData("F5", 5, 5)]
        [InlineData("B9", 1, 9)]
        [InlineData("D0", 3, 0)]
        [InlineData("I7", 8, 7)]
        public void IfFieldWasNotAlreadyShot_PreparingShotReturnsNotNull(string coordinates, int coordX, int coordY)
        {
            var battlefield = new Mock<IBattlefield>();
            var playerScore = new Mock<IPlayerScore>();
            var field = new Mock<IField>();
            battlefield.Setup(x => x.GetField(coordX, coordY)).Returns(field.Object);
            field.Setup(x => x.IfShot()).Returns(false);

            var game = new Game(battlefield.Object, playerScore.Object);
            
            Assert.NotNull(game.PrepareShot(coordinates));
        }
    }
}