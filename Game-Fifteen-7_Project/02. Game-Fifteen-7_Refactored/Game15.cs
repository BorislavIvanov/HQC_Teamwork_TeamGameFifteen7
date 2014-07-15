//namespace Game15
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Text;

//    class Game15
//    {
//        private static readonly Random randomGenerator = new Random();
//        static int[,] puzzleField = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
//        static int rowPositionOfEmptySpace = 3;
//        static int colPositionOfEmptySpace = 3;
//        static bool gameContinues = true;
//        static int countOfTotalMoves;
//        static List<Tuple<string, int>> topPlayersScores = new List<Tuple<string, int>>();
//        static int countOfTopPlayers = topPlayersScores.Count;

//        static bool CheckIsTheMoveAreLegal(int row, int col)//
//        {
//            if ((row == rowPositionOfEmptySpace - 1 || row == rowPositionOfEmptySpace + 1) && col == colPositionOfEmptySpace)
//            {
//                return true;
//            }

//            if ((row == rowPositionOfEmptySpace) && (col == colPositionOfEmptySpace - 1 || col == colPositionOfEmptySpace + 1))
//            {
//                return true;
//            }

//            return false;
//        }

//        static void MoveTheNumberOfField(int number)//
//        {
//            int rowPositionOfTheSelectedNumber = rowPositionOfEmptySpace;
//            int colPositionOfTheSelectedNumber = colPositionOfEmptySpace;
//            bool positionOfNumberIsFound = true;

//            for (int row = 0; row < 4; row++)
//            {
//                if (positionOfNumberIsFound)
//                {
//                    for (int col = 0; col < 4; col++)
//                    {
//                        if (puzzleField[row, col] == number)
//                        {
//                            rowPositionOfTheSelectedNumber = row;
//                            colPositionOfTheSelectedNumber = col;
//                            positionOfNumberIsFound = false;
//                            break;
//                        }
//                    }
//                }
//                else
//                {
//                    break;
//                }
//            }

//            bool isTheMoveAreLegal = CheckIsTheMoveAreLegal(rowPositionOfTheSelectedNumber, colPositionOfTheSelectedNumber);

//            if (!isTheMoveAreLegal)
//            {
//                Console.WriteLine("Illegal move!");
//            }
//            else
//            {
//                int currentlySelectedCell = puzzleField[rowPositionOfTheSelectedNumber, colPositionOfTheSelectedNumber];
//                puzzleField[rowPositionOfTheSelectedNumber, colPositionOfTheSelectedNumber] =
//                    puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace];
//                puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace] = currentlySelectedCell;
//                rowPositionOfEmptySpace = rowPositionOfTheSelectedNumber;
//                colPositionOfEmptySpace = colPositionOfTheSelectedNumber;
//                countOfTotalMoves++;

//                PrintTheGameField();
//            }
//        }

//        static bool IsPuzzleSolved()//
//        {
//            if (puzzleField[3, 3] == 0)
//            {
//                int correctNumber = 1;

//                for (int row = 0; row < 4; row++)
//                {
//                    for (int col = 0; col < 4; col++)
//                    {
//                        if (correctNumber <= 15)
//                        {
//                            if (puzzleField[row, col] == correctNumber)
//                            {
//                                correctNumber++;
//                            }
//                            else
//                            {
//                                return false;
//                            }
//                        }
//                        else
//                        {
//                            return true;
//                        }
//                    }
//                }
//            }

//            return false;
//        }

//        static void StartNewGame()//
//        {
//            countOfTotalMoves = 0;

//            ShuffleThePuzzleField();

//            PrintTheGameField();
//        }

//        private static void ShuffleThePuzzleField()//
//        {
//            for (int i = 0; i < 1; i++)
//            {
//                int randomNumber = randomGenerator.Next(3);

//                if (randomNumber == 0)
//                {
//                    int rowOfSelectedCell = rowPositionOfEmptySpace - 1;
//                    int colOfSelectedCell = colPositionOfEmptySpace;

