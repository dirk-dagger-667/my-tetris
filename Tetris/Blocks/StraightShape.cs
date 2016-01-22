namespace Tetris.Blocks
{
    public class StraightShape : Figure
    {
        private const int Height = 1;
        private const int Width = 4;

        public StraightShape(int coordX, int coordY)
            : base(coordX, coordY)
        {
            this.Blocks = new byte[Height, Width];

            this.Blocks[0, 0] = 1;
            this.Blocks[0, 1] = 1;
            this.Blocks[0, 2] = 1;
            this.Blocks[0, 3] = 1;
        }
    }
}
