using System;

namespace BattleshipsEngine
{
    class Shot : IShot
    {
        public Shot(IBattlefield battlefield, int[] coordinates)
        {
            this.battlefield = battlefield;
            this.coordinates = coordinates;
        }

        public bool Fire()
        {
            IField field = battlefield.GetField(coordinates[0], coordinates[1]);
            if (field.IfShot() == false)
            {
                hitShip = field.Shoot();
            }
            return hitShip != null;
        }

        public IShip GetHitShip()
        {
            return hitShip;
        }

        IBattlefield battlefield;
        int[] coordinates;
        IShip hitShip;
    }
}
