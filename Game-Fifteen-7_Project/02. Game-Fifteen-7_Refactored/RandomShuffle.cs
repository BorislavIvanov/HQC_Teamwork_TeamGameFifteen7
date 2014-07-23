namespace GameFifteenVersionSeven
{
    using System;

    /// <summary>
    /// This is class with puzzle shuffle methods.
    /// </summary>
    public class RandomShuffle : ShuffleStrategy // Strategy design pattern.
    {
        /// <summary>
        /// This method shuffle all cells in PuzzleField object.
        /// </summary>
        /// <param name="puzzleField">This is the field for shuffle.</param>
        public override void Shuffle(PuzzleField puzzleField)
        {
            Random randomGenerator = new Random();

            for (int i = 0; i < 1000; i++)
            {
                int randomNumber = randomGenerator.Next(3);
                Cell selectedCell = new Cell();

                if (randomNumber == 0)
                {
                    selectedCell.Row = puzzleField.EmptyCell.Row - 1;
                    selectedCell.Col = puzzleField.EmptyCell.Col;

                    if (this.CheckCellPosition(selectedCell, puzzleField))
                    {
                        this.RearrangePuzzleField(puzzleField, selectedCell);
                    }
                    else
                    {
                        randomNumber++;
                    }
                }

                if (randomNumber == 1)
                {
                    selectedCell.Row = puzzleField.EmptyCell.Row;
                    selectedCell.Col = puzzleField.EmptyCell.Col + 1;

                    if (this.CheckCellPosition(selectedCell, puzzleField))
                    {
                        this.RearrangePuzzleField(puzzleField, selectedCell);
                    }
                    else
                    {
                        randomNumber++;
                    }
                }

                if (randomNumber == 2)
                {
                    selectedCell.Row = puzzleField.EmptyCell.Row + 1;
                    selectedCell.Col = puzzleField.EmptyCell.Col;

                    if (this.CheckCellPosition(selectedCell, puzzleField))
                    {
                        this.RearrangePuzzleField(puzzleField, selectedCell);
                    }
                    else
                    {
                        randomNumber++;
                    }
                }

                if (randomNumber == 3)
                {
                    selectedCell.Row = puzzleField.EmptyCell.Row;
                    selectedCell.Col = puzzleField.EmptyCell.Col - 1;

                    if (this.CheckCellPosition(selectedCell, puzzleField))
                    {
                        this.RearrangePuzzleField(puzzleField, selectedCell);
                    }
                }
            }
        }

        /// <summary>
        /// This method change the positions of two cells.
        /// </summary>
        /// <param name="puzzleField">The field with cells.</param>
        /// <param name="selectedCell">Cell for position change.</param>
        private void RearrangePuzzleField(PuzzleField puzzleField, Cell selectedCell)
        {
            int selectedCellFieldIndex = selectedCell.Col + selectedCell.Row * puzzleField.MatrixSize;
            selectedCell = puzzleField.Body[selectedCellFieldIndex];

            int emptySpaceCell = puzzleField.EmptyCell.Content;
            puzzleField.EmptyCell.Content = selectedCell.Content;
            selectedCell.Content = emptySpaceCell;
        }

        /// <summary>
        /// This method validate the cell of FieldPuzzle.
        /// </summary>
        /// <param name="selectedCell">The selected cell.</param>
        /// <param name="puzzleField">The field with cells.</param>
        /// <returns>Returns "true" i the cell is in game field.</returns>
        private bool CheckCellPosition(Cell selectedCell, PuzzleField puzzleField)
        {
            return selectedCell.Row >= 0 && selectedCell.Row < puzzleField.MatrixSize && selectedCell.Col >= 0 && selectedCell.Col < puzzleField.MatrixSize;
        }
    }
}