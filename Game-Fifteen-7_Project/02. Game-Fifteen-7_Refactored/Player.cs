using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteenVersionSeven
{
    public class Player
    {
        public Player()
        {
            this.TotalMoves = 0;
        }

        public string Name { get; set; }
        public int TotalMoves { get; set; }

        public virtual void Print() //To implement Adapter design pattern
        {
        }
    }
}
