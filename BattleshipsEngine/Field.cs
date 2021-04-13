using System;

namespace BattleshipsEngine
{
    class Field
    {
        public Field()
        { }

        public bool IfShot() { return wasShot; }
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

        private bool wasShot = false;
        private IShip ship = null;
    }
}
