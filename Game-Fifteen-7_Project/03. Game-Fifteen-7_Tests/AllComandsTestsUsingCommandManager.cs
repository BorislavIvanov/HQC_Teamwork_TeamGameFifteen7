using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteenVersionSeven;

namespace GameFifteenVersionSevenTests
{
    [TestClass]
    public class AllComandsTestsUsingCommandManager
    {
        [TestMethod]
        public void ShouldPrintSpecificMessage_ExitCommandTest()
        {
            GameEngine testEngine = new GameEngine();
            ICommand exitCommand = new ExitCommand(testEngine);

            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                testEngine.CommandManager.Proceed(exitCommand);

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "Good bye!\r\n";
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void ShouldReturnTrue_ExitCommandTest()
        {
            GameEngine testEngine = new GameEngine();
            ICommand exitCommand = new ExitCommand(testEngine);
            testEngine.CommandManager.Proceed(exitCommand);

            Assert.IsTrue(testEngine.IsGameOver);
        }

        [TestMethod]
        public void ShouldReturnTrue_RestartCommandTest()
        {
            GameEngine testEngine = new GameEngine();
            testEngine.CountTotalMoves=2;
            ICommand restartCommand = new RestartCommand(testEngine);
            testEngine.CommandManager.Proceed(restartCommand);

            Assert.IsTrue(testEngine.CountTotalMoves==0);
        }
    }
}
