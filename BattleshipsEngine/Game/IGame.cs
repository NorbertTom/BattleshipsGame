namespace BattleshipsEngine
{
    public interface IGame
    {
        public IBattlefield GetBattlefield();
        public IShot PrepareShot(string coordinates);
        public bool ShouldKeepPlaying();
    }
}
