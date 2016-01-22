namespace Tetris.Logic
{
    using Tetris.Logic.Contracts;

    public class PlayGround : IPlayGround
    {
        public PlayGround(int rows, int cols)
        {
            this.Grid = new byte[rows, cols];
        }

        public byte[,] Grid { get; set; }
    }
}
