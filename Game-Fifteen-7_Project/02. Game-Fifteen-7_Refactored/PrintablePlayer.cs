namespace GameFifteenVersionSeven
{
    using System;

    /// <summary>
    /// This method is attached to the adapter of the Player object.
    /// </summary>
    public class PrintablePlayer // To implement Adapter design pattern
    {
        /// <summary>
        /// This method displaye the name and moves in the console.
        /// </summary>
        /// <param name="name">Name of the current player.</param>
        /// <param name="moves">Moves of the player.</param>
        public void Display(string name, int moves)
        {
            Console.WriteLine("{0} by {1}", name, moves);
        }
    }
}
