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
            //Mock<IField>[,] mockedFields = new Mock<IField>[10, 10];
            
            Field[,] fields = new Field[10, 10];
            Assert.True(battlefield.AcquireFields(fields));
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
        { }

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
