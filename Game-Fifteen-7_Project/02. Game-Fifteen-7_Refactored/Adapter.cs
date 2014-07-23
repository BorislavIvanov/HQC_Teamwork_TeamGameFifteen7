using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteenVersionSeven
{
    class Adapter : Player //Adapter design pattern
    {
        PrintablePlayer printablePlayer = new PrintablePlayer();

        public override void Print()
        {
            printablePlayer.Display(base.Name, base.TotalMoves);
        }
    }
}
