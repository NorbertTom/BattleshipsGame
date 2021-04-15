
namespace BattleshipsEngine
{
    interface IPlayerScore
    {
        public void AddPoint();
        public int GetCurrentScore();
        public bool HasGameEnded();
    }
}
