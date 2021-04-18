using System;

namespace BattleshipsEngine
{
    class Field : IField
    {
        public bool IsShot() { return wasShot; }
        public void PlaceShip(IShip ship) { this.ship = ship; }

        public IShip Shoot()
        {
            if (wasShot)
            {
                throw new Exception("Field already shot");
            }

            wasShot = true;
            return ship;
        }

        public bool IsShipThere()
        {
            return ship != null;
        }

        private bool wasShot = false;
        private IShip ship = null;
    }
}
