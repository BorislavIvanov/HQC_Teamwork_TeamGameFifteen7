using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteenVersionSeven;

namespace GameFifteenVersionSevenTests
{
    [TestClass]
    public class AllComandsTestsUsingCommandManager
    {
        [TestMethod]
        public void ShouldPrintFinalMessage_ExitCommandTest()
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
        public void ShouldReturnTrue_IsGameOver_ExitCommandTest()
        {
            GameEngine testEngine = new GameEngine();
            ICommand exitCommand = new ExitCommand(testEngine);
            testEngine.CommandManager.Proceed(exitCommand);

            Assert.IsTrue(testEngine.IsGameOver);
        }

        [TestMethod]
        public void ShouldReturnTrue_RestartCommandTest_ChangeCountTotalMoves()
        {
            GameEngine testEngine = new GameEngine();
            testEngine.CountTotalMoves=2;
            ICommand restartCommand = new RestartCommand(testEngine);
            testEngine.CommandManager.Proceed(restartCommand);

            Assert.IsTrue(testEngine.CountTotalMoves==0);
        }

        [TestMethod]
        public void ShouldPrintEmptyScoreboardMessage_TopCommandTest()
        {
            GameEngine testEngine = new GameEngine();
            List<Tuple<string, int>> topPlayersScores=new List<Tuple<string, int>>();
            ICommand topCommand = new TopCommand(topPlayersScores);
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                testEngine.CommandManager.Proceed(topCommand);

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "\nScoreboard:\r\nEmpty Scoreboard! :)\r\n\r\n";
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void ShouldPrintSampleScoreboardMessage_TopCommandTest()
        {
            GameEngine testEngine = new GameEngine();
            List<Tuple<string, int>> topPlayersScores=new List<Tuple<string, int>>();
            topPlayersScores.Add(new Tuple<string, int>("Pesho", 4));
            topPlayersScores.Add(new Tuple<string, int>("Spiro", 6));
            ICommand topCommand = new TopCommand(topPlayersScores);
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                testEngine.CommandManager.Proceed(topCommand);

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "\nScoreboard:\r\nPesho by 4\r\nSpiro by 6\r\n\r\n";
                Assert.AreEqual(expected, result);
            }
        }
    }
}
