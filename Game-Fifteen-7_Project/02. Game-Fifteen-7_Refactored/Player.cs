using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteenVersionSeven
{
    public sealed class Player
    {
        public Player()
        {
            this.TotalMoves = 0;
        }

        //public static readonly Player instance = new Player();

        //public static Player Instance
        //{
        //    get
        //    {
        //        return instance;
        //    }
        //}

        public string Name { get; set; }
        public int TotalMoves { get; set; }
    }
}
