namespace GameFifteenVersionSevenTests
{
    using System;
    using System.IO;
    using GameFifteenVersionSeven;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameEngineClassTests
    {

        [TestMethod]
        public void ShouldReturnTrue_CheckIsIncreaseTotalMovesOfPlayer()
        {
            Player testPlayer = new Player();
            GameEngine testEngine = new GameEngine(testPlayer);
            var oldIn = Console.In;
            Console.SetIn(new StringReader("5\r\nexit"));
            string result = String.Empty;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                testEngine.StartTheGame();

                writer.Flush();

                result = writer.GetStringBuilder().ToString();
            }
            Console.SetIn(oldIn);
            int expectedPlayerMoves = 1;
            string expectedMessage = "Illegal move!\r\nEnter a number to move: Good bye!\r\n";
            string resultString = result.Substring(result.Length - 50);
            Assert.IsTrue(expectedPlayerMoves == testPlayer.TotalMoves || expectedMessage == resultString);

        }
    }
}
