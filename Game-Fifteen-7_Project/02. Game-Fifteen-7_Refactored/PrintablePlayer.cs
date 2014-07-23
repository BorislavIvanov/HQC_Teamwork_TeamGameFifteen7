using System;

namespace GameFifteenVersionSeven
{
    public class PrintablePlayer //To implement Adapter design pattern
    {
        public void Display(string name, int moves)
        {
            Console.WriteLine("{0} by {1}", name, moves);
        }
    }
}
