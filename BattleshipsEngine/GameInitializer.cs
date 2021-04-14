using System;

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
