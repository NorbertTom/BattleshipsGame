using System;

namespace BattleshipsGame
{
    static class UIMessages
    {
        public static void OpeningMessage()
        {
            Console.WriteLine("That will be an opening message.");
        }

        public static void AskForCoordinatesMessage()
        {
            Console.WriteLine("That will be a message asking for coordinates.");
        }

        public static void InvalidCoordinatesInputMessage()
        {
            Console.WriteLine("That will be a message saying you input wrong coordinates.");
        }

        public static void FieldAlreadyShotMessage()
        {
            Console.WriteLine("That will be a message saying field was already shot");
        }

        public static void MissMessage()
        {
            Console.WriteLine("That will be a message saying you missed");
        }

        public static void HitMessage(string shipsName)
        {
            Console.WriteLine("That will be a message saying you hit " + shipsName);
        }
    }
}
