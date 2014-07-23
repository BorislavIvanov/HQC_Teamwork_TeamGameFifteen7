namespace GameFifteenVersionSeven
{
    using System;

    /// <summary>
    /// This is class for exiting from the game.
    /// </summary>
    public class ExitCommand : ICommand // Command design pattern.
    {
        /// <summary>
        /// This method get the instance of current engine.
        /// </summary>
        /// <param name="engine">Currently initialised engine.</param>
        public ExitCommand(GameEngine engine)
        {
            this.GameEngine = engine;
        }

        /// <summary>
        /// Gets or sets GameEngine.
        /// </summary>
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
