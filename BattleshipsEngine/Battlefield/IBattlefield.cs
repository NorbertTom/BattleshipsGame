
namespace BattleshipsEngine
{
    public interface IBattlefield
    {
        public bool Acquire(IField[,] fields);
        public IField GetField(int column, int row);
    }
}
