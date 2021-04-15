using System;
using System.Diagnostics;

namespace BattleshipsEngine
{
    static class GameInitializer
    {
        public static void Initialize(IBattlefield battlefield)
        {
            var fields = new Field[BattlefieldSize, BattlefieldSize];
            initializeFields(fields);
            battlefield.AcquireFields(fields);
        }

        public static void SpawnShips(IBattlefield battlefield, Random random, IShip[] ships)
        {
            var shipSpawner = new ShipSpawner(battlefield, random);
            for (int i = 0; i < ships.Length; i++)
            {
                bool result = shipSpawner.SpawnShip(ships[i]);
                Debug.Assert(result, "Spawning Ships failed");
            }
        }

        private static void initializeFields(Field[,] fields)
        {
            for (int i=0; i < BattlefieldSize; i++)
            {
                for (int j=0; j < BattlefieldSize; j++)
                {
                    fields[i, j] = new Field();
                }
            }
        }

        static int BattlefieldSize = 10;
    }
}
