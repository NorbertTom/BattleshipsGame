using System;

namespace BattleshipsEngine
{
    public abstract class Ship : IShip
    {
        public int Length { get; protected set; }

        public string Name { get; protected set; }

        public void DealDamage() { damage++; }
        public bool IsDestroyed() { return damage == Length; }

        protected int damage=0;
    }

    public class Battleship : Ship
    {
        public Battleship()
        {
            Length = 5;
            Name = "Battleship";
        }
    }

    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Length = 4;
            Name = "Destroyer";
        }
    }
}
