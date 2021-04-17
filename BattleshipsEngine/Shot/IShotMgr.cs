using System;

namespace BattleshipsEngine
{
    public interface IShotMgr
    {
        public bool WillShotBeValid();
        public IShot Shoot();
    }
}
