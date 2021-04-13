using System;
using Xunit;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class ShipsTests
    {
        [Fact]
        public void DestroyerConstructor()
        {
            var destroyer = new Destroyer();
            Assert.Equal(4, destroyer.GetLength());
            Assert.Equal("Destroyer", destroyer.GetName());
        }

        [Fact]
        public void BattleshipConstructor()
        {
            var battleship = new Battleship();
            Assert.Equal(5, battleship.GetLength());
            Assert.Equal("Battleship", battleship.GetName());
        }

        [Fact]
        public void DealingDamageToDestroyer()
        {
            var ship = new Destroyer();
            for (int i=0; i<ship.GetLength(); i++)
            {
                Assert.False(ship.IsDestroyed());
                ship.DealDamage();
            }
            Assert.True(ship.IsDestroyed());
        }

        [Fact]
        public void DealingDamageToBattleship()
        {
            var ship = new Battleship();
            for (int i = 0; i < ship.GetLength(); i++)
            {
                Assert.False(ship.IsDestroyed());
                ship.DealDamage();
            }
            Assert.True(ship.IsDestroyed());
        }
    }
}
