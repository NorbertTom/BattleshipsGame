using System;

namespace BattleshipsGame
{
    static class ValidateUserInput
    {
        public static bool Coordinates(string coordinates)
        {
            return coordinates.Length == 2 && IsValidLetter(coordinates[0]) && IsValidNumber(coordinates[1]);
        }

        private static bool IsValidLetter(char character)
        {
            return (character >= 'A' && character <= 'J');
        }

        private static bool IsValidNumber(char character)
        {
            return (character >= '0' && character <= '9');
        }
    }
}
