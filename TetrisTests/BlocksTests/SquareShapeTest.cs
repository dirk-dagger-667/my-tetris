﻿namespace TetrisTests.BlocksTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tetris.Blocks;

    [TestClass]
    public class SquareShapeTest
    {
        private const int Height = 2;
        private const int Width = 2;

        [TestMethod]
        public void TestCreationOfSquareShapeWithWrongCoordinates()
        {
            var shape = new SquareShape(20, 20);

            Assert.AreEqual(Height, shape.Blocks.GetLength(0));
            Assert.AreEqual(Width, shape.Blocks.GetLength(1));
        }
    }
}
