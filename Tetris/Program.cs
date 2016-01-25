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
        }
    }
}
