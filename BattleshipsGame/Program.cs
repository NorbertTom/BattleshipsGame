using System;

namespace BattleshipsGame
{
    using BattleshipsEngine;

    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Initialize();

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
                    //IShot shot = game.PrepareShot
                    //if (shot.IsShotValid()))
                        //bool result = shot.Fire();
                        //if (result)
                            //IShip ship = shot.GetHitShip()
                            //UI message -> you hit XX Ship!
                        //else
                            //UI message -> you missed
                    //else
                        //UI message -> field already shot
                }
                else
                {
                    //UI Message -> invalid input
                }
            }
            Console.WriteLine("Hello World! ");
        }
    }
}
