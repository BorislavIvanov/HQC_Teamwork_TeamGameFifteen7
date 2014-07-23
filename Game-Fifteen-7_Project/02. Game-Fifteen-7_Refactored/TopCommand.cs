﻿namespace GameFifteenVersionSeven
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class manage the showing of top players.
    /// </summary>
    public class TopCommand : ICommand // Command design pattern.
    {
        private GameEngine testEngine;

        /// <summary>
        /// Gets or sets the count of top players.
        /// </summary>
        public int CountTopPlayers { get; set; }

        /// <summary>
        /// Gets of sets the top scores players.
        /// </summary>
        public List<Tuple<string,int>> TopPlayersScores { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countOfTopPlayers"></param>
        /// <param name="topPlayersScores"></param>
        public TopCommand(List<Tuple<string, int>> topPlayersScores)
        {
            this.CountTopPlayers = topPlayersScores.Count;
            this.TopPlayersScores = topPlayersScores;

        }

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
