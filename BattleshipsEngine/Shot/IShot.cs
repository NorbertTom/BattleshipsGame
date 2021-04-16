using System;

namespace BattleshipsEngine
{
    public interface IShot
    {
        public IShip HitShip { get; }
        public bool Fire();
        public bool IsShotValid();
    }
}