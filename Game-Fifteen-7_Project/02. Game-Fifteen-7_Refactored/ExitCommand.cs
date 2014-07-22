namespace GameFifteenVersionSeven
{
    using System;

    /// <summary>
    /// This is class for exiting from the game.
    /// </summary>
    public class ExitCommand : ICommand // Command design pattern.
    {
        /// <summary>
        /// This method execute the command.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Good bye!");
        }
    }
}
