using System;

namespace GameFifteenVersionSeven
{
    public class RandomShuffle : ShuffleStrategy
    {
        public override void Shuffle(PuzzleField puzzleField)
        {
            //int rowPositionOfEmptySpace = puzzleField.EmptyCell.Row;
            //int colPositionOfEmptySpace = puzzleField.EmptyCell.Col;
            Random randomGenerator = new Random();

            for (int i = 0; i < 1000; i++)
            {
                int randomNumber = randomGenerator.Next(3);
                Cell selectedCell = new Cell();

                if (randomNumber == 0)
                {
                    selectedCell.Row = puzzleField.EmptyCell.Row - 1;
                    selectedCell.Col = puzzleField.EmptyCell.Col;

                    if (CheckCellPosition(selectedCell, puzzleField))
                    {
                        RearrangePuzzleField(puzzleField, selectedCell);
                    }
                    else
                    {
                        randomNumber++;
                        i--;
                    }
                }

                if (randomNumber == 1)
                {
                    selectedCell.Row = puzzleField.EmptyCell.Row;
                    selectedCell.Col = puzzleField.EmptyCell.Col + 1;

                    if (CheckCellPosition(selectedCell, puzzleField))
                    {
                        RearrangePuzzleField(puzzleField, selectedCell);
                    }
                    else
                    {
                        randomNumber++;
                        i--;
                    }
                }

                if (randomNumber == 2)
                {
                    selectedCell.Row = puzzleField.EmptyCell.Row + 1;
                    selectedCell.Col = puzzleField.EmptyCell.Col;

                    if (CheckCellPosition(selectedCell, puzzleField))
                    {
                        RearrangePuzzleField(puzzleField, selectedCell);
                    }
                    else
                    {
                        randomNumber++;
                        i--;
                    }
                }

                if (randomNumber == 3)
                {
                    selectedCell.Row = puzzleField.EmptyCell.Row;
                    selectedCell.Col = puzzleField.EmptyCell.Col-1;

                    if (CheckCellPosition(selectedCell, puzzleField))
                    {
                        RearrangePuzzleField(puzzleField, selectedCell);
                    }
                    else
                    {
                        i--;
                    }
                }
            }
        }

        private void RearrangePuzzleField(PuzzleField puzzleField, Cell selectedCell)
        {
            Cell emptySpaceCell = puzzleField.EmptyCell;
            puzzleField.EmptyCell = selectedCell;
            selectedCell = emptySpaceCell;
            puzzleField.EmptyCell.Row = selectedCell.Row;
            puzzleField.EmptyCell.Col = selectedCell.Col;
        }

        private bool CheckCellPosition(Cell selectedCell, PuzzleField puzzleField)
        {
            return selectedCell.Row >= 0 && selectedCell.Row <= puzzleField.MatrixSize && selectedCell.Col >= 0 && selectedCell.Col <= puzzleField.MatrixSize;
        }
    }
}
