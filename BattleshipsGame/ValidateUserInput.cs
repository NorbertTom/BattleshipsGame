using System;

namespace BattleshipsGame
{
    static class ValidateUserInput
    {
        public static bool coordinates(string coordinates)
        {
            bool isInputValid = false;
            if (coordinates.Length==2 
                && !(coordinates[0] < 'A' || coordinates[0] > 'J')
                && !(coordinates[1] < '0' || coordinates[1] > '9'))
            {
                isInputValid = true;
            }
            return isInputValid;
        }
    }
}
