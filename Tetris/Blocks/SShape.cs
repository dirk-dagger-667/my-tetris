namespace Tetris.Blocks
{
    public class SShape : Figure
    {
        private const int Height = 2;
        private const int Width = 3;

        public SShape(int coordX, int coordY)
            : base(coordX, coordY)
        {
            this.Blocks = new byte[Height, Width];

            this.Blocks[0, 0] = 0;
            this.Blocks[0, 1] = 1;
            this.Blocks[0, 2] = 1;
            this.Blocks[1, 0] = 1;
            this.Blocks[1, 1] = 1;
            this.Blocks[1, 2] = 0;
        }
    }
}
