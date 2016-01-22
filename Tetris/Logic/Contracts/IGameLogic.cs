namespace Tetris.Logic.Contracts
{
    using System;

    public interface IGameLogic
    {
        bool CheckForCollision(Tetris.Blocks.Contracts.IFigure shape, IPlayGround playGround);

        bool CheckForGameOver(IPlayGround playGround);

        int CheckForWholeLines(IPlayGround playGround);

        void MoveDown(Tetris.Blocks.Contracts.IFigure shape, int playGroundHight);

        void MoveLeft(Tetris.Blocks.Contracts.IFigure shape);

        void MoveRight(Tetris.Blocks.Contracts.IFigure shape, int playGroundWidth);

        void PlaceShapeInPlayGround(Tetris.Blocks.Contracts.IFigure shape, IPlayGround playGround);

        void Rotate(Tetris.Blocks.Contracts.IFigure shape, int playGroundWidth, int playGroundHeight);
    }
}
