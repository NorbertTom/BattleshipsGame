using System;
using Xunit;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class HelpersTests
    {
        [Theory]
        [InlineData("A0", 0, 0)]
        [InlineData("C2", 2, 2)]
        [InlineData("F7", 5, 7)]
        [InlineData("J1", 9, 1)]
        [InlineData("J9", 9, 9)]
        public void GivenValidInput_TranslatingCoordinatesWorkAsExpected(
                            string coordString, int expectedX, int expectedY)
        {
            int[] expectedResult = { expectedX, expectedY };
            int[] actualResult = Helpers.TranslateCoordinates(coordString);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}