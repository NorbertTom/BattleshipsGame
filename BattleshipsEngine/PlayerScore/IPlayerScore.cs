
namespace BattleshipsEngine
{
    interface IPlayerScore
    {
        public int CurrentScore { get; }
        public void AddPoint();
        public bool HasGameEnded();
    }
}
