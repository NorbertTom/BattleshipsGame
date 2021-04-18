using System;

namespace BattleshipsEngine
{
    class HitHandler
    {
        public HitHandler(IPlayerScore playerScore, IShip hitShip)
        {
            this.playerScore = playerScore;
            this.hitShip = hitShip;
        }

        public void Execute()
        {
            if (hitShip != null)
            {
                hitShip.DealDamage();
                playerScore.AddPoint();
            }
        }

        private IPlayerScore playerScore;
        private IShip hitShip;
    }
}
