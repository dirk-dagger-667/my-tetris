namespace Tetris.HighScore.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IHighScoreSaver
    {
        IDictionary<string, int> LoadHighScore(string filePath);

        void SaveHightScore(string playerName, int score, string filePath);
    }
}
