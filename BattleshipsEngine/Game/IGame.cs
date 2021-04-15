namespace BattleshipsEngine
{
    public interface IGame
    {
        public IBattlefield GetBattlefield();
        public IShot TryShot(string coordinates);
        public bool ShouldKeepPlaying();
    }
}
