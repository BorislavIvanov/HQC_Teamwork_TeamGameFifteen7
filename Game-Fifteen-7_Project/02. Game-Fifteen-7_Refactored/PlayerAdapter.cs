namespace GameFifteenVersionSeven
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This method is adapter for Player object for ability to print in console.
    /// </summary>
    public class PlayerAdapter : Player // Adapter design pattern
    {
        /// <summary>
        /// New instance of PrintablePlayer.
        /// </summary>
        private PrintablePlayer printablePlayer = new PrintablePlayer();

        /// <summary>
        /// Overrided Player print method.
        /// </summary>
        public override void Print()
        {
            printablePlayer.Display(base.Name, base.TotalMoves);
        }
    }
}
