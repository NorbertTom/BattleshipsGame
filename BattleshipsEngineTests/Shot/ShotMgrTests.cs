using Xunit;
using Moq;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class ShotMgrTests
    {
        [Fact]
        public void InvalidShot()
        {
            var playerScore = new Mock<IPlayerScore>();
            var battlefield = new Mock<IBattlefield>();
            int[] coordinates = { 5, 7 };
            var field = new Mock<IField>();

            battlefield.Setup(x => x.GetField(coordinates[0], coordinates[1])).Returns(field.Object);
            field.Setup(x => x.IfShot()).Returns(true);

            var shotMgr = new ShotMgr(playerScore.Object);
            var shot = shotMgr.Shoot(battlefield.Object, coordinates);

            Assert.Null(shot);
            playerScore.Verify(x => x.AddPoint(), Times.Never());
        }

        [Fact]
        public void InvalidShotWithShip()
        {
            var playerScore = new Mock<IPlayerScore>();
            var battlefield = new Mock<IBattlefield>();
            int[] coordinates = { 2, 1 };
            var field = new Mock<IField>();
            var ship = new Mock<IShip>();

            battlefield.Setup(x => x.GetField(coordinates[0], coordinates[1])).Returns(field.Object);
            field.Setup(x => x.IfShot()).Returns(true);
            field.Setup(x => x.Shoot()).Returns(ship.Object);

            var shotMgr = new ShotMgr(playerScore.Object);
            var shot = shotMgr.Shoot(battlefield.Object, coordinates);

            Assert.Null(shot);
            playerScore.Verify(x => x.AddPoint(), Times.Never());
            ship.Verify(x => x.DealDamage(), Times.Never());
        }

        [Fact]
        public void MissedShot()
        {
            var playerScore = new Mock<IPlayerScore>();
            var battlefield = new Mock<IBattlefield>();
            int[] coordinates = { 0, 0 };
            var field = new Mock<IField>();

            battlefield.Setup(x => x.GetField(coordinates[0], coordinates[1])).Returns(field.Object);
            field.Setup(x => x.IfShot()).Returns(false);
            field.Setup(x => x.Shoot()).Returns((IShip)null);

            var shotMgr = new ShotMgr(playerScore.Object);
            var shot = shotMgr.Shoot(battlefield.Object, coordinates);

            Assert.NotNull(shot);
            Assert.Null(shot.HitShip);
            Assert.True(shot.IsShotValid());
            playerScore.Verify(x => x.AddPoint(), Times.Never());
        }

        [Fact]
        public void HitShot()
        {
            var playerScore = new Mock<IPlayerScore>();
            var battlefield = new Mock<IBattlefield>();
            int[] coordinates = { 2, 8 };
            var field = new Mock<IField>();
            var ship = new Mock<IShip>();

            battlefield.Setup(x => x.GetField(coordinates[0], coordinates[1])).Returns(field.Object);
            field.Setup(x => x.IfShot()).Returns(false);
            field.Setup(x => x.Shoot()).Returns(ship.Object);

            var shotMgr = new ShotMgr(playerScore.Object);
            var shot = shotMgr.Shoot(battlefield.Object, coordinates);

            Assert.NotNull(shot);
            Assert.NotNull(shot.HitShip);
            Assert.True(shot.IsShotValid());
            playerScore.Verify(x => x.AddPoint(), Times.Once());
            ship.Verify(x => x.DealDamage(), Times.Once());
        }
    }
}