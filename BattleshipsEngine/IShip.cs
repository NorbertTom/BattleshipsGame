using System;

namespace BattleshipsEngine
{
    interface IShip
    {
        public int GetLength();
        //public int GetDamage();
        public void DealDamage();
        public bool IsDestroyed();
        public string GetName();
    }
}
