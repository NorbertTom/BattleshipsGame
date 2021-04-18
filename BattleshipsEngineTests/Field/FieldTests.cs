using System;
using Xunit;
using Moq;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class FieldTests
    {
        [Fact]
        public void GivenNewlyCreatedField_IsShotReturnsFalse()
        {
            var field = new Field();
            
            Assert.False(field.IsShot());
        }

        [Fact]
        public void AfterShootingField_IsShotReturnsTrue()
        {
            var field = new Field();

            Assert.False(field.IsShot());
            Assert.Null(field.Shoot());
            Assert.True(field.IsShot());
        }

        [Fact]
        public void WhenShootingFieldWithShip_ShootReturnsShipObject()
        {
            var mockShip = new Mock<IShip>();
            var field = new Field();
            
            field.PlaceShip(mockShip.Object);
         
            Assert.False(field.IsShot());
            Assert.Equal(mockShip.Object, field.Shoot());
            Assert.True(field.IsShot());
        }

        [Fact]
        public void IfFieldHasShip_IsShipThereReturnsTrue()
        {
            var mockShip = new Mock<IShip>();
            var field = new Field();

            Assert.False(field.IsShipThere());

            field.PlaceShip(mockShip.Object);
            Assert.True(field.IsShipThere());
        }
    }
}
