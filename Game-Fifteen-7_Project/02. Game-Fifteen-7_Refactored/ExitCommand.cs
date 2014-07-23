namespace GameFifteenVersionSeven
{
    using System;

    /// <summary>
    /// This is class for exiting from the game.
    /// </summary>
    public class ExitCommand : ICommand // Command design pattern.
    {
        public ExitCommand(GameEngine engine)
        {
            this.GameEngine = engine;
        }

        public GameEngine GameEngine { get; set; }

        /// <summary>
        /// This method execute the command.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Good bye!");
            this.GameEngine.IsGameOver = true;
        }
    }
}
