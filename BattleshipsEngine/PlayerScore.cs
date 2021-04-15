using System;

namespace BattleshipsEngine
{
    class PlayerScore : IPlayerScore
    {
        public PlayerScore(int maxPoints)
        {
            this.maxPoints = maxPoints;
        }

        public void AddPoint()
        {
            currentScore++;
        }

        public int GetCurrentScore()
        {
            return currentScore;
        }

        public bool HasGameEnded()
        {
            return currentScore == maxPoints;
        }

        private int maxPoints;
        private int currentScore;
    }
}
