namespace GameFifteenVersionSeven
{
    using System.Collections.Generic;

    /// <summary>
    /// PuzzleField class.
    /// </summary>
    public class PuzzleField
    {
        /// <summary>
        /// Initializes a new instance of the PuzzleField class.
        /// </summary>
        /// <param name="size">Size of the field.</param>
        /// <param name="initialValue">Initial value of the field.</param>
        public PuzzleField(int size, int initialValue)
        {
            this.MatrixSize = size;
            this.InitialValue = initialValue;
            this.Body = new List<Cell>();
            this.FillPuzzleBody();
        }

        /// <summary>
        /// Gets or sets the Initial value of puzzle field.
        /// </summary>
        public int InitialValue { get; set; }

        /// <summary>
        /// Gets or sets the matrix size of puzzle field.
        /// </summary>
        public int MatrixSize { get; set; }

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

            private set
            {
            }
        }

        /// <summary>
        /// This method fill the list of elements in puzzle field.
        /// </summary>
        public void FillPuzzleBody()
        {
            Cell singleCell = new Cell();
            int currentValue = this.InitialValue + 1;

            for (int row = 0; row < this.MatrixSize; row++)
            {
                for (int col = 0; col < this.MatrixSize; col++)
                {
                    // Protoype design pattern.
                    Cell currentCell = singleCell.Clone() as Cell;

                    if (currentValue == this.MatrixSize * this.MatrixSize)
                    {
                        currentValue = 0;
                    }

                    currentCell.Context = currentValue;
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
                if (searchedCell.Context == this.InitialValue)
                {
                    break;
                }
            }

            return searchedCell;
        }
    }
}