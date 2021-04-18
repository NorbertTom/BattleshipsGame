using System;

namespace BattleshipsEngine
{
    class Shot : IShot
    {
        public Shot(IBattlefield battlefield, int[] coordinates)
        {
            field = battlefield.GetField(coordinates[0], coordinates[1]);
        }

        public bool Fire()
        {
            HitShip = field.Shoot();
            return HitShip != null;
        }

        public bool IsShotValid()
        {
            return !(field.IsShot());
        }

        public IShip HitShip { get; private set; }
        private IField field;
    }
}
