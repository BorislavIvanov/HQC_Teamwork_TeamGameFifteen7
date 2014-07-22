using System;

namespace GameFifteenVersionSeven
{
    // Prototype design pattern.
    public class Cell : ICell, ICloneable
    {
        public int Context { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone() as Cell;
        }

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
