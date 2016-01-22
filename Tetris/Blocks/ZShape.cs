namespace Tetris.Blocks
{
    using Tetris.Blocks;

    public class ZShape : Figure
    {
        private const int Height = 2;
        private const int Width = 3;

        public ZShape(int coordX, int coordY)
            : base(coordX, coordY)
        {
            this.Blocks = new byte[Height, Width];

            this.Blocks[0, 0] = 1;
            this.Blocks[0, 1] = 1;
            this.Blocks[0, 2] = 0;
            this.Blocks[1, 0] = 0;
            this.Blocks[1, 1] = 1;
            this.Blocks[1, 2] = 1;
        }
    }
}
