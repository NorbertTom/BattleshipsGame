
namespace BattleshipsEngine
{
    class Game : IGame
    {
        public Game(IBattlefield battlefield, IPlayerScore playerScore)
        {
            this.battlefield = battlefield;
            this.playerScore = playerScore;
        }

        public IBattlefield GetBattlefield()
        {
            return battlefield;
        }

        public IShot TryShot(string coordinates)
        {
            int[] coordsInt = Helpers.TranslateCoordinates(coordinates);
            var shotMgr = new ShotMgr(playerScore);
            var shot = shotMgr.Shoot(battlefield, coordsInt);
            return shot;
        }

        public bool ShouldKeepPlaying()
        {
            return !(playerScore.HasGameEnded());
        }

        private IBattlefield battlefield;
        private IPlayerScore playerScore;
    }
}