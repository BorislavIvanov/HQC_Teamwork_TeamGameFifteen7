namespace GameFifteenVersionSeven
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// This method contains the core game logic.
    /// </summary>
    internal static class GameEngine
    {
        /// <summary>
        /// Random generator for random field shuffle.
        /// </summary>
        private static readonly Random RandomGenerator = new Random();

        /// <summary>
        /// Game puzzle field.
        /// </summary>
        private static int[,] puzzleField = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };

        /// <summary>
        /// Row position of field empty space.
        /// </summary>
        private static int rowPositionOfEmptySpace = 3;

        /// <summary>
        /// Column position of field empty space.
        /// </summary>
        private static int colPositionOfEmptySpace = 3;

        /// <summary>
        /// Boolean variable for whether the game continues.
        /// </summary>
        private static bool gameContinues = true;

        /// <summary>
        /// Number of moves from player for current game.
        /// </summary>
        private static int countOfTotalMoves;

        /// <summary>
        /// Array of top players.
        /// </summary>
        private static List<Tuple<string, int>> topPlayersScores = new List<Tuple<string, int>>();
        
        /// <summary>
        /// Count of top players.
        /// </summary>
        private static int countOfTopPlayers = topPlayersScores.Count;

        /// <summary>
        /// This method start the game.
        /// </summary>
        public static void StartTheGame()
        {
            while (gameContinues)
            {
                countOfTotalMoves = 0;

                ShuffleThePuzzleField();

                ConsolePrinter.PrintWelcomeMessage();

                ConsolePrinter.PrintTheGameField(puzzleField);

                bool isGameWon = IsPuzzleSolved();

                while (!isGameWon)
                {
                    Console.Write("Enter a number to move: ");
                    string inputCommand = Console.ReadLine();
                    
                    ExecuteTheGameCommand(inputCommand);

                    if (!gameContinues)
                    {
                        break;
                    }

                    isGameWon = IsPuzzleSolved();
                }

                if (isGameWon)
                {
                    ConsolePrinter.PrintTheGameIsWon(countOfTotalMoves);

                    string inputOfPlayerName = Console.ReadLine();

                    AddNewTopPlayer(inputOfPlayerName);

                    ConsolePrinter.PrintScoreboard(countOfTopPlayers, topPlayersScores);

                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// This method make a restart of the game.
        /// </summary>
        private static void StartNewGame()
        {
            countOfTotalMoves = 0;

            ShuffleThePuzzleField();

            ConsolePrinter.PrintTheGameField(puzzleField);
        }

        /// <summary>
        /// This method shuffle all numbers in puzzle field.
        /// </summary>
        private static void ShuffleThePuzzleField()
        {
            for (int i = 0; i < 1000; i++)
            {
                int randomNumber = RandomGenerator.Next(3);

                if (randomNumber == 0)
                {
                    int rowOfSelectedCell = rowPositionOfEmptySpace - 1;
                    int colOfSelectedCell = colPositionOfEmptySpace;

                    if (rowOfSelectedCell >= 0 && rowOfSelectedCell <= 3 && colOfSelectedCell >= 0 && colOfSelectedCell <= 3)
                    {
                        int emptySpaceCell = puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace];
                        puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace] =
                            puzzleField[rowOfSelectedCell, colOfSelectedCell];
                        puzzleField[rowOfSelectedCell, colOfSelectedCell] = emptySpaceCell;
                        rowPositionOfEmptySpace = rowOfSelectedCell;
                        colPositionOfEmptySpace = colOfSelectedCell;
                    }
                    else
                    {
                        randomNumber++;
                        i--;
                    }
                }

                if (randomNumber == 1)
                {
                    int rowOfSelectedCell = rowPositionOfEmptySpace;
                    int colOfSelectedCell = colPositionOfEmptySpace + 1;

                    if (rowOfSelectedCell >= 0 && rowOfSelectedCell <= 3 && colOfSelectedCell >= 0 && colOfSelectedCell <= 3)
                    {
                        int emptySpaceCell = puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace];
                        puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace] =
                            puzzleField[rowOfSelectedCell, colOfSelectedCell];
                        puzzleField[rowOfSelectedCell, colOfSelectedCell] = emptySpaceCell;
                        rowPositionOfEmptySpace = rowOfSelectedCell;
                        colPositionOfEmptySpace = colOfSelectedCell;
                    }
                    else
                    {
                        randomNumber++;
                        i--;
                    }
                }

                if (randomNumber == 2)
                {
                    int rowOfSelectedCell = rowPositionOfEmptySpace + 1;
                    int colOfSelectedCell = colPositionOfEmptySpace;

                    if (rowOfSelectedCell >= 0 && rowOfSelectedCell <= 3 && colOfSelectedCell >= 0 && colOfSelectedCell <= 3)
                    {
                        int emptySpaceCell = puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace];
                        puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace] =
                            puzzleField[rowOfSelectedCell, colOfSelectedCell];
                        puzzleField[rowOfSelectedCell, colOfSelectedCell] = emptySpaceCell;
                        rowPositionOfEmptySpace = rowOfSelectedCell;
                        colPositionOfEmptySpace = colOfSelectedCell;
                    }
                    else
                    {
                        randomNumber++;
                        i--;
                    }
                }

                if (randomNumber == 3)
                {
                    int rowOfSelectedCell = rowPositionOfEmptySpace;
                    int colOfSelectedCell = colPositionOfEmptySpace - 1;

                    if (rowOfSelectedCell >= 0 && rowOfSelectedCell <= 3 && colOfSelectedCell >= 0 && colOfSelectedCell <= 3)
                    {
                        int emptySpaceCell = puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace];
                        puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace] =
                            puzzleField[rowOfSelectedCell, colOfSelectedCell];
                        puzzleField[rowOfSelectedCell, colOfSelectedCell] = emptySpaceCell;
                        rowPositionOfEmptySpace = rowOfSelectedCell;
                        colPositionOfEmptySpace = colOfSelectedCell;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
        }

        /// <summary>
        /// This method checks if a number from a cell can be moved.
        /// </summary>
        /// <param name="row">Row of game field.</param>
        /// <param name="col">Column of game field.</param>
        /// <returns>Returns "true" if the move are legal or "false" if the move are illegal.</returns>
        private static bool CheckIsTheMoveAreLegal(int row, int col)
        {
            if ((row == rowPositionOfEmptySpace - 1 || row == rowPositionOfEmptySpace + 1) && col == colPositionOfEmptySpace)
            {
                return true;
            }

            if ((row == rowPositionOfEmptySpace) && (col == colPositionOfEmptySpace - 1 || col == colPositionOfEmptySpace + 1))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// This method checks if the selected number from players is valid for relocation and moving it if possible.
        /// </summary>
        /// <param name="number">Selected number of field from player.</param>
        private static void MoveTheNumberOfField(int number)
        {
            int rowPositionOfTheSelectedNumber = rowPositionOfEmptySpace;
            int colPositionOfTheSelectedNumber = colPositionOfEmptySpace;
            bool positionOfNumberIsFound = true;

            for (int row = 0; row < 4; row++)
            {
                if (positionOfNumberIsFound)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        if (puzzleField[row, col] == number)
                        {
                            rowPositionOfTheSelectedNumber = row;
                            colPositionOfTheSelectedNumber = col;
                            positionOfNumberIsFound = false;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            bool isTheMoveAreLegal = CheckIsTheMoveAreLegal(rowPositionOfTheSelectedNumber, colPositionOfTheSelectedNumber);

            if (!isTheMoveAreLegal)
            {
                Console.WriteLine("Illegal move!");
            }
            else
            {
                int currentlySelectedCell = puzzleField[rowPositionOfTheSelectedNumber, colPositionOfTheSelectedNumber];
                puzzleField[rowPositionOfTheSelectedNumber, colPositionOfTheSelectedNumber] =
                    puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace];
                puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace] = currentlySelectedCell;
                rowPositionOfEmptySpace = rowPositionOfTheSelectedNumber;
                colPositionOfEmptySpace = colPositionOfTheSelectedNumber;
                countOfTotalMoves++;

                ConsolePrinter.PrintTheGameField(puzzleField);
            }
        }

        /// <summary>
        /// This method gets input command from player and execute it.
        /// </summary>
        /// <param name="inputCommand">Input command from player.</param>
        private static void ExecuteTheGameCommand(string inputCommand)
        {
            int selectedNumber;
            bool inputIsANumber = int.TryParse(inputCommand, out selectedNumber);

            if (inputIsANumber)
            {
                if (selectedNumber >= 1 && selectedNumber <= 15)
                {
                    MoveTheNumberOfField(selectedNumber);
                }
                else
                {
                    Console.WriteLine("Illegal move!");
                }
            }
            else
            {
                if (inputCommand == "exit")
                {
                    Console.WriteLine("Good bye!");
                    gameContinues = false;
                }
                else
                {
                    if (inputCommand == "restart")
                    {
                        StartNewGame();
                    }
                    else
                    {
                        if (inputCommand == "top")
                        {
                            ConsolePrinter.PrintScoreboard(countOfTopPlayers, topPlayersScores);

                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Illegal command!");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method check that the puzzle is solved correctly.
        /// </summary>
        /// <returns>Returns "true" if the puzzle is correctly solved or "false" if the puzzle is not correctly solved.</returns>
        private static bool IsPuzzleSolved()
        {
            if (puzzleField[3, 3] == 0)
            {
                int correctNumber = 1;

                for (int row = 0; row < 4; row++)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        if (correctNumber <= 15)
                        {
                            if (puzzleField[row, col] == correctNumber)
                            {
                                correctNumber++;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// This method add new top player in top players rank list at end of the game.
        /// </summary>
        /// <param name="inputOfPlayerName">Name of the player.</param>
        private static void AddNewTopPlayer(string inputOfPlayerName)
        {
            topPlayersScores.Add(new Tuple<string, int>(inputOfPlayerName, countOfTotalMoves));
            countOfTopPlayers = topPlayersScores.Count;
            topPlayersScores.Sort((a, b) => a.Item2.CompareTo(b.Item2));

            if (countOfTopPlayers == 4)
            {
                topPlayersScores.RemoveAt(3);
                countOfTopPlayers = topPlayersScores.Count;
            }
        }
    }
}
