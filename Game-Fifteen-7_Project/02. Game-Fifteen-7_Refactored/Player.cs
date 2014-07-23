using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteenVersionSeven
{
    /// <summary>
    /// Player object.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Constructor for instance of new Player.
        /// </summary>
        public Player()
        {
            this.TotalMoves = 0;
        }

        /// <summary>
        /// Gets or sets the name of Player object.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the totalmoves of Player object.
        /// </summary>
        public int TotalMoves { get; set; }

        /// <summary>
        /// This print the Player.
        /// </summary>
        public virtual void Print() //To implement Adapter design pattern
        {
        }
    }
}
