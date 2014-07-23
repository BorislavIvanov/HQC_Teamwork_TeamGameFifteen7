namespace GameFifteenVersionSeven
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class manage the showing of top players.
    /// </summary>
    public class TopCommand : ICommand // Command design pattern.
    {
        /// <summary>
        /// Initialize a new instance of the TopCommand class
        /// </summary>
        /// <param name="topPlayersScores"></param>
        public TopCommand(List<Player> topPlayersScores)
        {
            this.CountTopPlayers = topPlayersScores.Count;
            this.TopPlayersScores = topPlayersScores;
        }

        /// <summary>
        /// Gets or sets the count of top players.
        /// </summary>
        public int CountTopPlayers { get; set; }

        /// <summary>
        /// Gets of sets the top scores players.
        /// </summary>
        public List<Player> TopPlayersScores { get; set; }

        /// <summary>
        /// This method execute the top command.
        /// </summary>
        public void Execute()
        {
            ConsolePrinter.PrintScoreboard(this.TopPlayersScores);

            Console.WriteLine();
        }
    }
}
