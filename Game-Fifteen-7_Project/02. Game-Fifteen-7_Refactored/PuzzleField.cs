namespace GameFifteenVersionSeven
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// PuzzleField class.
    /// </summary>
    public class PuzzleField //implementation of Singleton design pattern
    {
        private int matrixSize;
        private static PuzzleField instance = null;
        private static Object mutex = new Object();

        /// <summary>
        /// Initializes a new instance of the PuzzleField class.
        /// </summary>
        /// <param name="size">Size of the field.</param>
        /// <param name="initialValue">Initial value of the field.</param>
        public PuzzleField(int size)
        {
            this.MatrixSize = size;
            this.Body = new List<Cell>();
            this.FillPuzzleBody();
        }

        public static PuzzleField GetInstance(int size)  //implementation of Singleton design pattern
        {
            if (instance == null)
            {
                lock (mutex) // lock the object because of possible two threads requests
                {
                    if (instance == null)
                    {
                        instance = new PuzzleField(size);
                    }
                }
            }

            return instance;
        }
        ///// <summary>
        ///// Gets or sets the Initial value of puzzle field.
        ///// </summary>
        //public int InitialValue
        //{
        //    get
        //    {
        //        return this.initialValue;
        //    }

        //    set
        //    {
        //        if (value < 0)
        //        {
        //            throw new ArgumentException("The initial value must be a positive integer");
        //        }

        //        this.initialValue = value;
        //    }
        //}

        /// <summary>
        /// Gets or sets the matrix size of puzzle field.
        /// </summary>
        public int MatrixSize
        {
            get
            {
                return this.matrixSize;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The matrix size must be a positive integer");
                }

                this.matrixSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the elements in puzzle field body.
        /// </summary>
        public List<Cell> Body { get; set; }

        /// <summary>
        /// Gets the empty cell of puzzle field.
        /// </summary>
        public Cell EmptyCell
        {
            get
            {
                return this.FindEmptyCell();
            }

            set
            {
            }
        }

        /// <summary>
        /// This method fill the list of elements in puzzle field.
        /// </summary>
        public void FillPuzzleBody()
        {
            Cell singleCell = new Cell();
            int currentValue = 1;

            for (int row = 0; row < this.MatrixSize; row++)
            {
                for (int col = 0; col < this.MatrixSize; col++)
                {
                    // Prototype design pattern.
                    Cell currentCell = singleCell.Clone() as Cell;

                    if (currentValue == this.MatrixSize * this.MatrixSize)
                    {
                        currentValue = 0;
                    }

                    currentCell.Content = currentValue;
                    currentCell.Row = row;
                    currentCell.Col = col;
                    this.Body.Add(currentCell);
                    currentValue++;
                }
            }
        }

        /// <summary>
        /// This method returns the empty cell from PuzzleField
        /// </summary>
        /// <returns>Returns object of empty cell.</returns>
        private Cell FindEmptyCell()
        {
            Cell searchedCell = new Cell();

            for (int i = 0; i < this.Body.Count; i++)
            {
                searchedCell = this.Body[i];
                if (searchedCell.Content == 0)
                {
                    break;
                }
            }

            return searchedCell;
        }
    }
}