namespace GameFifteenVersionSevenTests
{
    using System;
    using System.IO;
    using GameFifteenVersionSeven;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConsolePrinterTests
    {
        [TestMethod]
        public void WellcomeMessageTest()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                ConsolePrinter.PrintWelcomeMessage();

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "Welcome to the game “15”.\r\nPlease try to arrange the numbers sequentially.\r\n\nUse the codes:\r\n- 'top' to view the top scoreboard\r\n- 'restart' to start a new game\r\n- 'exit' to quit the game.\r\n";
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void PrintTheGameFieldTest()
        {
            GameEngine gameEngine = new GameEngine(new Player());

            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                ConsolePrinter.PrintTheGameField(gameEngine.PuzzleField);

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = " -------------\r\n|  1  2  3  4 |\r\n|  5  6  7  8 |\r\n|  9 10 11 12 |\r\n| 13 14 15    |\r\n";
                Assert.AreEqual(expected, result);
            }
        }
    }
}
