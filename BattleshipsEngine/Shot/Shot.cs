using System;

namespace BattleshipsEngine
{
    class Shot : IShot
    {
        public Shot(IBattlefield battlefield, IPlayerScore playerScore, int[] coordinates)
        {
            this.battlefield = battlefield;
            this.playerScore = playerScore;
            this.coordinates = coordinates;
            field = battlefield.GetField(coordinates[0], coordinates[1]);
        }

        public bool Fire() // too much going on there I think
        {
            if (IsShotValid())
            {
                hitShip = field.Shoot();
                handleHit();
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

        private void handleHit()
        {
            if (hitShip != null)
            {
                dealDamageToShip();
                playerScore.AddPoint();
            }
        }

        private void dealDamageToShip()
        {
            hitShip.DealDamage();
        }

        IBattlefield battlefield;
        IPlayerScore playerScore;
        IField field;
        int[] coordinates;
        IShip hitShip;
    }
}
