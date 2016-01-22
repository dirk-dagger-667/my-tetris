namespace Tetris.Blocks.Contracts
{
    /// <summary>
    /// Interface to define the different figures
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// The the subpieces that define each figure as matrix
        /// </summary>
        byte[,] Blocks { get; set; }

        /// <summary>
        /// The position of the upper-leftmost subpiece of the figure
        /// </summary>
        int PositionX { get; set; }

        int PositionY { get; set; }

        IFigure CloneShape();
    }
}
