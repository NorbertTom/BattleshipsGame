using System;

namespace BattleshipsEngine
{
    public interface IField
    {
        public bool IsShot();
        public bool IsShipThere();
        public void PlaceShip(IShip ship);
        public IShip Shoot();
    }
}
