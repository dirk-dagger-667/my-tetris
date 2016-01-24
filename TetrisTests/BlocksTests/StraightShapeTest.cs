namespace TetrisTests.BlocksTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tetris.Blocks;

    [TestClass]
    public class StraightShapeTest
    {
        private const int Height = 1;
        private const int Width = 4;

        [TestMethod]
        public void TestCreationOfStraightShapeWithWrongCoordinates()
        {
            var shape = new StraightShape(20, 20);

            Assert.AreEqual(Height, shape.Blocks.GetLength(0));
            Assert.AreEqual(Width, shape.Blocks.GetLength(1));
        }
    }
}
