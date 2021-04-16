using System;
using Xunit;
using Moq;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class ShipSpawnerTests
    {
        [Fact]
        public void TrySpawningOneVerticalShip()
        {
            int shipsLength = 5;
            int[] shipsStartingCoordinates = { 0, 4 };
            
            var field0 = new Mock<IField>();
            var field1 = new Mock<IField>();
            var field2 = new Mock<IField>();
            var field3 = new Mock<IField>();
            var field4 = new Mock<IField>();
            
            var battlefield = new Mock<IBattlefield>();
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0], shipsStartingCoordinates[1]))
                                            .Returns(field0.Object);
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0], shipsStartingCoordinates[1]+1))
                                            .Returns(field1.Object);
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0], shipsStartingCoordinates[1]+2))
                                            .Returns(field2.Object);
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0], shipsStartingCoordinates[1]+3))
                                            .Returns(field3.Object);
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0], shipsStartingCoordinates[1]+4))
                                            .Returns(field4.Object);
            
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(2)).Returns(0);
            mockRandom.Setup(x => x.Next(10)).Returns(shipsStartingCoordinates[0]);
            mockRandom.Setup(x => x.Next(9 - shipsLength + 2)).Returns(shipsStartingCoordinates[1]);

            var ship = new Mock<IShip>();
            ship.Setup(x => x.Length).Returns(shipsLength);

            var shipSpawner = new ShipSpawner(battlefield.Object, mockRandom.Object);

            Assert.True(shipSpawner.SpawnShip(ship.Object));
            field0.Verify(x => x.PlaceShip(ship.Object), Times.Once());
            field1.Verify(x => x.PlaceShip(ship.Object), Times.Once());
            field2.Verify(x => x.PlaceShip(ship.Object), Times.Once());
            field3.Verify(x => x.PlaceShip(ship.Object), Times.Once());
            field4.Verify(x => x.PlaceShip(ship.Object), Times.Once());
        }

        [Fact]
        public void TrySpawningOneHorizontalShip()
        {
            int shipsLength = 4;
            int[] shipsStartingCoordinates = { 0, 9 };

            var field0 = new Mock<IField>();
            var field1 = new Mock<IField>();
            var field2 = new Mock<IField>();
            var field3 = new Mock<IField>();

            var battlefield = new Mock<IBattlefield>();
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0], shipsStartingCoordinates[1]))
                                            .Returns(field0.Object);
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0]+1, shipsStartingCoordinates[1]))
                                            .Returns(field1.Object);
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0]+2, shipsStartingCoordinates[1]))
                                            .Returns(field2.Object);
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0]+3, shipsStartingCoordinates[1]))
                                            .Returns(field3.Object);

            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(2)).Returns(1);
            mockRandom.Setup(x => x.Next(9 - shipsLength + 2)).Returns(shipsStartingCoordinates[0]);
            mockRandom.Setup(x => x.Next(10)).Returns(shipsStartingCoordinates[1]);

            var ship = new Mock<IShip>();
            ship.Setup(x => x.Length).Returns(shipsLength);

            var shipSpawner = new ShipSpawner(battlefield.Object, mockRandom.Object);

            Assert.True(shipSpawner.SpawnShip(ship.Object));
            field0.Verify(x => x.PlaceShip(ship.Object), Times.Once());
            field1.Verify(x => x.PlaceShip(ship.Object), Times.Once());
            field2.Verify(x => x.PlaceShip(ship.Object), Times.Once());
            field3.Verify(x => x.PlaceShip(ship.Object), Times.Once());
        }

        [Fact]
        public void TrySpawningSameShipTwice()
        {
            int shipsLength = 5;
            int[] shipsStartingCoordinates = { 4, 1 };

            var field0 = new Mock<IField>();
            var field1 = new Mock<IField>();
            var field2 = new Mock<IField>();
            var field3 = new Mock<IField>();
            var field4 = new Mock<IField>();

            var battlefield = new Mock<IBattlefield>();
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0], shipsStartingCoordinates[1]))
                                            .Returns(field0.Object);
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0], shipsStartingCoordinates[1] + 1))
                                            .Returns(field1.Object);
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0], shipsStartingCoordinates[1] + 2))
                                            .Returns(field2.Object);
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0], shipsStartingCoordinates[1] + 3))
                                            .Returns(field3.Object);
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0], shipsStartingCoordinates[1] + 4))
                                            .Returns(field4.Object);

            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(2)).Returns(0);
            mockRandom.Setup(x => x.Next(10)).Returns(shipsStartingCoordinates[0]);
            mockRandom.Setup(x => x.Next(9 - shipsLength + 2)).Returns(shipsStartingCoordinates[1]);

            var ship = new Mock<IShip>();
            ship.Setup(x => x.Length).Returns(shipsLength);

            var shipSpawner = new ShipSpawner(battlefield.Object, mockRandom.Object);

            Assert.True(shipSpawner.SpawnShip(ship.Object));
            field0.Verify(x => x.PlaceShip(ship.Object), Times.Once());
            field1.Verify(x => x.PlaceShip(ship.Object), Times.Once());
            field2.Verify(x => x.PlaceShip(ship.Object), Times.Once());
            field3.Verify(x => x.PlaceShip(ship.Object), Times.Once());
            field4.Verify(x => x.PlaceShip(ship.Object), Times.Once());

            Assert.False(shipSpawner.SpawnShip(ship.Object));
        }

        [Fact]
        public void TrySpawningCollidingShips()
        {
            int shipsLength = 4;
            int[] shipsStartingCoordinates = { 0, 9 };

            var field0 = new Mock<IField>();
            var field1 = new Mock<IField>();
            var field2 = new Mock<IField>();
            var field3 = new Mock<IField>();

            var battlefield = new Mock<IBattlefield>();
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0], shipsStartingCoordinates[1]))
                                            .Returns(field0.Object);
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0] + 1, shipsStartingCoordinates[1]))
                                            .Returns(field1.Object);
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0] + 2, shipsStartingCoordinates[1]))
                                            .Returns(field2.Object);
            battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0] + 3, shipsStartingCoordinates[1]))
                                            .Returns(field3.Object);

            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(2)).Returns(1);
            mockRandom.Setup(x => x.Next(9 - shipsLength + 2)).Returns(shipsStartingCoordinates[0]);
            mockRandom.Setup(x => x.Next(10)).Returns(shipsStartingCoordinates[1]);

            var ship = new Mock<IShip>();
            ship.Setup(x => x.Length).Returns(shipsLength);

            var shipSpawner = new ShipSpawner(battlefield.Object, mockRandom.Object);
            shipSpawner.SpawnShip(ship.Object);

            int[] nextShipsStartingCoordinates = { 3, 6 };
            int nextShipsLength = shipsLength;
            mockRandom.Setup(x => x.Next(2)).Returns(0);
            mockRandom.Setup(x => x.Next(10)).Returns(nextShipsStartingCoordinates[0]);
            mockRandom.Setup(x => x.Next(9 - nextShipsLength + 2)).Returns(nextShipsStartingCoordinates[1]);

            Assert.False(shipSpawner.SpawnShip(ship.Object));            
        }
    }
}