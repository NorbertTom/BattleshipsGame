using System;

namespace BattleshipsEngine
{
    public interface IShot
    {
        public bool Fire();
        public bool IsShotValid();
        public IShip GetHitShip();
    }
}