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
            PrintLegendRows();
            for (int i=0;i<BattlefieldSize;i++)
            {
                PrintRow(i);
            }
        }

        private void PrintLegendRows()
        {
            Console.WriteLine("\n   ABCDEFGHIJ | ? - unknown, X - miss, H - hit\n" +
                                 "  -----------");
        }

        private void PrintRow(int rowNr)
        {
            PrintLegendPrefix(rowNr);
            for (int i=0; i<BattlefieldSize; i++)
            {
                PrintField(rowNr, i);
            }
            Console.Write("\n");
        }

        private void PrintLegendPrefix(int rowNr)
        {
            Console.Write(rowNr + " |");
        }

        private void PrintField(int rowNr, int columnNr)
        {
            IField field = battlefield.GetField(columnNr, rowNr);
            bool isFieldShot = field.IsShot();
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
