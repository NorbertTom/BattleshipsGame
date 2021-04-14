using System;

namespace BattleshipsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // game initialization
            UIMessages.OpeningMessage();

            bool gameOn = true; // connection from game needed - if enough points was scored or not
            while (gameOn)
            {
                //var uIBattlefieldPrinter = new UIBattlefieldPrinter(); - needs Battlefield from game
                UIMessages.AskForCoordinatesMessage();
                string coordsInput = Console.ReadLine();
                bool inputValid = ValidateUserInput.coordinates(coordsInput);
                if (inputValid)
                {
                    // Translate coords string to coords
                    //Shoot (battlefield, coords) - needs Shoot class
                }
            }
            Console.WriteLine("Hello World! ");
        }
    }
}
