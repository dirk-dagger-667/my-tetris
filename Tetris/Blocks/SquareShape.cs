namespace Tetris.Blocks
{
    public class SquareShape : Figure
    {
        private const int Height = 2;
        private const int Width = 2;

        public SquareShape(int coordX, int coordY)
            : base(coordX, coordY)
        {
            this.Blocks = new byte[Height, Width];

            this.Blocks[0, 0] = 1;
            this.Blocks[0, 1] = 1;
            this.Blocks[1, 0] = 1;
            this.Blocks[1, 1] = 1;
        }
    }
}
