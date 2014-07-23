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
            Player testPlayer = new Player();
            GameEngine testEngine = new GameEngine(testPlayer);
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
            Player testPlayer =new Player();
            GameEngine testEngine = new GameEngine(testPlayer);
            ICommand exitCommand = new ExitCommand(testEngine);
            testEngine.CommandManager.Proceed(exitCommand);

            Assert.IsTrue(testEngine.IsGameOver);
        }

        [TestMethod]
        public void ShouldReturnTrue_RestartCommandTest_ChangeCountTotalMoves()
        {
            Player testPlayer = new Player();
            GameEngine testEngine = new GameEngine(testPlayer);
            testEngine.Player.TotalMoves = 2;
            ICommand restartCommand = new RestartCommand(testEngine);
            testEngine.CommandManager.Proceed(restartCommand);

            Assert.IsTrue(testEngine.Player.TotalMoves == 0);
        }

        [TestMethod]
        public void ShouldPrintEmptyScoreboardMessage_TopCommandTest()
        {
            Player testPlayer = new Player();
            GameEngine testEngine = new GameEngine(testPlayer);
            List<Player> topPlayersScores = new List<Player>();
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
            Player firstPlayer = new Player();
            firstPlayer.Name = "Pesho";
            firstPlayer.TotalMoves = 4;
            GameEngine testEngine = new GameEngine(firstPlayer);
            List<Player> topPlayersScores = new List<Player>();

            Player secondPlayer=new Player();
            secondPlayer.Name = "Spiro";
            secondPlayer.TotalMoves = 6;

            topPlayersScores.Add(firstPlayer);
            topPlayersScores.Add(secondPlayer);

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
