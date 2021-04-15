using System;

namespace BattleshipsEngine
{
    public interface IShot
    {
        public bool Fire();
        public IShip GetHitShip();
    }
}