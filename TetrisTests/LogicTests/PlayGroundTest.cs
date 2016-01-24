namespace TetrisTests.LogicTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tetris.Logic;

    [TestClass]
    public class PlayGroundTest
    {
        [TestMethod]
        public void TestCreationOfPlayGroundWithPositiveIntegersForRowsAndCols()
        {
            var playGround = new PlayGround(20, 20);

            Assert.AreEqual(20, playGround.Grid.GetLength(0));
            Assert.AreEqual(20, playGround.Grid.GetLength(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Negative rows")]
        public void TestCreatingOfPlayGroundWithNegativeIntegersForRows()
        {
            var playGround = new PlayGround(-1, 50);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Negative cols")]
        public void TestCreatingOfPlayGroundWithNegativeIntegersForCols()
        {
            var playGround = new PlayGround(20, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Negative rows and cols")]
        public void TestCreatingOfPlayGroundWithNegativeIntegersForRowsAndCols()
        {
            var playGround = new PlayGround(20, -1);
        }    
    }
}
