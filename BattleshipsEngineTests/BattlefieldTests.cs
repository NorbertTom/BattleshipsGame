using System;
using Xunit;
using Moq;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class BattlefieldTests
    {
        [Fact]
        public void acquireFieldsTest()
        {
            var battlefield = new Battlefield();
            
            Field[,] fields = new Field[10, 10];
            Assert.True(battlefield.AcquireFields(fields));
            Field[,] fieldsInvalid = new Field[11, 11];
            Assert.False(battlefield.AcquireFields(fieldsInvalid));

        }

        [Fact]
        public void getField()
        {
            var battlefield = new Battlefield();
            Field[,] fields = new Field[10, 10];
            initializeFields(fields);
            var someField = fields[4, 7];
            Assert.True(battlefield.AcquireFields(fields));
            Assert.Equal(someField, battlefield.GetField(4, 7));
        }

        [Fact]
        public void getFieldThatWasPreviouslyShot()
        {
            var battlefield = new Battlefield();
            Field[,] fields = new Field[10, 10];
            initializeFields(fields);
            battlefield.AcquireFields(fields);
            Assert.False(battlefield.GetField(3, 9).IfShot());
            battlefield.GetField(3, 9).Shoot();
            Assert.True(battlefield.GetField(3, 9).IfShot());
        }

        private void initializeFields(Field[,] fields)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    fields[i, j] = new Field();
                }
            }
        }
    }
}
