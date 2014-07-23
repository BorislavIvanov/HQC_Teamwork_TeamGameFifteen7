using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteenVersionSeven;
using System.IO;

namespace GameFifteenVersionSevenTests
{
    [TestClass]
    public class GameEngineClassTests
    {
        [TestMethod]
        public void ShouldReturnTrue_DefineCommandsMethodTest()
        {
            Player testPlayer = new Player();
            GameEngine testEngine = new GameEngine(testPlayer);
            List<Player> testTopPlayers = new List<Player>();
        }
    }
}
