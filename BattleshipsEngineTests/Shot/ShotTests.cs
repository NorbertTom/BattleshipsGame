using System;
using Xunit;
using Moq;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class ShotTests
    {
        [Fact]
        public void FiringInvalidShot_ReturnsFalse()
        {
            var battlefield = new Mock<IBattlefield>();
            int[] coordinates = { 5, 3 };
            var field = new Mock<IField>();

            battlefield.Setup(x => x.GetField(coordinates[0], coordinates[1])).Returns(field.Object);
            field.Setup(x => x.IsShot()).Returns(true);

            var newShot = new Shot(battlefield.Object, coordinates);
            Assert.False(newShot.Fire());
            Assert.False(newShot.IsShotValid());
            Assert.Null(newShot.HitShip);
        }

        [Fact]
        public void InCaseOfMissedShot_NoShipIsReturned()
        {
            var battlefield = new Mock<IBattlefield>();
            int[] coordinates = { 1, 0 };
            var field = new Mock<IField>();
            var ship = new Mock<IShip>();

            battlefield.Setup(x => x.GetField(coordinates[0], coordinates[1])).Returns(field.Object);
            field.Setup(x => x.IsShot()).Returns(false);
            field.Setup(x => x.Shoot()).Returns((IShip)null);

            var newShot = new Shot(battlefield.Object, coordinates);
            Assert.False(newShot.Fire());
            Assert.True(newShot.IsShotValid());
            Assert.Null(newShot.HitShip);
        }

        [Fact]
        public void InCaseOfHitShot_HitShipIsReturned()
        {
            var battlefield = new Mock<IBattlefield>();
            int[] coordinates = { 7, 2 };
            var field = new Mock<IField>();
            var ship = new Mock<IShip>();

            battlefield.Setup(x => x.GetField(coordinates[0], coordinates[1])).Returns(field.Object);
            field.Setup(x => x.IsShot()).Returns(false);
            field.Setup(x => x.Shoot()).Returns(ship.Object);

            var newShot = new Shot(battlefield.Object, coordinates);
            Assert.True(newShot.Fire());
            Assert.True(newShot.IsShotValid());
            Assert.Equal(ship.Object, newShot.HitShip);
        }
    }
}