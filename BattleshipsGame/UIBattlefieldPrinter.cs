using System;
using BattleshipsEngine;


namespace BattleshipsGame
{
    class UIBattlefieldPrinter
    {
        public UIBattlefieldPrinter(IBattlefield battlefield)
        {
            this.battlefield = battlefield;
        }

        public void Print()
        {
            printLegendRows();
            for (int i=0;i<BattlefieldSize;i++)
            {
                printRow(i);
            }
        }

        private void printLegendRows()
        {
            Console.WriteLine("   ABCDEFGHIJ");
            Console.WriteLine("  -----------");
        }

        private void printRow(int rowNr)
        {
            printLegendPrefix(rowNr);
            for (int i=0;i<BattlefieldSize;i++)
            {
                printField(rowNr, i);
            }
            Console.Write("\n");
        }

        private void printLegendPrefix(int rowNr)
        {
            Console.Write(rowNr + " |");
        }

        private void printField(int rowNr, int columnNr)
        {
            IField field = battlefield.GetField(columnNr, rowNr);
            bool isFieldShot = field.IfShot();
            if (isFieldShot)
            {
                if (field.IsShipThere())
                {
                    Console.Write('H');
                }
                else 
                {
                    Console.Write('X');
                }
            }
            else 
            {
                Console.Write("?");
            }
        }

        IBattlefield battlefield;
        const int BattlefieldSize = 10;
    }
}
