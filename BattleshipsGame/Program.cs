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
            var game = gameInitializer.CreateGame();

            UIMessages.OpeningMessage();
            Console.ReadLine();

            var battlefieldPrinter = new UIBattlefieldPrinter(game.Battlefield);

            while (game.ShouldKeepPlaying())
            {
                ExecuteGameLoop(game, battlefieldPrinter);
            }
            UIMessages.GameEndMessage();
        }

        static void ExecuteGameLoop(IGame game, UIBattlefieldPrinter battlefieldPrinter)
        {
            battlefieldPrinter.Print();

            UIMessages.AskForCoordinatesMessage();
            string coordsInput = Console.ReadLine();
            bool inputValid = ValidateUserInput.Coordinates(coordsInput);
            if (!inputValid)
            {
                UIMessages.InvalidCoordinatesInputMessage();
                return;
            }

            var shot = game.Shoot(coordsInput);
            if (shot==null)
            {
                UIMessages.FieldAlreadyShotMessage();
                return;
            }

            if (shot.HitShip != null)
            {
                string message = GetInfoAboutShip(shot.HitShip);
                UIMessages.HitMessage(message);
            }
            else
            {
                UIMessages.MissMessage();
            }
        }

        static string GetInfoAboutShip(IShip ship)
        {
            string message = ship.Name;
            message = ship.IsDestroyed() ? message + ". You sunk the ship." : message;
            return message;
        }
    }
}
