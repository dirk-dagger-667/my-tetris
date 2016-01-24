namespace TetrisTests.BlocksTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Tetris.Blocks;
    using Tetris.Blocks.Contracts;

    [TestClass]
    public class FigureTest
    {
        [TestMethod]
        public void TestCreationFigureWithPositiveIntegersForCoordinates()
        {
            var figure = new Figure(7, 7);

            Assert.IsInstanceOfType(figure, typeof(IFigure));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The coordX cannot be negative")]
        public void TestCreationFigureWithNegativeIntegerForXCoord()
        {
            var figure = new Figure(-1, 7);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The coordY cannot be negative")]
        public void TestCreationFigureWithNegativeIntegerForYCoord()
        {
            var figure = new Figure(7, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The coordX and coordY cannot be negative")]
        public void TestCreationFigureWithNegativeIntegerForBothCoords()
        {
            var figure = new Figure(-1, -1);
        }

        [TestMethod]
        public void TestCloneMethod()
        {
            var figure = new Figure(6, 6);
            var clonedFigure = figure.CloneShape();

            Assert.AreEqual(figure.PositionX, clonedFigure.PositionX);
            Assert.AreEqual(figure.PositionY, clonedFigure.PositionY);
        }
    }
}
