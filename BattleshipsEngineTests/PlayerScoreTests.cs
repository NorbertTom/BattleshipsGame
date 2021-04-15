using System;
using Xunit;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class PlayerScoreTests
    {
        [Fact]
        public void AddPoints()
        {
            var playerScore = new PlayerScore(13);
            Assert.Equal(0, playerScore.GetCurrentScore());
            playerScore.AddPoint();
            Assert.Equal(1, playerScore.GetCurrentScore());
        }

        [Fact]
        public void EndOfTheGame()
        {
            var playerScore = new PlayerScore(13);
            Assert.False(playerScore.HasGameEnded());
            for (int i = 0; i < 13; i++)
            {
                playerScore.AddPoint();
            }
            Assert.Equal(13, playerScore.GetCurrentScore());
            Assert.True(playerScore.HasGameEnded());
        }
    }
}
