namespace Tetris.Logic
{
    using System;
    using Tetris.Blocks;
    using Tetris.Blocks.Contracts;
    using Tetris.Logic.Contracts;

    public class ShapeGenerator : IShapeGenerator
    {
        private const int NumberOfShapes = 7;
        private const int PlayGroundWidth = 16;
        private Random randomGenerator = new Random();
        private IFigure[] allShapes = new Figure[NumberOfShapes]
            {
                new JShape(1, PlayGroundWidth / 2),
                new LShape(1, PlayGroundWidth / 2),
                new SquareShape(1, PlayGroundWidth / 2),
                new SShape(1, PlayGroundWidth / 2),
                new StraightShape(1, PlayGroundWidth / 2),
                new TShape(1, PlayGroundWidth / 2),
                new ZShape(1, PlayGroundWidth / 2)
            };

        public IFigure GenerateShape()
        {
            return allShapes[randomGenerator.Next(allShapes.Length)];
        }
    }
}
