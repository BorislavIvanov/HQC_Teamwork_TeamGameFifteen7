namespace GameFifteenVersionSeven
{
    using System;

    // Prototype design pattern.
    /// <summary>
    /// Cell object.
    /// </summary>
    public class Cell : ICell, ICloneable
    {
        /// <summary>
        /// Gets or sets the content of Cell.
        /// </summary>
        public int Context { get; set; }

        /// <summary>
        /// Gets or sets the row of Cell.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the collum of cell.
        /// </summary>
        public int Col { get; set; }

        /// <summary>
        /// This method make copy of the Cell object.
        /// </summary>
        /// <returns>This returns cloned object of the cell.</returns>
        public object Clone()
        {
            return this.MemberwiseClone() as Cell;
        }

        /// <summary>
        /// This method print the object in console.
        /// </summary>
        public void Print()
        {
            if (this.Context >= 10)
            {
                Console.Write("{0} ", this.Context);
            }
            else if (this.Context == 0)
            {
                Console.Write("   ");
            }
            else
            {
                Console.Write(" {0} ", this.Context);
            }
        }
    }
}
