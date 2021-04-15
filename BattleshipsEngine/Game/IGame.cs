namespace BattleshipsEngine
{
    public interface IGame
    {
        public void Initialize();
        public IBattlefield GetBattlefield();
        public IShot PrepareShot(string coordinates);
        public bool ShouldKeepPlaying();
    }
}
