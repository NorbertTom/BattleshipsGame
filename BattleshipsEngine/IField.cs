using System;

namespace BattleshipsEngine
{
    public interface IField
    {
        public bool IfShot();
        public bool IsShipThere();
        public void PlaceShip(IShip ship);
        public IShip Shoot();
    }
}
