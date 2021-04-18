namespace BattleshipsEngine
{
    public interface IGame
    {
        public IBattlefield Battlefield { get; }
        public IShot Shoot(string coordinates);
        public bool ShouldKeepPlaying();
    }
}
