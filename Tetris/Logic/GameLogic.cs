namespace Tetris.Logic
{
    using Tetris.Blocks;
    using Tetris.Blocks.Contracts;
    using Tetris.ConsoleHelpers;
    using Tetris.Logic.Contracts;

    public class GameLogic : IGameLogic
    {
        public void MoveDown(IFigure shape, int playGroundHight)
        {
            if (shape.PositionX + shape.Blocks.GetLength(0) <= playGroundHight)
            {
                shape.PositionX++;
            }
        }

        public void MoveLeft(IFigure shape)
        {
            if (shape.PositionY > 1)
            {
                shape.PositionY--;
            }
        }

        public void MoveRight(IFigure shape, int playGroundWidth)
        {
            if (shape.PositionY + shape.Blocks.GetLength(1) < playGroundWidth + 1)
            {
                shape.PositionY++;
            }
        }

        public int CheckForWholeLines(IPlayGround playGround)
        {
            int linesRemoved = 0;

            for (int row = 0; row < playGround.Grid.GetLength(0); row++)
            {
                bool isFullLine = true;

                for (int col = 0; col < playGround.Grid.GetLength(1); col++)
                {
                    if (playGround.Grid[row, col] == 0)
                    {
                        isFullLine = false;
                        break;
                    }
                }

                if (isFullLine)
                {
                    for (int nextLine = row - 1; nextLine >= 0; nextLine--)
                    {
                        if (row < 0)
                        {
                            continue;
                        }

                        for (int colFromNextLine = 0; colFromNextLine < playGround.Grid.GetLength(1); colFromNextLine++)
                        {
                            playGround.Grid[nextLine + 1, colFromNextLine] = playGround.Grid[nextLine, colFromNextLine];
                        }
                    }

                    for (int colLastLine = 0; colLastLine < playGround.Grid.GetLength(1); colLastLine++)
                    {
                        playGround.Grid[0, colLastLine] = 0;
                    }

                    linesRemoved++;
                }
            }

            return linesRemoved;
        }

        public void Rotate(IFigure shape, int playGroundWidth, int playGroundHeight)
        {
            var width = shape.Blocks.GetLength(0);
            var height = shape.Blocks.GetLength(1);
            var newBlocks = new byte[height, width];

            if (shape.PositionY + width < playGroundWidth && shape.PositionX + height < playGroundHeight)
            {
                for (int col = 0; col < width; col++)
                {
                    for (int row = 0; row < height; row++)
                    {
                        newBlocks[row, width - col - 1] = shape.Blocks[col, row];
                    }
                }
            }

            shape.Blocks = newBlocks;
        }

        public void PlaceShapeInPlayGround(IFigure shape, IPlayGround playGround)
        {
            for (int figRow = 0; figRow < shape.Blocks.GetLength(0); figRow++)
            {
                for (int figCol = 0; figCol < shape.Blocks.GetLength(1); figCol++)
                {
                    var row = shape.PositionX - 1 + figRow;
                    var col = shape.PositionY - 1 + figCol;

                    if (shape.Blocks[figRow, figCol] == 1)
                    {
                        playGround.Grid[row, col] = 1;
                    }
                }
            }
        }

        public bool CheckForCollision(IFigure shape, IPlayGround playGround)
        {
            if (shape.PositionX + shape.Blocks.GetLength(0) > playGround.Grid.GetLength(0))
            {
                return true;
            }

            for (int shapeRow = 0; shapeRow < shape.Blocks.GetLength(0); shapeRow++)
            {
                for (int shapeCol = 0; shapeCol < shape.Blocks.GetLength(1); shapeCol++)
                {
                    if (shape.PositionX + shapeRow < 0)
                    {
                        continue;
                    }

                    if (playGround.Grid[shape.PositionX + shapeRow, shape.PositionY - 1 + shapeCol] == 1 && shape.Blocks[shapeRow, shapeCol] == 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CheckForGameOver(IPlayGround playGround)
        {
                for (int col = 0; col < playGround.Grid.GetLength(1); col++)
                {
                    if (playGround.Grid[1, col] == 1)
                    {
                        return true;
                    }
                }

            return false;
        }
    }
}
