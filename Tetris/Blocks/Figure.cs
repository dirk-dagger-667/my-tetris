namespace Tetris.Blocks
{
    using Tetris.Blocks.Contracts;

    public class Figure : IFigure
    {
        public Figure(int coordX, int coordY)
        {
            this.PositionX = coordX;
            this.PositionY = coordY;
        }

        public byte[,] Blocks { get; set; }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public IFigure CloneShape()
        {
            var clonedShape = new Figure(this.PositionX, this.PositionY);
            clonedShape.Blocks = new byte[this.Blocks.GetLength(0), this.Blocks.GetLength(1)];

            for (int row = 0; row < clonedShape.Blocks.GetLength(0); row++)
            {
                for (int col = 0; col < clonedShape.Blocks.GetLength(1); col++)
                {
                    clonedShape.Blocks[row, col] = this.Blocks[row, col];
                }
            }

            return clonedShape;
        }
    }
}
