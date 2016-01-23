namespace Tetris.Tests.LogicTests
{

    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Tetris.Blocks;
    using Tetris.Logic;
    using Tetris.Logic.Contracts;
    using Tetris.Tests.LogicTests;

    [TestClass]
    public class LogicTest
    {
        private IGameLogic logic;
        private IPlayGround playGround;

        [TestInitialize]
        public void Init()
        {
            logic = new GameLogic();
            playGround = new PlayGround(20, 20);
        }

        [TestMethod]
        public void MoveDownWhileNotAtTheBottomOfTheGrid()
        {
            Figure figure = new TShape(7, 7);

            logic.MoveDown(figure, 25);

            Assert.AreEqual(8, figure.PositionX);
            Assert.AreEqual(7, figure.PositionY);
        }

        [TestMethod]
        public void MoveDownWhileAtTheBottomOfTheGrid()
        {
            Figure figure = new TShape(25, 7);

            logic.MoveDown(figure, 25);

            Assert.AreEqual(25, figure.PositionX);
            Assert.AreEqual(7, figure.PositionY);
        }

        [TestMethod]
        public void MoveRightWhileNotAtTheRightBorder()
        {
            Figure figure = new TShape(7, 7);

            logic.MoveRight(figure, 25);

            Assert.AreEqual(7, figure.PositionX);
            Assert.AreEqual(8, figure.PositionY);
        }

        [TestMethod]
        public void MoveRightWhileAtTheRightBorder()
        {
            Figure figure = new TShape(7, 24);

            logic.MoveRight(figure, 25);

            Assert.AreEqual(7, figure.PositionX);
            Assert.AreEqual(24, figure.PositionY);
        }

        [TestMethod]
        public void MoveLeftWhileNotAtTheRightBorder()
        {
            Figure figure = new TShape(7, 7);

            logic.MoveLeft(figure);

            Assert.AreEqual(7, figure.PositionX);
            Assert.AreEqual(6, figure.PositionY);
        }

        [TestMethod]
        public void MoveLeftWhileAtTheRightBorder()
        {
            Figure figure = new TShape(7, 1);

            logic.MoveLeft(figure);

            Assert.AreEqual(7, figure.PositionX);
            Assert.AreEqual(1, figure.PositionY);
        }

        [TestMethod]
        public void CheckForLinesWhileNoFullLinePresent()
        {
            for (int row = 0; row < playGround.Grid.GetLength(0); row++)
            {
                for (int col = 0; col < playGround.Grid.GetLength(1); col++)
                {
                    if (col % 2 == 0)
                    {
                        playGround.Grid[row, col] = 1;
                    }
                }
            }

            Assert.AreEqual(0, logic.CheckForWholeLines(playGround));
        }

        [TestMethod]
        public void CheckForLinesWhileOneFullLinePresent()
        {
            for (int col = 0; col < playGround.Grid.GetLength(1); col++)
            {
                playGround.Grid[19, col] = 1;
            }

            Assert.AreEqual(1, logic.CheckForWholeLines(playGround));
        }

        [TestMethod]
        public void CheckForLinesWhileTwoFullLinePresent()
        {
            for (int col = 0; col < playGround.Grid.GetLength(1); col++)
            {
                playGround.Grid[19, col] = 1;
                playGround.Grid[18, col] = 1;
            }

            Assert.AreEqual(2, logic.CheckForWholeLines(playGround));
        }

        [TestMethod]
        public void CheckForLinesWhileThreeFullLinePresent()
        {
            for (int col = 0; col < playGround.Grid.GetLength(1); col++)
            {
                playGround.Grid[19, col] = 1;
                playGround.Grid[18, col] = 1;
                playGround.Grid[17, col] = 1;
            }

            Assert.AreEqual(3, logic.CheckForWholeLines(playGround));
        }

        [TestMethod]
        public void CheckForLinesWhileFourFullLinePresent()
        {
            for (int col = 0; col < playGround.Grid.GetLength(1); col++)
            {
                playGround.Grid[19, col] = 1;
                playGround.Grid[18, col] = 1;
                playGround.Grid[17, col] = 1;
                playGround.Grid[16, col] = 1;
            }

            Assert.AreEqual(4, logic.CheckForWholeLines(playGround));
        }

        [TestMethod]
        public void RotateFigureOnce()
        {
            Figure figure = new TShape(7, 7);
            logic.Rotate(figure, playGround.Grid.GetLength(1), playGround.Grid.GetLength(0));

            Assert.AreEqual(1, figure.Blocks[0, 0]);
            Assert.AreEqual(0, figure.Blocks[0, 1]);
            Assert.AreEqual(1, figure.Blocks[1, 0]);
            Assert.AreEqual(1, figure.Blocks[1, 1]);
            Assert.AreEqual(1, figure.Blocks[2, 0]);
            Assert.AreEqual(0, figure.Blocks[2, 1]);
        }

        [TestMethod]
        public void RotateFigureTwice()
        {
            Figure figure = new TShape(7, 7);
            logic.Rotate(figure, playGround.Grid.GetLength(1), playGround.Grid.GetLength(0));
            logic.Rotate(figure, playGround.Grid.GetLength(1), playGround.Grid.GetLength(0));

            Assert.AreEqual(1, figure.Blocks[0, 0]);
            Assert.AreEqual(1, figure.Blocks[0, 1]);
            Assert.AreEqual(1, figure.Blocks[0, 2]);
            Assert.AreEqual(0, figure.Blocks[1, 0]);
            Assert.AreEqual(1, figure.Blocks[1, 1]);
            Assert.AreEqual(0, figure.Blocks[1, 2]);
        }

        [TestMethod]
        public void RotateFigureThrice()
        {
            Figure figure = new TShape(7, 7);
            logic.Rotate(figure, playGround.Grid.GetLength(1), playGround.Grid.GetLength(0));
            logic.Rotate(figure, playGround.Grid.GetLength(1), playGround.Grid.GetLength(0));
            logic.Rotate(figure, playGround.Grid.GetLength(1), playGround.Grid.GetLength(0));

            Assert.AreEqual(0, figure.Blocks[0, 0]);
            Assert.AreEqual(1, figure.Blocks[0, 1]);
            Assert.AreEqual(1, figure.Blocks[1, 0]);
            Assert.AreEqual(1, figure.Blocks[1, 1]);
            Assert.AreEqual(0, figure.Blocks[2, 0]);
            Assert.AreEqual(1, figure.Blocks[2, 1]);
        }

        [TestMethod]
        public void RotateFigureQuarce()
        {
            Figure figure = new TShape(7, 7);
            logic.Rotate(figure, playGround.Grid.GetLength(1), playGround.Grid.GetLength(0));
            logic.Rotate(figure, playGround.Grid.GetLength(1), playGround.Grid.GetLength(0));
            logic.Rotate(figure, playGround.Grid.GetLength(1), playGround.Grid.GetLength(0));
            logic.Rotate(figure, playGround.Grid.GetLength(1), playGround.Grid.GetLength(0));

            Assert.AreEqual(0, figure.Blocks[0, 0]);
            Assert.AreEqual(1, figure.Blocks[0, 1]);
            Assert.AreEqual(0, figure.Blocks[0, 2]);
            Assert.AreEqual(1, figure.Blocks[1, 0]);
            Assert.AreEqual(1, figure.Blocks[1, 1]);
            Assert.AreEqual(1, figure.Blocks[1, 2]);
        }

        [TestMethod]
        public void PlaceFigureInPlayGround()
        {
            Figure figure = new TShape(7, 7);

            logic.PlaceShapeInPlayGround(figure, playGround);

            Assert.AreEqual(0, playGround.Grid[figure.PositionX - 1, figure.PositionY - 1]);
            Assert.AreEqual(1, playGround.Grid[figure.PositionX - 1, figure.PositionY]);
            Assert.AreEqual(0, playGround.Grid[figure.PositionX - 1, figure.PositionY + 1]);
            Assert.AreEqual(1, playGround.Grid[figure.PositionX, figure.PositionY - 1]);
            Assert.AreEqual(1, playGround.Grid[figure.PositionX, figure.PositionY]);
            Assert.AreEqual(1, playGround.Grid[figure.PositionX, figure.PositionY + 1]);
        }

        [TestMethod]
        public void CheckForGameOverTrue()
        {
            Figure figure = new TShape(1, 4);
            logic.PlaceShapeInPlayGround(figure, playGround);

            logic.CheckForGameOver(playGround);

            Assert.IsTrue(logic.CheckForGameOver(playGround) == true);
        }

        [TestMethod]
        public void CheckForGameOverFalse()
        {
            Figure figure = new TShape(5, 5);
            logic.PlaceShapeInPlayGround(figure, playGround);

            logic.CheckForGameOver(playGround);

            Assert.IsFalse(logic.CheckForGameOver(playGround) == true);
        }
    }
}
