namespace TetrisTests.LogicTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using Tetris.Blocks.Contracts;
    using Tetris.Logic;

    [TestClass]
    public class ShapeGeneratorTest
    {
        [TestMethod]
        public void TestGenerateShapeMethodShouldReturnARandomFigure()
        {
            var shapeGenerator = new ShapeGenerator();
            var figure = shapeGenerator.GenerateShape().CloneShape();

            Assert.IsInstanceOfType(figure, typeof(IFigure));
        }
    }
}
