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
            if (IsShotValid())
            {
                HitShip = field.Shoot();
            }
            return HitShip != null;
        }

        public bool IsShotValid()
        {
            return !(field.IfShot());
        }

        public IShip HitShip { get; private set; }
        private IField field;
    }
}
