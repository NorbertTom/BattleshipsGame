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
                hitShip = field.Shoot();
            }
            return hitShip != null;
        }

        public IShip GetHitShip()
        {
            return hitShip;
        }

        public bool IsShotValid()
        {
            return !(field.IfShot());
        }

        private IShip hitShip;
        private IField field;
    }
}
