namespace GameFifteenVersionSeven
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class contains methods that write to the console.
    /// </summary>
    internal static class ConsolePrinter
    {
        /// <summary>
        /// This method write welcome message on screen.
        /// </summary>
        internal static void PrintWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the game “15”.");
            Console.WriteLine("Please try to arrange the numbers sequentially.");
            Console.WriteLine("\nUse the codes:");
            Console.WriteLine("- 'top' to view the top scoreboard");
            Console.WriteLine("- 'restart' to start a new game");
            Console.WriteLine("- 'exit' to quit the game.");
            Console.ResetColor();
        }

        /// <summary>
        /// This method render the game field in console.
        /// </summary>
        /// <param name="puzzleField">Array containing field values.</param>
        internal static void PrintTheGameField(PuzzleField puzzleField)
        {
            Console.WriteLine(" -------------");

            for (int row = 0; row < puzzleField.MatrixSize; row++)
            {
                Console.Write("| ");

                for (int col = 0; col < puzzleField.MatrixSize; col++)
                {
                    int currentCelNumber = (puzzleField.MatrixSize * row) + col;
                    puzzleField.Body[currentCelNumber].Print();
                }

                Console.WriteLine("|");
            }

            Console.WriteLine(" -------------");
        }

        /// <summary>
        /// This method print the scoreboard in console.
        /// </summary>
        /// <param name="countOfTopPlayers">Count of top players.</param>
        /// <param name="topPlayersScores">Array of top scores players.</param>
        internal static void PrintScoreboard(int countOfTopPlayers, List<Tuple<string, int>> topPlayersScores)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nScoreboard:");

            if (countOfTopPlayers != 0)
            {
                for (int i = 0; i <= countOfTopPlayers - 1; i++)
                {
                    Console.WriteLine("{0} by {1}", topPlayersScores[i].Item1, topPlayersScores[i].Item2);
                }
            }
            else
            {
                Console.WriteLine("Empty Scoreboard! :)");
            }

            Console.ResetColor();
        }

        /// <summary>
        /// This method render the final won screen.
        /// </summary>
        /// <param name="countOfTotalMoves">Count of moves made by player.</param>
        internal static void PrintTheGameIsWon(int countOfTotalMoves)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("Congratulations! You won the game in {0} moves.", countOfTotalMoves);

            Console.Write("Please enter your name for the top scoreboard: ");

            Console.ResetColor();
        }
    }
}
