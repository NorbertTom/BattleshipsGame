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
            
            Assert.False(field.IsShot());
        }

        [Fact]
        public void ShootEmptyField()
        {
            var field = new Field();

            Assert.False(field.IsShot());
            Assert.Null(field.Shoot());
            Assert.True(field.IsShot());
        }

        [Fact]
        public void PlaceShipAndShootIt()
        {
            var mockShip = new Mock<IShip>();
            var field = new Field();
            
            field.PlaceShip(mockShip.Object);
         
            Assert.False(field.IsShot());
            Assert.Equal(mockShip.Object, field.Shoot());
            Assert.True(field.IsShot());
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
