namespace Tetris.Logic
{
    using System;
    using Tetris.Logic.Contracts;

    public class PlayGround : IPlayGround
    {
        public PlayGround(int rows, int cols)
        {
            if (rows < 1)
            {
                throw new ArgumentOutOfRangeException("The rows cannot be less or eqaul to zero");
            }
            else if (cols < 1)
            {
                throw new ArgumentOutOfRangeException("The columbs cannot be less or eqaul to zero");
            }

            this.Grid = new byte[rows, cols];
        }

        public byte[,] Grid { get; set; }
    }
}
