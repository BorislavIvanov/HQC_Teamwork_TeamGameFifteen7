using System;

namespace GameFifteenVersionSeven
{
    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Good bye!");
        }
    }
}
