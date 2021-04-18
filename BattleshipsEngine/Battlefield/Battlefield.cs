using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipsEngine
{
    class Battlefield : IBattlefield
    {
        public bool Acquire(IField[,] fields)
        {
            bool result = false;
            
            if (fields.Length == 100)
            {
                this.fields = fields;
                result = true;
            }

            return result;
        }
        
        public IField GetField(int column, int row)
        {
            return fields[column, row];
        }

        IField[,] fields;
    }
}