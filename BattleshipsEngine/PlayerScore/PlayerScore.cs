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
            CurrentScore++;
        }

        public bool HasGameEnded()
        {
            return CurrentScore == maxPoints;
        }

        public int CurrentScore { get; private set; }
        private int maxPoints;
    }
}
