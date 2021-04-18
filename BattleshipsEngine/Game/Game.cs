
namespace BattleshipsEngine
{
    class Game : IGame
    {
        public Game(IBattlefield battlefield, IPlayerScore playerScore)
        {
            Battlefield = battlefield;
            this.playerScore = playerScore;
        }

        public IShot Shoot(string coordinates)
        {
            int[] coordsInt = Helpers.TranslateCoordinates(coordinates);
            var shot = new Shot(Battlefield, coordsInt);
            if (!shot.IsShotValid())
            {
                return null;
            }
               
            shot.Fire();
            var hitHandler = new HitHandler(playerScore, shot.HitShip);
            hitHandler.Execute();
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