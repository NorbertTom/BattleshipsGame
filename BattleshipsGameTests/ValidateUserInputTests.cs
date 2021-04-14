using System;
using Xunit;
using BattleshipsGame;

namespace BattleshipsGameTests
{
    public class ValidateUserInputTests
    {
        [Fact]
        public void validateCoordinates()
        {
            string[] validInputs = { "A4", "F0", "J9", "B1", "D7" };
            string[] invalidInputs = { "K4", "a0", "X9", "B10", "8X" };

            foreach(string validInput in validInputs)
            {
                Assert.True(ValidateUserInput.coordinates(validInput));
            }

            foreach(string invalidInput in invalidInputs)
            {
                Assert.False(ValidateUserInput.coordinates(invalidInput));
            }
        }
    }
}
