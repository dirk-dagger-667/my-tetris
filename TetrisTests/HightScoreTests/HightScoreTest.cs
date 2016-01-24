namespace TetrisTests.HightScoreTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tetris.HighScore;
    using Tetris.HighScore.Contracts;

    [TestClass]
    public class HightScoreTest
    {
        private const string FilePath = "../../../";
        private IHighScoreSaver highScore;

        [TestInitialize]
        public void Init()
        {
            highScore = new HighScoreSaver
        }

        [TestMethod]
        public void TestHightScoreSaverLoadHighScore()
        {

        }
    }
}
