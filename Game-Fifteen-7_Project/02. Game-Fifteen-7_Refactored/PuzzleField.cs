using System.Collections.Generic;

namespace GameFifteenVersionSeven
{
    public class PuzzleField
    {
        public PuzzleField(int size, int initialValue)
        {
            this.MatrixSize = size;
            this.InitialValue = initialValue;
            this.Body=new List<Cell>();
            this.FillPuzzleBody();
        }

        public int InitialValue { get; set; }

        public int MatrixSize { get; set; }

        public List<Cell> Body { get; set; }

        public Cell EmptyCell
        {
            get
            {
                return FindEmptyCell();
            }
            set
            {
                ;
            }
        }

        private Cell FindEmptyCell()
        {
            Cell searchedCell = new Cell();
            for (int i = 0; i < this.Body.Count; i++)
            {
                searchedCell = this.Body[i];
                if (searchedCell.Context == 0)
                {
                    break;
                }
            }
            return searchedCell;
        }

        public void FillPuzzleBody()
        {
            Cell singleCell = new Cell();
            int currentValue = this.InitialValue+1;
            for (int row = 0; row < this.MatrixSize; row++)
            {
                for (int col = 0; col < this.MatrixSize; col++)
                {
                    Cell currentCell = singleCell.Clone() as Cell;
                    if (currentValue==this.MatrixSize*this.MatrixSize)
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
    }
}
