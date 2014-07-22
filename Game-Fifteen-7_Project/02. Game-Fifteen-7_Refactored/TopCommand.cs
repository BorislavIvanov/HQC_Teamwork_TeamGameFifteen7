namespace GameFifteenVersionSeven
{
    using System;
    using System.Collections.Generic;

    public class TopCommand : ICommand
    {
        public int CountTopPlayers { get; set; }

        public List<Tuple<string,int>> TopPlayersScores { get; set; }

        public TopCommand(int countOfTopPlayers, List<Tuple<string, int>> topPlayersScores)
        {
            this.CountTopPlayers = countOfTopPlayers;
            this.TopPlayersScores = topPlayersScores;

        }
        public void Execute()
        {
            ConsolePrinter.PrintScoreboard(this.CountTopPlayers, this.TopPlayersScores);

            Console.WriteLine();
        }
    }
}
