using System;
using Xunit;
using Moq;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class FieldTests
    {
        [Fact]
        public void IfFieldWasShot()
        {
            var field = new Field();
            
            Assert.False(field.IfShot());
        }

        [Fact]
        public void ShootEmptyField()
        {
            var field = new Field();

            Assert.False(field.IfShot());
            Assert.Null(field.Shoot());
            Assert.True(field.IfShot());
        }

        [Fact]
        public void PlaceShipAndShootIt()
        {
            var mockShip = new Mock<IShip>();
            var field = new Field();
            
            field.PlaceShip(mockShip.Object);
         
            Assert.False(field.IfShot());
            Assert.Equal(mockShip.Object, field.Shoot());
            Assert.True(field.IfShot());
        }

        [Fact]
        public void IsShipThereTest()
        {
            var mockShip = new Mock<IShip>();
            var field = new Field();

            Assert.False(field.IsShipThere());

            field.PlaceShip(mockShip.Object);
            Assert.True(field.IsShipThere());
        }
    }
}
