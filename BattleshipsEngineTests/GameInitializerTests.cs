using System;
using Xunit;
using Moq;
using BattleshipsEngine;

namespace BattleshipsEngineTests
{
    public class GameInitializerTests
    {
        [Fact]
        public void initializeBattlefield()
        {
            var battlefield = new Mock<IBattlefield>();
            GameInitializer.Initialize(battlefield.Object);
            battlefield.Verify(x => x.AcquireFields(It.IsAny<Field[,]>()), Times.Once());
        }
    }
}
