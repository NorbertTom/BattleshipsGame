
namespace BattleshipsEngine
{
    class ShotMgr : IShotMgr
    {
        public ShotMgr(IPlayerScore playerScore, IBattlefield battlefield, int[] coordinates)
        {
            this.playerScore = playerScore;
            shot = new Shot(battlefield, coordinates);
        }

        public bool WillShotBeValid()
        {
            return shot.IsShotValid();
        }

        public IShot Shoot()
        {
            shot.Fire();
            if (shot.HitShip != null)
            {
                HandleHit();
            }
            return shot;
        }

        private void HandleHit()
        {
            shot.HitShip.DealDamage();
            playerScore.AddPoint();
        }

        private IPlayerScore playerScore;
        private Shot shot;
    }
}
