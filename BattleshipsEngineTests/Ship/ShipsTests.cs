using System;
using Xunit;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class ShipsTests
    {
        [Fact]
        public void AfterCreatingDestroyerShip_NameAndLenghtAreCorrect()
        {
            var destroyer = new Destroyer();
            Assert.Equal(4, destroyer.Length);
            Assert.Equal("Destroyer", destroyer.Name);
        }

        [Fact]
        public void AfterCreatingBattleshipShip_NameAndLenghtAreCorrect()
        {
            var battleship = new Battleship();
            Assert.Equal(5, battleship.Length);
            Assert.Equal("Battleship", battleship.Name);
        }

        [Fact]
        public void AfterDealingDamageFourTimesToDestroyer_ItIsDestroyed()
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
        public void AfterDealingDamageFiveTimesToBattleship_ItIsDestroyed()
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