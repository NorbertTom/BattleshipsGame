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
            Mock<IField>[] fields = new Mock<IField>[5];
            for (int i = 0; i < fields.Length; i++)
            {
                fields[i] = new Mock<IField>();
            }

            var battlefield = new Mock<IBattlefield>();

            for (int i = 0; i < fields.Length; i++)
            {
                battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0], shipsStartingCoordinates[1] + i))
                                              .Returns(fields[i].Object);
            }

            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(2)).Returns(0);
            mockRandom.Setup(x => x.Next(10)).Returns(shipsStartingCoordinates[0]);
            mockRandom.Setup(x => x.Next(9 - shipsLength + 2)).Returns(shipsStartingCoordinates[1]);

            var ship = new Mock<IShip>();
            ship.Setup(x => x.Length).Returns(shipsLength);

            var shipSpawner = new ShipSpawner(battlefield.Object, mockRandom.Object);

            Assert.True(shipSpawner.SpawnShip(ship.Object));
            foreach (var field in fields)
            {
                field.Verify(x => x.PlaceShip(ship.Object), Times.Once());
            }
        }

        [Fact]
        public void TrySpawningOneHorizontalShip()
        {
            int shipsLength = 4;
            int[] shipsStartingCoordinates = { 0, 9 };

            Mock<IField>[] fields = new Mock<IField>[4];
            for (int i = 0; i < fields.Length; i++)
            {
                fields[i] = new Mock<IField>();
            }

            var battlefield = new Mock<IBattlefield>();
            for (int i = 0; i < fields.Length; i++)
            {
                battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0] + i, shipsStartingCoordinates[1]))
                                                .Returns(fields[i].Object);
            }

            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(2)).Returns(1);
            mockRandom.Setup(x => x.Next(9 - shipsLength + 2)).Returns(shipsStartingCoordinates[0]);
            mockRandom.Setup(x => x.Next(10)).Returns(shipsStartingCoordinates[1]);

            var ship = new Mock<IShip>();
            ship.Setup(x => x.Length).Returns(shipsLength);

            var shipSpawner = new ShipSpawner(battlefield.Object, mockRandom.Object);

            Assert.True(shipSpawner.SpawnShip(ship.Object));
            foreach (var field in fields)
            {
                field.Verify(x => x.PlaceShip(ship.Object), Times.Once());
            }
        }

        [Fact]
        public void TrySpawningSameShipTwice()
        {
            int shipsLength = 5;
            int[] shipsStartingCoordinates = { 4, 1 };

            Mock<IField>[] fields = new Mock<IField>[5];
            for (int i = 0; i < fields.Length; i++)
            {
                fields[i] = new Mock<IField>();
            }

            var battlefield = new Mock<IBattlefield>();
            for (int i = 0; i < fields.Length; i++)
            {
                battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0], shipsStartingCoordinates[1] + i))
                                                .Returns(fields[i].Object);
            }

            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(2)).Returns(0);
            mockRandom.Setup(x => x.Next(10)).Returns(shipsStartingCoordinates[0]);
            mockRandom.Setup(x => x.Next(9 - shipsLength + 2)).Returns(shipsStartingCoordinates[1]);

            var ship = new Mock<IShip>();
            ship.Setup(x => x.Length).Returns(shipsLength);

            var shipSpawner = new ShipSpawner(battlefield.Object, mockRandom.Object);

            Assert.True(shipSpawner.SpawnShip(ship.Object));
            foreach (var field in fields)
            {
                field.Verify(x => x.PlaceShip(ship.Object), Times.Once());
            }
            Assert.False(shipSpawner.SpawnShip(ship.Object));
        }

        [Fact]
        public void TrySpawningCollidingShips()
        {
            int shipsLength = 4;
            int[] shipsStartingCoordinates = { 0, 9 };

            Mock<IField>[] fields = new Mock<IField>[4];
            for (int i = 0; i < fields.Length; i++)
            {
                fields[i] = new Mock<IField>();
            }

            var battlefield = new Mock<IBattlefield>();
            for (int i=0;i<fields.Length;i++)
            {
                battlefield.Setup(x => x.GetField(shipsStartingCoordinates[0] + i, shipsStartingCoordinates[1]))
                                          .Returns(fields[i].Object);
            }
 
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