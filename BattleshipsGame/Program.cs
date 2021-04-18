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
            if (shot == null)
            {
                UIMessages.FieldAlreadyShotMessage();
                return;
            }

            var ship = shot.HitShip;
            if (ship == null)
            {
                UIMessages.MissMessage();
                return;
            }

            UIMessages.HitMessage(ship.Name);

            if (ship.IsDestroyed())
            {
                UIMessages.ShipDestroyedMessage();
            }
        }
    }
}