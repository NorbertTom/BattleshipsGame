using System;

namespace BattleshipsEngine
{
    interface IField
    {
        public bool IfShot();
        public void PlaceShip(IShip ship);
        public IShip Shoot();
    }
}
