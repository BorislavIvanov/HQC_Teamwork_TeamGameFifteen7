namespace GameFifteenVersionSeven
{
    /// <summary>
    /// This class manage all input game commands.
    /// </summary>
    public class CommandManager // Command design pattern.
    {
        /// <summary>
        /// This method proceed the command.
        /// </summary>
        /// <param name="command">This is input command for proceed.</param>
        public void Proceed(ICommand command)
        {
            command.Execute();
        }
    }
}
