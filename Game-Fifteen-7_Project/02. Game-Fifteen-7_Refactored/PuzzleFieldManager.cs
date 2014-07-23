namespace GameFifteenVersionSeven
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Manager for operations with PuzzleField.
    /// </summary>
    public class PuzzleFieldManager
    {
        /// <summary>
        /// Constructor of PuzzleFieldManager.
        /// </summary>
        /// <param name="field">The Current PuzzleField for manage.</param>
        public PuzzleFieldManager(PuzzleField field)
        {
            this.Field = field;
        }

        /// <summary>
        /// Gets or sets the current Field.
        /// </summary>
        public PuzzleField Field { get; set; }

        /// <summary>
        /// This method rearrange the puzzle field by chosen cell.
        /// </summary>
        /// <param name="selectedCell">The cell for move.</param>
        public void RearrangePuzzleField(Cell selectedCell)
        {
            int selectedCellFieldIndex = selectedCell.Col + (selectedCell.Row * this.Field.MatrixSize);
            selectedCell = this.Field.Body[selectedCellFieldIndex];

            int emptySpaceCell = this.Field.EmptyCell.Content;
            this.Field.EmptyCell.Content = selectedCell.Content;
            selectedCell.Content = emptySpaceCell;
        }

        /// <summary>
        /// This method find the cell from the PuzzleField by his content
        /// </summary>
        /// <param name="cellContent">Content of the seeked cell.</param>
        /// <returns>Returns object of the seeked cell.</returns>
        public Cell FindCellByItsContent(int cellContent)
        {
            Cell searchedCell = this.Field.Body.FirstOrDefault(c => c.Content == cellContent);
            return searchedCell;
        }
    }
}
