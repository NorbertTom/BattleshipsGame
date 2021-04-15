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
            var playerScore = new Mock<IPlayerScore>();
            int[] coordinates = { 5, 3 };
            var field = new Mock<IField>();

            battlefield.Setup(x => x.GetField(coordinates[0], coordinates[1])).Returns(field.Object);
            field.Setup(x => x.IfShot()).Returns(true);

            var newShot = new Shot(battlefield.Object, playerScore.Object, coordinates);
            Assert.False(newShot.IsShotValid());
            Assert.False(newShot.Fire());
            Assert.Null(newShot.GetHitShip());
            playerScore.Verify(x => x.AddPoint(), Times.Never());
        }

        [Fact]
        public void TestMissShot()
        {
            var battlefield = new Mock<IBattlefield>();
            var playerScore = new Mock<IPlayerScore>();
            int[] coordinates = { 1, 0 };
            var field = new Mock<IField>();
            var ship = new Mock<IShip>();

            battlefield.Setup(x => x.GetField(coordinates[0], coordinates[1])).Returns(field.Object);
            field.Setup(x => x.IfShot()).Returns(false);
            field.Setup(x => x.Shoot()).Returns((IShip)null);

            var newShot = new Shot(battlefield.Object, playerScore.Object, coordinates);
            Assert.True(newShot.IsShotValid());
            Assert.False(newShot.Fire());
            Assert.Null(newShot.GetHitShip());
            playerScore.Verify(x => x.AddPoint(), Times.Never());
        }

        [Fact]
        public void TestHitShot()
        {
            var battlefield = new Mock<IBattlefield>();
            var playerScore = new Mock<IPlayerScore>();
            int[] coordinates = { 7, 2 };
            var field = new Mock<IField>();
            var ship = new Mock<IShip>();

            battlefield.Setup(x => x.GetField(coordinates[0], coordinates[1])).Returns(field.Object);
            field.Setup(x => x.IfShot()).Returns(false);
            field.Setup(x => x.Shoot()).Returns(ship.Object);

            var newShot = new Shot(battlefield.Object, playerScore.Object, coordinates);
            Assert.True(newShot.IsShotValid());
            Assert.True(newShot.Fire());
            Assert.Equal(ship.Object, newShot.GetHitShip());
            ship.Verify(x => x.DealDamage(), Times.Once());
            playerScore.Verify(x => x.AddPoint(), Times.Once());
        }
    }
}