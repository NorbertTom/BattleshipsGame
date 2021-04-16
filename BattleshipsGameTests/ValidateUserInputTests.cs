using System;
using Xunit;
using BattleshipsGame;

namespace BattleshipsGameTests
{
    public class ValidateUserInputTests
    {
        [Theory]
        [InlineData("A4")]
        [InlineData("F0")]
        [InlineData("J9")]
        [InlineData("B1")]
        [InlineData("D7")]
        public void ValidateCoordinates_Valid(string validInput)
        {
            Assert.True(ValidateUserInput.Coordinates(validInput));
        }

        [Theory]
        [InlineData("K4")]
        [InlineData("a0")]
        [InlineData("X9")]
        [InlineData("B10")]
        [InlineData("8X")]
        public void ValidateCoordinates_invalid(string invalidInput)
        {
            Assert.False(ValidateUserInput.Coordinates(invalidInput));
        }
    }
}
