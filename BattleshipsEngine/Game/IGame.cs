namespace BattleshipsEngine
{
    public interface IGame
    {
        public IBattlefield Battlefield { get; }
        public IShot TryShot(string coordinates);
        public bool ShouldKeepPlaying();
    }
}
