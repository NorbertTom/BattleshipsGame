using System;
using Xunit;
using Moq;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class ShotTests
    {
        [Fact]
        public void TestInvalidShot()
        {
            var battlefield = new Mock<IBattlefield>();
            int[] coordinates = { 5, 3 };
            var field = new Mock<IField>();

            battlefield.Setup(x => x.GetField(coordinates[0], coordinates[1])).Returns(field.Object);
            field.Setup(x => x.IfShot()).Returns(true);

            var newShot = new Shot(battlefield.Object, coordinates);
            Assert.False(newShot.Fire());
            Assert.Null(newShot.GetHitShip());
        }

        [Fact]
        public void TestValidShot()
        {
            var battlefield = new Mock<IBattlefield>();
            int[] coordinates = { 7, 2 };
            var field = new Mock<IField>();
            var ship = new Mock<IShip>();

            battlefield.Setup(x => x.GetField(coordinates[0], coordinates[1])).Returns(field.Object);
            field.Setup(x => x.IfShot()).Returns(false);
            field.Setup(x => x.Shoot()).Returns(ship.Object);

            var newShot = new Shot(battlefield.Object, coordinates);
            Assert.True(newShot.Fire());
            Assert.Equal(ship.Object, newShot.GetHitShip());
        }
    }
}
