using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteenVersionSeven
{
    public class PlayerAdapter : Player //Adapter design pattern
    {
        PrintablePlayer printablePlayer = new PrintablePlayer();

        public override void Print()
        {
            printablePlayer.Display(base.Name, base.TotalMoves);
        }
    }
}
