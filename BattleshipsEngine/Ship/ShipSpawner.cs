using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace BattleshipsEngine
{
    class ShipSpawner
    {
        public ShipSpawner(IBattlefield battlefield, Random random)
        {
            this.battlefield = battlefield;
            this.random = random;
            fieldsOccupiedBySpawnedShips = new List<int[]>();
            startingPosition = new int[2];
        }

        public bool SpawnShip(IShip ship)
        {
            bool shipSpawnSucceeded = false;

            shipsLength = ship.Length;
            isVertical = random.Next(2) == 0 ? true : false;
            int nrOfCycles = 0;
            const int cyclesLimit = 50;

            while (!shipSpawnSucceeded)
            {
                RandomizeStartingPosition();
                SetAllFieldsOccupiedByNewShip();
                shipSpawnSucceeded = !IsShipCollidingWithAnother();
                nrOfCycles++;
                if (nrOfCycles > cyclesLimit)
                    return false;
            }

            PlaceShipOnBattlefield(ship);

            return shipSpawnSucceeded;
        }

        private void RandomizeStartingPosition()
        {
            if (isVertical)
            {
                startingPosition[0] = random.Next(BattlefieldHighestIndex + 1);
                startingPosition[1] = random.Next(BattlefieldHighestIndex - shipsLength + 2);
            }
            else
            {
                startingPosition[0] = random.Next(BattlefieldHighestIndex - shipsLength + 2);
                startingPosition[1] = random.Next(BattlefieldHighestIndex + 1);
            }
        }

        private void SetAllFieldsOccupiedByNewShip()
        {
            fieldsOccupiedByNewShip = new List<int[]>();
            int shipsDirection = isVertical ? 1 : 0;

            for (int i = 0; i < shipsLength; i++)
            {
                int[] currentPosition = startingPosition.Clone() as int[];
                currentPosition[shipsDirection] = startingPosition[shipsDirection] + i;

                if (currentPosition[0] > BattlefieldHighestIndex || currentPosition[1] > BattlefieldHighestIndex)
                {
                    throw new Exception("Ship exceeds battlefield size");
                }

                fieldsOccupiedByNewShip.Add(currentPosition);
            }
        }

        private bool IsShipCollidingWithAnother()
        {
            foreach(int[] newShipsCoords in fieldsOccupiedByNewShip)
            {
                foreach(int[] occupiedCoords in fieldsOccupiedBySpawnedShips)
                {
                    if (newShipsCoords[0] == occupiedCoords[0] && newShipsCoords[1] == occupiedCoords[1])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void PlaceShipOnBattlefield(IShip ship)
        {
            foreach (int[] newShipsCoords in fieldsOccupiedByNewShip)
            {
                battlefield.GetField(newShipsCoords[0], newShipsCoords[1]).PlaceShip(ship);
                fieldsOccupiedBySpawnedShips.Add(newShipsCoords);
            }
        }

        private IBattlefield battlefield;
        private Random random;
        private List<int[]> fieldsOccupiedBySpawnedShips;
        private List<int[]> fieldsOccupiedByNewShip;
        private bool isVertical;
        private int shipsLength;
        private int[] startingPosition;
        private const int BattlefieldHighestIndex = 9;
    }
}
