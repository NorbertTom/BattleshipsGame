
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
            if (shot.HitShip != null)
            {
                HandleHit(shot.HitShip);
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
