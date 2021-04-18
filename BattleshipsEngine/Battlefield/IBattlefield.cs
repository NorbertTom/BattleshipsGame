
namespace BattleshipsEngine
{
    public interface IBattlefield
    {
        public bool AcquireFields(IField[,] fields);
        public IField GetField(int column, int row);
    }
}
