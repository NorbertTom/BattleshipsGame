namespace BattleshipsEngine
{
    public interface IGame
    {
        public IBattlefield Battlefield { get; }
        public IShotMgr PrepareShot(string coordinates);
        public bool ShouldKeepPlaying();
    }
}
