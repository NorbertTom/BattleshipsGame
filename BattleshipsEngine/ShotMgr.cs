
namespace BattleshipsEngine
{
    class ShotMgr
    {
        public ShotMgr(IPlayerScore playerScore)
        {
            this.playerScore = playerScore;
        }

        public IShot Shoot(IBattlefield battlefield, int[] coordinates)
        {
            var shot = new Shot(battlefield, coordinates);
            if (!shot.IsShotValid())
            {
                return null;
            }

            shot.Fire();
            IShip ship = shot.HitShip;
            if (ship != null)
            {
                HandleHit(ship);
            }
            return shot;
        }

        private void HandleHit(IShip ship)
        {
            ship.DealDamage();
            playerScore.AddPoint();
        }

        private IPlayerScore playerScore;
    }
}
