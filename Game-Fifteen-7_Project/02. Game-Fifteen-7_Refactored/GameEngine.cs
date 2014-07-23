﻿namespace GameFifteenVersionSeven
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This method contains the core game logic.
    /// </summary>
    public class GameEngine // Facade design pattern.
    {
        private const int MatrixSize = 4;
        private const int InitialValue = 0;

        /// <summary>
        /// Array of top players.
        /// </summary>
        private static List<Tuple<string, int>> topPlayersScores = new List<Tuple<string, int>>();

        /// <summary>
        /// Initialize a new instance of the GameEngine class
        /// </summary>
        public GameEngine()
        {
            this.PuzzleField = new PuzzleField(MatrixSize, InitialValue);
            this.CommandManager = new CommandManager();
            this.ShuffleStrategy = new RandomShuffle();
            this.IsGameOver = false;
        }

        public CommandManager CommandManager { get; set; }

        public ShuffleStrategy ShuffleStrategy { get; set; }

        public PuzzleField PuzzleField { get; set; }

        public bool IsGameOver { get; set; }

        public int CountTotalMoves { get; set; }

        // Command design pattern.
        public ICommand TopCommand { get; set; }

        public ICommand ExitCommand { get; set; }

        public ICommand RestartCommand { get; set; }

        /// <summary>
        /// This method start the game.
        /// </summary>
        public void StartTheGame()
        {
            // Command design pattern.
            this.DefineCommands(topPlayersScores);

            while (!this.IsGameOver)
            {
                this.CountTotalMoves = 0;

                this.ShuffleStrategy.Shuffle(this.PuzzleField);

                ConsolePrinter.PrintWelcomeMessage();

                ConsolePrinter.PrintTheGameField(this.PuzzleField);

                bool isGameWon = this.IsPuzzleSolved();

                while (!isGameWon)
                {
                    Console.Write("Enter a number to move: ");
                    string inputCommand = Console.ReadLine();

                    this.ExecuteTheGameCommand(inputCommand);

                    if (this.IsGameOver)
                    {
                        break;
                    }

                    isGameWon = this.IsPuzzleSolved();
                }

                if (isGameWon)
                {
                    ConsolePrinter.PrintTheGameIsWon(this.CountTotalMoves);

                    string inputOfPlayerName = Console.ReadLine();

                    this.AddNewTopPlayer(inputOfPlayerName);

                    ConsolePrinter.PrintScoreboard(topPlayersScores);

                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// This method make a restart of the game.
        /// </summary>
        public void StartNewGame()
        {
            this.CountTotalMoves = 0;

            this.ShuffleStrategy.Shuffle(this.PuzzleField);

            ConsolePrinter.PrintTheGameField(this.PuzzleField);
        }

        private void DefineCommands(List<Tuple<string, int>> topPlayersScores)
        {
            this.TopCommand = new TopCommand(topPlayersScores);
            this.ExitCommand = new ExitCommand(this);
            this.RestartCommand = new RestartCommand(this);
        }

        /// <summary>
        /// This method checks if a number from a cell can be moved.
        /// </summary>
        /// <param name="row">Row of game field.</param>
        /// <param name="col">Column of game field.</param>
        /// <returns>Returns "true" if the move are legal or "false" if the move are illegal.</returns>
        private bool CheckIsTheMoveAreLegal(Cell cell)
        {
            if ((cell.Row == this.PuzzleField.EmptyCell.Row - 1 || cell.Row == this.PuzzleField.EmptyCell.Row + 1)
                && cell.Col == this.PuzzleField.EmptyCell.Col)
            {
                return true;
            }

            if ((cell.Row == this.PuzzleField.EmptyCell.Row) && (cell.Col == this.PuzzleField.EmptyCell.Col - 1
                || cell.Col == this.PuzzleField.EmptyCell.Col + 1))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// This method checks if the selected number from players is valid for relocation and moving it if possible.
        /// </summary>
        /// <param name="number">Selected number of field from player.</param>
        private void MoveTheNumberOfField(int number)
        {
            Cell selectedCell = new Cell();

            for (int i = 0; i < this.PuzzleField.Body.Count; i++)
            {
                Cell currentCell = this.PuzzleField.Body[i];
                if (currentCell.Content == number)
                {
                    selectedCell = currentCell;
                    break;
                }
            }

            bool isTheMoveAreLegal = this.CheckIsTheMoveAreLegal(selectedCell);

            if (!isTheMoveAreLegal)
            {
                Console.WriteLine("Illegal move!");
            }
            else
            {
                int cellForChange = selectedCell.Content;
                selectedCell.Content = this.PuzzleField.EmptyCell.Content;
                this.PuzzleField.EmptyCell.Content = cellForChange;
                this.CountTotalMoves++;

                ConsolePrinter.PrintTheGameField(this.PuzzleField);
            }
        }

        /// <summary>
        /// This method gets input command from player and execute it.
        /// </summary>
        /// <param name="inputCommand">Input command from player.</param>
        private void ExecuteTheGameCommand(string inputCommand)
        {
            int selectedNumber;
            bool inputIsANumber = int.TryParse(inputCommand, out selectedNumber);

            if (inputIsANumber)
            {
                if (selectedNumber >= (this.PuzzleField.InitialValue + 1) && selectedNumber <= (this.PuzzleField.MatrixSize * this.PuzzleField.MatrixSize))
                {
                    this.MoveTheNumberOfField(selectedNumber);
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
                    this.CommandManager.Proceed(this.ExitCommand);
                }
                else
                {
                    if (inputCommand == "restart")
                    {
                        this.CommandManager.Proceed(this.RestartCommand);
                    }
                    else
                    {
                        if (inputCommand == "top")
                        {
                            this.CommandManager.Proceed(this.TopCommand);
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
        private bool IsPuzzleSolved()
        {
            for (int i = 0; i < this.PuzzleField.Body.Count - 1; i++)
            {
                Cell currentCell = this.PuzzleField.Body[i];
                if (currentCell.Content != i + 1)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// This method add new top player in top players rank list at end of the game.
        /// </summary>
        /// <param name="inputOfPlayerName">Name of the player.</param>
        private void AddNewTopPlayer(string inputOfPlayerName)
        {
            topPlayersScores.Add(new Tuple<string, int>(inputOfPlayerName, this.CountTotalMoves));
            topPlayersScores.Sort((a, b) => a.Item2.CompareTo(b.Item2));

            if (topPlayersScores.Count == 4)
            {
                topPlayersScores.RemoveAt(3);
            }
        }
    }
}