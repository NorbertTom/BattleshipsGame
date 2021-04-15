using System;

namespace BattleshipsEngine
{
    static class Helpers
    {
        public static int[] TranslateCoordinates(string coordinatesString)
        {
            int column = translateCharCapitalLetterToInt(coordinatesString[0]);
            int row = Int32.Parse(coordinatesString[1].ToString());
            int[] coordinates = { column, row };
            return coordinates;
        }

        private static int translateCharCapitalLetterToInt(char capitalLetter)
        {
            const int CapitalAInAscii = 65;
            int temp = capitalLetter;
            return capitalLetter - CapitalAInAscii;
        }
    }
}