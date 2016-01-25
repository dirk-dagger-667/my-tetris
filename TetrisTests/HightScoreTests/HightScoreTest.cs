namespace TetrisTests.HightScoreTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tetris.HighScore;
    using Tetris.HighScore.Contracts;

    [TestClass]
    public class HightScoreTest
    {
        private const string FilePath = "../../../Tetris/highScore.xml";
        private IHighScoreSaver highScore;

        [TestInitialize]
        public void Init()
        {
            highScore = new HighScoreSaver();
        }

        [TestMethod]
        public void TestHightScoreSaverLoadHighScoreReturnOrderedDictOfHightScore()
        {
            var sortedHightScore = highScore.LoadHighScore(FilePath);
            var scoreArray = new int[sortedHightScore.Count];
            var count = 0;

            Assert.AreEqual(6, sortedHightScore.Count);

            foreach (var pair in sortedHightScore)
            {
                scoreArray[count] = pair.Value;
                count++;
            }

            for (int score = 0; score < scoreArray.Length - 1; score++)
            {
                Assert.IsTrue(scoreArray[score] > scoreArray[score + 1]);
            }
        }

        public 
    }
}
