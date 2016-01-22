namespace Tetris
{
    using Tetris.ConsoleHelpers;
    using Tetris.HighScore;
    using Tetris.Logic;

    public class Program
    {       
        public static void Main()
        {
            var engine = new Engine();
            engine.StartGame();

            // HighScoreSaver saver = new HighScoreSaver();
            // saver.SaveHightScore("Dimitar", 4, "../../highScore.xml");
            // saver.SaveHightScore("Chocho", 5, "../../highScore.xml");
            // saver.SaveHightScore("Smerch", 3, "../../highScore.xml");
            // saver.SaveHightScore("Ayattolah", 1, "../../highScore.xml");
            // saver.SaveHightScore("Hodja", 2, "../../highScore.xml");

            // var test = saver.LoadHighScore("../../highScore.xml");

            // ConsoleRenderer.DrawPlyerPositionInHighScore(test, "Dimitar");
        }
    }
}
