
namespace BattleshipsEngine
{
    class Game : IGame
    {
        public Game(IBattlefield battlefield, IPlayerScore playerScore)
        {
            Battlefield = battlefield;
            this.playerScore = playerScore;
        }

        public IShot TryShot(string coordinates)
        {
            int[] coordsInt = Helpers.TranslateCoordinates(coordinates);
            var shotMgr = new ShotMgr(playerScore);
            var shot = shotMgr.Shoot(Battlefield, coordsInt);
            return shot;
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