namespace GameFifteenVersionSeven
{
    using System;

    /// <summary>
    /// This is class with puzzle shuffle methods.
    /// </summary>
    public class RandomShuffle : ShuffleStrategy // Strategy design pattern.
    {
        private const int NumberOfShuffling = 5;

        /// <summary>
        /// This method shuffle all cells in PuzzleField object.
        /// </summary>
        /// <param name="puzzleField">This is the field for shuffle.</param>
        public override void Shuffle(PuzzleFieldManager manager)
        {
            PuzzleField puzzleField = manager.Field;
            Random randomGenerator = new Random();

            for (int i = 0; i < NumberOfShuffling; i++)
            {
                int randomNumber = randomGenerator.Next(3);
                Cell selectedCell = new Cell();

                if (randomNumber == 0)
                {
                    selectedCell.Col = puzzleField.EmptyCell.Col;
                    if (puzzleField.EmptyCell.Row > 0)
                    {
                        selectedCell.Row = puzzleField.EmptyCell.Row - 1;
                        manager.RearrangePuzzleField(selectedCell);
                    }
                    else
                    {
                        randomNumber++;
                    }
                }

                if (randomNumber == 1)
                {
                    selectedCell.Row = puzzleField.EmptyCell.Row;
                    if (puzzleField.EmptyCell.Col < puzzleField.MatrixSize - 1)
                    {
                        selectedCell.Col = puzzleField.EmptyCell.Col + 1;
                        manager.RearrangePuzzleField(selectedCell);
                    }
                    else
                    {
                        randomNumber++;
                    }
                }

                if (randomNumber == 2)
                {
                    selectedCell.Col = puzzleField.EmptyCell.Col;
                    if (puzzleField.EmptyCell.Row < puzzleField.MatrixSize - 1)
                    {
                        selectedCell.Row = puzzleField.EmptyCell.Row + 1;
                        manager.RearrangePuzzleField(selectedCell);
                    }
                    else
                    {
                        randomNumber++;
                    }
                }

                if (randomNumber == 3)
                {
                    selectedCell.Row = puzzleField.EmptyCell.Row;
                    if (puzzleField.EmptyCell.Col > 0)
                    {
                        selectedCell.Col = puzzleField.EmptyCell.Col - 1;
                        manager.RearrangePuzzleField(selectedCell);
                    }
                }
            }
        }
    }
}