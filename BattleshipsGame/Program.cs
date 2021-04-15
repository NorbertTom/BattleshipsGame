using System;

namespace BattleshipsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // var game = new Game();
            // game initialization
            UIMessages.OpeningMessage();

            bool gameOn = true; // connection from game needed - if enough points was scored or not
            while (gameOn)
            {
                //var uIBattlefieldPrinter = new UIBattlefieldPrinter(); - need Battlefield from game
                UIMessages.AskForCoordinatesMessage();
                string coordsInput = Console.ReadLine();
                bool inputValid = ValidateUserInput.coordinates(coordsInput);
                if (inputValid)
                {
                    // Translate coords string to coords, should be part of Game project / really?
                    // Shoot (coords) - needs Shoot class, or IShot and than GetName and GetOutcome

                }
            }
            Console.WriteLine("Hello World! ");
        }
    }
}
