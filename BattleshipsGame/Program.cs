using System;

namespace BattleshipsGame
{
    using BattleshipsEngine;

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            var gameInitializer = new GameInitializer(random);
            var game = gameInitializer.createGame();

            UIMessages.OpeningMessage();
            Console.ReadLine();

            while (game.ShouldKeepPlaying())
            {
                executeGameLoop(game);
            }
            UIMessages.GameEndMessage();
        }

        static void executeGameLoop(IGame game)
        {
            var uIBattlefieldPrinter = new UIBattlefieldPrinter(game.GetBattlefield());
            uIBattlefieldPrinter.Print();

            UIMessages.AskForCoordinatesMessage();
            string coordsInput = Console.ReadLine();
            bool inputValid = ValidateUserInput.coordinates(coordsInput);
            if (!inputValid)
            {
                UIMessages.InvalidCoordinatesInputMessage();
                return;
            }

            IShot shot = game.PrepareShot(coordsInput);
            if (!(shot.IsShotValid()))
            {
                UIMessages.FieldAlreadyShotMessage();
                return;
            }

            bool isShipHit = shot.Fire();
            if (isShipHit)
            {
                string message = getInfoAboutShip(shot.GetHitShip());
                UIMessages.HitMessage(message);
            }
            else
            {
                UIMessages.MissMessage();
            }
        }

        static string getInfoAboutShip(IShip ship)
        {
            string message = ship.GetName();
            message = ship.IsDestroyed() ? message + ". You sunk the ship." : message;
            return message;
        }
    }
}
