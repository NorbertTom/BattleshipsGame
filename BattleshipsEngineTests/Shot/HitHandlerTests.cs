using System;
using Xunit;
using Moq;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class HitHandlerTests
    {
        [Fact]
        public void GivenNullShip_DoesNotAddPointToPlayerScore()
        {
            var playerScore = new Mock<IPlayerScore>();
            IShip ship = null;

            var hitHandler = new HitHandler(playerScore.Object, ship);
            hitHandler.Execute();

            playerScore.Verify(x => x.AddPoint(), Times.Never());
        }

        [Fact]
        public void GivenNotNullShip_AddsPointsToPlayerScore()
        {
            var playerScore = new Mock<IPlayerScore>();
            var ship = new Mock<IShip>();
            const int nrOfRepeats = 5;

            for (int i = 0; i < nrOfRepeats; i++)
            {
                var hitHandler = new HitHandler(playerScore.Object, ship.Object);
                hitHandler.Execute();
            }

            playerScore.Verify(x => x.AddPoint(), Times.Exactly(nrOfRepeats));
        }
    }
}
