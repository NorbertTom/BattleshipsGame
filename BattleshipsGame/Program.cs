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

            while (game.ShouldKeepPlaying())
            {
                var uIBattlefieldPrinter = new UIBattlefieldPrinter(game.GetBattlefield());
                uIBattlefieldPrinter.Print();
                UIMessages.AskForCoordinatesMessage();
                string coordsInput = Console.ReadLine();
                bool inputValid = ValidateUserInput.coordinates(coordsInput);
                if (inputValid)
                {
                    IShot shot = game.PrepareShot(coordsInput);
                    if (shot.IsShotValid())
                    {
                        bool shipHit = shot.Fire();
                        if (shipHit)
                        {
                            //check if it's not sunken
                            IShip ship = shot.GetHitShip();
                            UIMessages.HitMessage(ship.GetName());
                        }
                        else
                        {
                            UIMessages.MissMessage();
                        }
                    }
                    else
                    {
                        UIMessages.FieldAlreadyShotMessage();
                    }
                }
                else
                {
                    UIMessages.InvalidCoordinatesInputMessage();
                }
            }
            Console.WriteLine("Hello World! ");
        }
    }
}
