using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteenVersionSeven;
using System.IO;

namespace GameFifteenVersionSevenTests
{
    [TestClass]
    public class ProgramClassTests
    {
        [TestMethod]
        public void ShouldReturnSpecificString_MainMethodTest()
        {
            var oldIn = Console.In;
            Console.SetIn(new StringReader("A\r\nexit"));
            string result = String.Empty;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                Program.Main();

                writer.Flush();

                result = writer.GetStringBuilder().ToString();
            }
            Console.SetIn(oldIn);
            string expectedMessage = "Illegal command!\r\nEnter a number to move: Good bye!\r\n";
            string resultString = result.Substring(result.Length - 53);
            Assert.IsTrue(expectedMessage == resultString);
        }
    }
}
