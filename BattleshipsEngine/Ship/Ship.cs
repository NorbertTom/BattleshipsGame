using System;

namespace BattleshipsEngine
{
    public abstract class Ship : IShip
    {
        public int Length
        {
            get => length;
            protected set => length = value;
        }

        public string Name 
        { 
            get => name;
            protected set => name = value;
        }

        public void DealDamage() { damage++; }
        public bool IsDestroyed() { return damage == length; }

        protected int damage=0;
        protected int length;
        protected string name;
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
