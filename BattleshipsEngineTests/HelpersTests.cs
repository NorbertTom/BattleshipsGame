using System;
using Xunit;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class HelpersTests
    {
        [Fact]
        public void TranslateCoordinatesTest1()
        {
            string coordinatesString = "A0";
            int[] expectedResult = { 0, 0 };
            int[] actualResult = Helpers.TranslateCoordinates(coordinatesString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TranslateCoordinatesTest2()
        {
            string coordinatesString = "C2";
            int[] expectedResult = { 2, 2 };
            int[] actualResult = Helpers.TranslateCoordinates(coordinatesString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TranslateCoordinatesTest3()
        {
            string coordinatesString = "F7";
            int[] expectedResult = { 5, 7 };
            int[] actualResult = Helpers.TranslateCoordinates(coordinatesString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TranslateCoordinatesTest4()
        {
            string coordinatesString = "J1";
            int[] expectedResult = { 9, 1 };
            int[] actualResult = Helpers.TranslateCoordinates(coordinatesString);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TranslateCoordinatesTest5()
        {
            string coordinatesString = "J9";
            int[] expectedResult = { 9, 9 };
            int[] actualResult = Helpers.TranslateCoordinates(coordinatesString);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
