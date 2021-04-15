using System;

namespace BattleshipsEngine
{
    public class Game
    {
        public Game()
        {}

        public IBattlefield GetBattlefield()
        {
            return battlefield;
        }

        public void Initialize()
        {
            const int MaxScoreInGame = 13;
            playerScore = new PlayerScore(MaxScoreInGame);
            battlefield = new Battlefield();
            GameInitializer.Initialize(battlefield);
            //Ships
            //ShipSpawner
        }

        public IShot PrepareShot(string coordinates)
        {
            int[] coordsInt = Helpers.TranslateCoordinates(coordinates);
            var shot = new Shot(battlefield, playerScore, coordsInt);
            return shot;
        }

        private Battlefield battlefield;
        private PlayerScore playerScore;
        private Random random;
    }
}
