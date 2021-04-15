using System;

namespace BattleshipsEngine
{
    public class Game
    {
        public Game()
        {}

        public void Initialize()
        {
            const int MaxScoreInGame = 13;
            playerScore = new PlayerScore(MaxScoreInGame);
            battlefield = new Battlefield();
            random = new Random();
            GameInitializer.Initialize(battlefield);
            Ship[] ships = { new Battleship(), new Destroyer(), new Destroyer() };
            GameInitializer.SpawnShips(battlefield, random, ships);
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

        private Battlefield battlefield;
        private PlayerScore playerScore;
        private Random random;
    }
}
