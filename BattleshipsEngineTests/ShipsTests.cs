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
            Assert.Equal(4, destroyer.Length);
            Assert.Equal("Destroyer", destroyer.Name);
        }

        [Fact]
        public void BattleshipConstructor()
        {
            var battleship = new Battleship();
            Assert.Equal(5, battleship.Length);
            Assert.Equal("Battleship", battleship.Name);
        }

        [Fact]
        public void DealingDamageToDestroyer()
        {
            var ship = new Destroyer();
            for (int i=0; i<ship.Length; i++)
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
            for (int i = 0; i < ship.Length; i++)
            {
                Assert.False(ship.IsDestroyed());
                ship.DealDamage();
            }
            Assert.True(ship.IsDestroyed());
        }
    }
}
