namespace GameFifteenVersionSeven
{
    using System;

    // Prototype design pattern.

    /// <summary>
    /// Cell object.
    /// </summary>
    public class Cell : ICell, ICloneable
    {
        private int content;
        private int row;
        private int col;

        /// <summary>
        /// Gets or sets the content of Cell.
        /// </summary>
        public int Content
        {
            get
            {
                return this.content;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The content must be a positive integer!");
                }

                this.content = value;
            }
        }

        /// <summary>
        /// Gets or sets the row of Cell.
        /// </summary>
        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of row must be a positive integer!");
                }

                this.row = value;
            }
        }

        /// <summary>
        /// Gets or sets the collum of cell.
        /// </summary>
        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of column must be a positive integer!");
                }

                this.col = value;
            }
        }

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
            if (this.Content >= 10)
            {
                Console.Write("{0} ", this.Content);
            }
            else if (this.Content == 0)
            {
                Console.Write("   ");
            }
            else
            {
                Console.Write(" {0} ", this.Content);
            }
        }
    }
}
