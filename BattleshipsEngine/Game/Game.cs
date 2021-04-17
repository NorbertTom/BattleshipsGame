
namespace BattleshipsEngine
{
    class Game : IGame
    {
        public Game(IBattlefield battlefield, IPlayerScore playerScore)
        {
            Battlefield = battlefield;
            this.playerScore = playerScore;
        }

        public IShotMgr PrepareShot(string coordinates)
        {
            int[] coordsInt = Helpers.TranslateCoordinates(coordinates);
            var shotMgr = new ShotMgr(playerScore, Battlefield, coordsInt);
            var result = shotMgr.WillShotBeValid() ? shotMgr : null;
            return result;
        }

        public bool ShouldKeepPlaying()
        {
            return !(playerScore.HasGameEnded());
        }

        public IBattlefield Battlefield
        {
            get;
            private set;
        }

        private IPlayerScore playerScore;
    }
}