using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteenVersionSeven
{
    public class PuzzleFieldManager //to manage puzzle field
    {
        public PuzzleFieldManager(PuzzleField field)
        {
            this.Field = field;
        }

        public PuzzleField Field { get; set; }

        public void RearrangePuzzleField(Cell selectedCell)
        {
            int selectedCellFieldIndex = selectedCell.Col + (selectedCell.Row * this.Field.MatrixSize);
            selectedCell = this.Field.Body[selectedCellFieldIndex];

            int emptySpaceCell = this.Field.EmptyCell.Content;
            this.Field.EmptyCell.Content = selectedCell.Content;
            selectedCell.Content = emptySpaceCell;
        }

        public Cell FindCellByItsContent(int cellContent)
        {
            Cell searchedCell = this.Field.Body.FirstOrDefault(c => c.Content == cellContent);
            return searchedCell;
        }
    }
}