//                    if (rowOfSelectedCell >= 0 && rowOfSelectedCell <= 3 && colOfSelectedCell >= 0 && colOfSelectedCell <= 3)
//                    {
//                        int emptySpaceCell = puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace];
//                        puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace] =
//                            puzzleField[rowOfSelectedCell, colOfSelectedCell];
//                        puzzleField[rowOfSelectedCell, colOfSelectedCell] = emptySpaceCell;
//                        rowPositionOfEmptySpace = rowOfSelectedCell;
//                        colPositionOfEmptySpace = colOfSelectedCell;
//                    }
//                    else
//                    {
//                        randomNumber++;
//                        i--;
//                    }
//                }

//                if (randomNumber == 1)
//                {
//                    int rowOfSelectedCell = rowPositionOfEmptySpace;
//                    int colOfSelectedCell = colPositionOfEmptySpace + 1;

//                    if (rowOfSelectedCell >= 0 && rowOfSelectedCell <= 3 && colOfSelectedCell >= 0 && colOfSelectedCell <= 3)
//                    {
//                        int emptySpaceCell = puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace];
//                        puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace] =
//                            puzzleField[rowOfSelectedCell, colOfSelectedCell];
//                        puzzleField[rowOfSelectedCell, colOfSelectedCell] = emptySpaceCell;
//                        rowPositionOfEmptySpace = rowOfSelectedCell;
//                        colPositionOfEmptySpace = colOfSelectedCell;
//                    }
//                    else
//                    {
//                        randomNumber++;
//                        i--;
//                    }
//                }

//                if (randomNumber == 2)
//                {
//                    int rowOfSelectedCell = rowPositionOfEmptySpace + 1;
//                    int colOfSelectedCell = colPositionOfEmptySpace;

//                    if (rowOfSelectedCell >= 0 && rowOfSelectedCell <= 3 && colOfSelectedCell >= 0 && colOfSelectedCell <= 3)
//                    {
//                        int emptySpaceCell = puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace];
//                        puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace] =
//                            puzzleField[rowOfSelectedCell, colOfSelectedCell];
//                        puzzleField[rowOfSelectedCell, colOfSelectedCell] = emptySpaceCell;
//                        rowPositionOfEmptySpace = rowOfSelectedCell;
//                        colPositionOfEmptySpace = colOfSelectedCell;
//                    }
//                    else
//                    {
//                        randomNumber++;
//                        i--;
//                    }
//                }

//                if (randomNumber == 3)
//                {
//                    int rowOfSelectedCell = rowPositionOfEmptySpace;
//                    int colOfSelectedCell = colPositionOfEmptySpace - 1;

//                    if (rowOfSelectedCell >= 0 && rowOfSelectedCell <= 3 && colOfSelectedCell >= 0 && colOfSelectedCell <= 3)
//                    {
//                        int emptySpaceCell = puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace];
//                        puzzleField[rowPositionOfEmptySpace, colPositionOfEmptySpace] =
//                            puzzleField[rowOfSelectedCell, colOfSelectedCell];
//                        puzzleField[rowOfSelectedCell, colOfSelectedCell] = emptySpaceCell;
//                        rowPositionOfEmptySpace = rowOfSelectedCell;
//                        colPositionOfEmptySpace = colOfSelectedCell;
//                    }
//                    else
//                    {
//                        i--;
//                    }
//                }
//            }
//        }

//        private static void PrintScoreboard()//
//        {
//            Console.WriteLine("\nScoreboard:");

//            if (countOfTopPlayers != 0)
//            {
//                for (int i = 0; i <= countOfTopPlayers - 1; i++)
//                {
//                    Console.WriteLine("{0} by {1}", topPlayersScores[i].Item1, topPlayersScores[i].Item2);
//                }
//            }
//            else
//            {
//                Console.WriteLine("Empty Scoreboard! :)");
//            }
//        }

