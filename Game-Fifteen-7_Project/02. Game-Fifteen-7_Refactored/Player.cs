namespace GameFifteenVersionSeven
{
    public class Player
    {
        /// <summary>
        /// Initializes a new instance of the Player class
        /// </summary>
        public Player()
        {
            this.TotalMoves = 0;
        }

        public string Name { get; set; }
        public int TotalMoves { get; set; }

        /// <summary>
        /// Virtual method to implement Adapter design pattern
        /// </summary>
        public virtual void Print() //To implement Adapter design pattern
        {
        }
    }
}
