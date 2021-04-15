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
            //Ships
            //ShipSpawner
        }

        public IShot PrepareShot(string coordinates)
        {
            int[] coordsInt = Helpers.TranslateCoordinates(coordinates);
            var shot = new Shot(battlefield, coordsInt);
            return shot;
        }

        private Battlefield battlefield;
    }
}
