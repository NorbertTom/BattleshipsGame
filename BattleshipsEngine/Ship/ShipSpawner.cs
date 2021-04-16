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
            indiciesOccupiedWithShips = new List<int[]>();
        }

        public bool SpawnShip(IShip ship)
        {
            bool shipSpawned = false;

            shipsLength = ship.Length;
            isVertical = random.Next(2) == 0 ? true : false;
            int[] startingPosition = new int[2];
            int nrOfCycles = 0;
            const int cyclesLimit = 50;

            while (!shipSpawned)
            {
                startingPosition = GetRandomizedStartingPosition();
                shipSpawned = !IsShipCollidingWithAnother(startingPosition);
                nrOfCycles++;
                if (nrOfCycles > cyclesLimit)
                    return false;
            }

            PlaceShipOnBattlefield(startingPosition, ship);

            return shipSpawned;
        }

        private int[] GetRandomizedStartingPosition()
        {
            int column, row;

            if (isVertical)
            {
                column = random.Next(BattlefieldHighestIndex+1);
                row = random.Next(BattlefieldHighestIndex - shipsLength + 2);
            }
            else 
            {
                column = random.Next(BattlefieldHighestIndex - shipsLength + 2);
                row = random.Next(BattlefieldHighestIndex+1);
            }

            int[] result = { column, row };
            return result;
        }

        private bool IsShipCollidingWithAnother(int[] startingPosition)
        {
            List<int[]> allShipsFieldsCoords = GetAllShipsFieldsCoords(startingPosition);

            foreach(int[] currentCoords in allShipsFieldsCoords)
            {
                foreach(int[] occupiedCoords in indiciesOccupiedWithShips)
                {
                    if (currentCoords[0] == occupiedCoords[0] && currentCoords[1] == occupiedCoords[1])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void PlaceShipOnBattlefield(int[] startingPosition, IShip ship)
        {
            var allShipsFieldsCoords = GetAllShipsFieldsCoords(startingPosition);
            foreach (int[] currentCoordinates in allShipsFieldsCoords)
            {
                battlefield.GetField(currentCoordinates[0], currentCoordinates[1]).PlaceShip(ship);
                indiciesOccupiedWithShips.Add(currentCoordinates);
            }
        }

        private List<int[]> GetAllShipsFieldsCoords(int[] startingPosition)
        {
            List<int[]> allShipsFieldsCoords = new List<int[]>();
            int changingCoordinate = isVertical ? 1 : 0;
            
            for (int i = 0; i < shipsLength; i++)
            {
                int[] currentPosition = startingPosition.Clone() as int[];
                currentPosition[changingCoordinate] = startingPosition[changingCoordinate] + i;

                if (currentPosition[0] > BattlefieldHighestIndex || currentPosition[1] > BattlefieldHighestIndex)
                {
                    throw new Exception("Ship exceeds battlefield size");
                }

                allShipsFieldsCoords.Add(currentPosition);
            }
            return allShipsFieldsCoords;
        }

        private IBattlefield battlefield;
        private Random random;
        private List<int[]> indiciesOccupiedWithShips;
        private bool isVertical;
        private int shipsLength;
        private const int BattlefieldHighestIndex = 9;
    }
}