//        private static void PrintTheGameField()//
//        {
//            Console.WriteLine(" -------------");

//            for (int row = 0; row < 4; row++)
//            {
//                Console.Write("| ");

//                for (int col = 0; col < 4; col++)
//                {
//                    if (puzzleField[row, col] >= 10)
//                    {
//                        Console.Write("{0} ", puzzleField[row, col]);
//                    }
//                    else if (puzzleField[row, col] == 0)
//                    {
//                        Console.Write("   ");
//                    }
//                    else
//                    {
//                        Console.Write(" {0} ", puzzleField[row, col]);
//                    }
//                }

//                Console.WriteLine("|");
//            }

//            Console.WriteLine(" -------------");
//        }

//        private static void PrintWelcomeMessage()//
//        {
//            Console.WriteLine("Welcome to the game “15”.\nPlease try to arrange the numbers sequentially.\nUse 'top' to view the top scoreboard,\n'restart' to start a new game\nand 'exit' to quit the game.\n");
//            Console.WriteLine(" -------------");
//        }

//        private static void AddNewTopPlayer(string inputOfPlayerName)
//        {
//            topPlayersScores.Add(new Tuple<string, int>(inputOfPlayerName, countOfTotalMoves));
//            countOfTopPlayers = topPlayersScores.Count;
//            topPlayersScores.Sort((a, b) => a.Item2.CompareTo(b.Item2));

//            if (countOfTopPlayers == 4)
//            {
//                topPlayersScores.RemoveAt(3);
//                countOfTopPlayers = topPlayersScores.Count;
//            }
//        }

//        private static void PrintTheGameIsWon()//
//        {
//            Console.WriteLine("Congratulations! You won the game in {0} moves.", countOfTotalMoves);

//            Console.Write("Please enter your name for the top scoreboard: ");
//        }

//        private static void ExecuteTheGameCommand(string inputCommand, int selectedNumber, bool inputIsANumber)//
//        {
//            if (inputIsANumber)
//            {
//                if (selectedNumber >= 1 && selectedNumber <= 15)
//                {
//                    MoveTheNumberOfField(selectedNumber);
//                }
//                else
//                {
//                    Console.WriteLine("Illegal move!");
//                }
//            }
//            else
//            {
//                if (inputCommand == "exit")
//                {
//                    Console.WriteLine("Good bye!");
//                    gameContinues = false;
//                    //break;
//                }
//                else
//                {
//                    if (inputCommand == "restart")
//                    {
//                        StartNewGame();
//                    }
//                    else
//                    {
//                        if (inputCommand == "top")
//                        {
//                            PrintScoreboard();

//                            Console.WriteLine();
//                        }
//                        else
//                        {
//                            Console.WriteLine("Illegal command!");
//                        }
//                    }
//                }
//            }
//        }

//        public static void Main(string[] args)//
//        {
//            while (gameContinues)
//            {
//                countOfTotalMoves = 0;

//                ShuffleThePuzzleField();

//                PrintWelcomeMessage();

//                PrintTheGameField();

//                bool isGameWon = IsPuzzleSolved();

//                while (!isGameWon)
//                {
//                    Console.Write("Enter a number to move: ");
//                    string inputCommand = Console.ReadLine();
//                    int selectedNumber;
//                    bool inputIsANumber = int.TryParse(inputCommand, out selectedNumber);

//                    ExecuteTheGameCommand(inputCommand, selectedNumber, inputIsANumber);

//                    if (!gameContinues)
//                    {
//                        break;
//                    }

//                    isGameWon = IsPuzzleSolved();
//                }

//                if (isGameWon)
//                {
//                    PrintTheGameIsWon();

//                    string inputOfPlayerName = Console.ReadLine();

//                    AddNewTopPlayer(inputOfPlayerName);

//                    PrintScoreboard();

//                    Console.WriteLine();
//                }
//            }
//        }
//    }
//}