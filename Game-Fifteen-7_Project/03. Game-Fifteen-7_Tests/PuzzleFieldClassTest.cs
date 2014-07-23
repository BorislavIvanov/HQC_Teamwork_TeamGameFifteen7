using System.Collections.Generic;

namespace GameFifteenVersionSevenTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteenVersionSeven;

    [TestClass]
    public class PuzzleFieldClassTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void ShouldThrowArgumentException_SetInvalidInitalValue()
        {
            try
            {
                PuzzleField testField = new PuzzleField(4, -1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The initial value must be a positive integer", ex.Message);
                throw;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void ShouldThrowArgumentException_SetInvalidMatrixSize()
        {
            try
            {
                PuzzleField testField = new PuzzleField(-1, 0);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The matrix size must be a positive integer", ex.Message);
                throw;
            }

        }

        [TestMethod]
        public void ShouldBeEqual_FillPuzzleBodyMethodTest()
        {
            PuzzleField testField = new PuzzleField(3, 0);
            List<Cell> expectedBody=new List<Cell>();
            Cell firstCell=new Cell();
            firstCell.Content = 1;
            firstCell.Row = 0;
            firstCell.Col = 0;
            Cell secondCell=new Cell();
            secondCell.Content = 2;
            secondCell.Row = 0;
            secondCell.Col = 1;
            Cell thirdCell=new Cell();
            thirdCell.Content = 3;
            thirdCell.Row = 0;
            thirdCell.Col = 2;
            Cell fourthCell=new Cell();
            fourthCell.Content = 4;
            fourthCell.Row = 1;
            fourthCell.Col = 0;
            Cell fifthCell=new Cell();
            fifthCell.Content = 5;
            fifthCell.Row = 1;
            fifthCell.Col = 1;
            Cell sixthCell=new Cell();
            sixthCell.Content = 6;
            sixthCell.Row = 1;
            sixthCell.Col = 2;
            Cell seventhCell=new Cell();
            seventhCell.Content = 7;
            seventhCell.Row = 2;
            seventhCell.Col = 0;
            Cell eigthCell=new Cell();
            eigthCell.Content = 8;
            eigthCell.Row = 2;
            eigthCell.Col = 1;
            Cell ninthCell=new Cell();
            ninthCell.Content = 0;
            ninthCell.Row = 2;
            ninthCell.Col = 2;
            expectedBody.Add(firstCell);
            expectedBody.Add(secondCell);
            expectedBody.Add(thirdCell);
            expectedBody.Add(fourthCell);
            expectedBody.Add(fifthCell);
            expectedBody.Add(sixthCell);
            expectedBody.Add(seventhCell);
            expectedBody.Add(eigthCell);
            expectedBody.Add(ninthCell);
            Assert.AreEqual(expectedBody,testField.Body);
        }
    }
}
