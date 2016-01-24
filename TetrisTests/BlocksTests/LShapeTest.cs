namespace TetrisTests.BlocksTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tetris.Blocks;

    [TestClass]
    public class LShapeTest
    {
        private const int Height = 2;
        private const int Width = 3;

        [TestMethod]
        public void TestCreationOfLShapeWithWrongCoordinates()
        {
            var shape = new LShape(20, 20);

            Assert.AreEqual(Height, shape.Blocks.GetLength(0));
            Assert.AreEqual(Width, shape.Blocks.GetLength(1));
        }
    }
}
