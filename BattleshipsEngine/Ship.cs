using System;

namespace BattleshipsEngine
{
    public abstract class Ship : IShip
    {
        public int GetLength() { return length; }
        public string GetName() { return name; }
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
            length = 5;
            name = "Battleship";
        }
    }

    public class Destroyer : Ship
    {
        public Destroyer()
        {
            length = 4;
            name = "Destroyer";
        }
    }
}
