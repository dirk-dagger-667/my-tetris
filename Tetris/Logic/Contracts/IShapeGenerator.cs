namespace Tetris.Logic.Contracts
{
    using Tetris.Blocks.Contracts;

    public interface IShapeGenerator
    {
        IFigure GenerateShape();
    }
}
