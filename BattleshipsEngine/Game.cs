using System;
using System.Collections.Generic;
using System.Text;

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
            battlefield = new Battlefield();
            GameInitializer.Initialize(battlefield);
        }

        private Battlefield battlefield;
    }
}
