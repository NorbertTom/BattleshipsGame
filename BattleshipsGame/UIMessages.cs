using System;

namespace BattleshipsGame
{
    static class UIMessages
    {
        public static void OpeningMessage()
        {
            Console.Write("Welcome to the Battleships Game.\n" +
                          "There are 3 ships you have to shoot down:\n" +
                          "1 Battleship (5 units long)\n" +
                          "2 Destroyers (4 units long)\n" +
                          "You shoot by entering the coordinates as two characters:\n" +
                          "capital letter as a column and number as a row, and pressing ENTER\n" +
                          "Please use no spacing between them\n" +
                          "If you are ready to have some fun please hit ENTER\n");
        }

        public static void AskForCoordinatesMessage()
        {
            Console.WriteLine("Please enter the coordinates (example: A7)");
        }

        public static void InvalidCoordinatesInputMessage()
        {
            Console.WriteLine("You entered incorrect coordinates, please try again");
        }

        public static void FieldAlreadyShotMessage()
        {
            Console.WriteLine("You have already shot that field, please choose different one");
        }

        public static void MissMessage()
        {
            Console.WriteLine("MISS");
        }

        public static void HitMessage(string shipsName)
        {
            Console.WriteLine("HIT: " + shipsName);
        }

        public static void GameEndMessage()
        {
            Console.WriteLine("You destroyed all ships. Congratulations!");
        }
    }
}
