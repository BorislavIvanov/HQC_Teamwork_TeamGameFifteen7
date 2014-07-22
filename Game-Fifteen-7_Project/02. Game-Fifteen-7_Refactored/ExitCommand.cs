using System;

namespace GameFifteenVersionSeven
{
    // Command design pattern.
    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Good bye!");
        }
    }
}
