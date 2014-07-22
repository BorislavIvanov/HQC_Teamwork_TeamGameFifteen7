namespace GameFifteenVersionSeven
{
    /// <summary>
    /// Interface ICell
    /// </summary>
    public interface ICell
    {
        /// <summary>
        /// Gets or sets the content of Cell.
        /// </summary>
        int Context { get; set; }

        /// <summary>
        /// Gets or sets the row of Cell.
        /// </summary>
        int Row { get; set; }

        /// <summary>
        /// Gets or sets the collum of cell.
        /// </summary>
        int Col { get; set; }
    }
}
