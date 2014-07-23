using System;
using System.IO;
using System.Net.WebSockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteenVersionSeven;

namespace GameFifteenVersionSevenTests
{
    [TestClass]
    public class CellClassTests
    {
        [TestMethod]
        public void ShouldReturnFalse_CompareContextOfOriginalAndClonedInstances()
        {
            Cell firstCell = new Cell();
            firstCell.Content = 1;
            Cell secondCell = firstCell.Clone() as Cell;
            secondCell.Content = 2;

            Assert.IsFalse(firstCell.Content == secondCell.Content);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void ShouldThrowArgumentException_SetInvalidValueForCellContent()
        {
            try
            {
                Cell testCell = new Cell();
                testCell.Content = -1;
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The content must be a positive integer!", ex.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void ShouldThrowArgumentException_SetInvalidValueForCellColumn()
        {
            try
            {
                Cell testCell = new Cell();
                testCell.Col = -1;
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The number of column must be a positive integer!", ex.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void ShouldThrowArgumentException_SetInvalidValueForCellRow()
        {
            try
            {
                Cell testCell = new Cell();
                testCell.Row = -1;
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The number of row must be a positive integer!", ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void ShouldPrintSpecificMessage_PrintMethodTestWithTwoDigitContent()
        {
            Cell testCell = new Cell();
            testCell.Content = 11;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                testCell.Print();

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "11 ";
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void ShouldPrintSpecificMessage_PrintMethodTestWithZero()
        {
            Cell testCell = new Cell();
            testCell.Content = 0;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                testCell.Print();

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "   ";
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void ShouldPrintSpecificMessage_PrintMethodTestWithOneDigitNoZeroContent()
        {
            Cell testCell = new Cell();
            testCell.Content = 5;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                testCell.Print();

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = " 5 ";
                Assert.AreEqual(expected, result);
            }
        }
    }
}
