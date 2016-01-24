namespace TetrisTests.BlocksTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tetris.Blocks;

    [TestClass]
    public class ZShapeTest
    {
        private const int Height = 2;
        private const int Width = 3;

        [TestMethod]
        public void TestCreationOfZShapeWithWrongCoordinates()
        {
            var shape = new ZShape(20, 20);

            Assert.AreEqual(Height, shape.Blocks.GetLength(0));
            Assert.AreEqual(Width, shape.Blocks.GetLength(1));
        }
    }
}
