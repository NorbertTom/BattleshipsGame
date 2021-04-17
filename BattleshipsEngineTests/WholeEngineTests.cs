using System;
using Xunit;
using Moq;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class WholeEngineTests
    {
        [Fact]
        public void After13HitShots_GameStopsPlaying()
        {
            //Battleship is Vertical at (1, 5)
            //First Destroyer is Horizontal at (4, 2)
            //Second Destroyer is Vertical at (8, 0)

            var random = new Mock<Random>();
            random.SetupSequence(x => x.Next(2)).Returns(0)
                                                .Returns(1)
                                                .Returns(0);
            random.SetupSequence(x => x.Next(10)).Returns(1).Returns(2).Returns(8);
            random.Setup(x => x.Next(6)).Returns(5);
            random.SetupSequence(x => x.Next(7)).Returns(4).Returns(0);

            var gameInitializer = new GameInitializer(random.Object);
            var game = gameInitializer.CreateGame();
            string[] listOfShots = {"B5", "B6", "B7", "B8", "B9",
                                    "E2", "F2", "G2", "H2",
                                    "I0", "I1", "I2", "I3"};
            foreach (var shotCoordinates in listOfShots)
            {
                Assert.True(game.ShouldKeepPlaying());
                var shotMgr = game.PrepareShot(shotCoordinates);
                shotMgr.Shoot();
            }
            Assert.False(game.ShouldKeepPlaying());
        }
    }
}
