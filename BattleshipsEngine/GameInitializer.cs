using System;
using System.Diagnostics;

namespace BattleshipsEngine
{
    public class GameInitializer
    {
        public GameInitializer(Random random)
        {
            this.random = random;
        }

        public IGame createGame()
        {
            const int MaxScoreInGame = 13;
            var playerScore = new PlayerScore(MaxScoreInGame);
            var battlefield = new Battlefield();
            Initialize(battlefield);
            Ship[] ships = { new Battleship(), new Destroyer(), new Destroyer() };
            SpawnShips(battlefield, random, ships);

            var game = new Game(battlefield, playerScore);
            return game;
        }

        private void Initialize(IBattlefield battlefield)
        {
            var fields = new Field[BattlefieldSize, BattlefieldSize];
            initializeFields(fields);
            battlefield.AcquireFields(fields);
        }

        private void SpawnShips(IBattlefield battlefield, Random random, IShip[] ships)
        {
            var shipSpawner = new ShipSpawner(battlefield, random);
            for (int i = 0; i < ships.Length; i++)
            {
                bool result = shipSpawner.SpawnShip(ships[i]);
                Debug.Assert(result, "Spawning Ships failed");
            }
        }

        private void initializeFields(Field[,] fields)
        {
            for (int i=0; i < BattlefieldSize; i++)
            {
                for (int j=0; j < BattlefieldSize; j++)
                {
                    fields[i, j] = new Field();
                }
            }
        }

        Random random;
        const int BattlefieldSize = 10;
    }
}