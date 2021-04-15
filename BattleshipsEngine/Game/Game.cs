
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

        public IShot PrepareShot(string coordinates)
        {
            int[] coordsInt = Helpers.TranslateCoordinates(coordinates);
            var shot = new Shot(battlefield, playerScore, coordsInt);
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