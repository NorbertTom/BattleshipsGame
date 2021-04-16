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
            var uIBattlefieldPrinter = new UIBattlefieldPrinter(game.Battlefield);
            uIBattlefieldPrinter.Print();

            UIMessages.AskForCoordinatesMessage();
            string coordsInput = Console.ReadLine();
            bool inputValid = ValidateUserInput.coordinates(coordsInput);
            if (!inputValid)
            {
                UIMessages.InvalidCoordinatesInputMessage();
                return;
            }

            IShot shot = game.TryShot(coordsInput);
            if (shot==null)
            {
                UIMessages.FieldAlreadyShotMessage();
                return;
            }

            IShip ship = shot.HitShip;
            if (ship != null)
            {
                string message = getInfoAboutShip(ship);
                UIMessages.HitMessage(message);
            }
            else
            {
                UIMessages.MissMessage();
            }
        }

        static string getInfoAboutShip(IShip ship)
        {
            string message = ship.Name;
            message = ship.IsDestroyed() ? message + ". You sunk the ship." : message;
            return message;
        }
    }
}
