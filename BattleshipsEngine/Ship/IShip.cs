using System;

namespace BattleshipsEngine
{
    public interface IShip
    {
        public int Length { get; }
        public string Name { get; }
        public void DealDamage();
        public bool IsDestroyed();
    }
}
