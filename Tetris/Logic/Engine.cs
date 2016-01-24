namespace Tetris.Logic
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Tetris.Blocks.Contracts;
    using Tetris.ConsoleHelpers;
    using Tetris.HighScore;
    using Tetris.HighScore.Contracts;
    using Tetris.Logic.Contracts;

    public class Engine
    {
        private const int PlayGroundWidth = 16;
        private const int PlayGroundHeight = 25;
        private const int InfoPanelWidth = 20;
        private const int FullGameWidth = PlayGroundWidth + InfoPanelWidth + 3;
        private const int FullGameHeight = PlayGroundHeight + 2;
        private const string FilePath = "../../../highScore.xml";
        private const string EnterYouNameMSG = "Please enter your name: ";

        // maximum number of removed lines at once
        private static int[] scorePerLines = new int[] { 10, 20, 30, 40 };

        // 8 Levels in all
        private static int[] speedOfGamePerLevel = new int[] { 400, 350, 300, 250, 200, 150, 100, 50 };

        public Engine()
        {
            this.shapeGenerator = new ShapeGenerator();
            this.Logic = new GameLogic();
            this.PlayGround = new PlayGround(PlayGroundHeight, PlayGroundWidth);
            this.HighScore = new HighScoreSaver();

            this.Score = 0;
            this.Level = 1;

            this.CurrentShape = shapeGenerator.GenerateShape().CloneShape();
            this.NextShape = shapeGenerator.GenerateShape().CloneShape();
        }

        private int Score { get; set; }

        private int Level { get; set; }

        private IShapeGenerator shapeGenerator { get; set; }

        private IHighScoreSaver HighScore { get; set; }

        private IFigure CurrentShape { get; set; }

        private IFigure NextShape { get; set; }

        private IPlayGround PlayGround { get; set; }

        private IGameLogic Logic { get; set; }

        public void StartGame()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    ConsoleRenderer.PlaySound();
                }
            });

            ConsoleRenderer.ConsoleSettings(FullGameWidth, FullGameHeight);
            ConsoleRenderer.DrawBorders(FullGameWidth, FullGameHeight, PlayGroundWidth, InfoPanelWidth);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.DownArrow:
                            this.Logic.MoveDown(this.CurrentShape, PlayGroundHeight);
                            break;
                        case ConsoleKey.LeftArrow:
                            this.Logic.MoveLeft(this.CurrentShape);
                            break;
                        case ConsoleKey.RightArrow:
                            this.Logic.MoveRight(this.CurrentShape, PlayGroundWidth);
                            break;
                        case ConsoleKey.UpArrow:
                            this.Logic.Rotate(this.CurrentShape, PlayGroundWidth, PlayGroundHeight);
                            break;
                        default:
                            break;
                    }
                }

                if (this.Logic.CheckForGameOver(this.PlayGround))
                {
                    ConsoleRenderer.DrawGameOver();
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Write(EnterYouNameMSG);
                    string playerName = Console.ReadLine();
                    Console.Clear();
                    this.HighScore.SaveHightScore(playerName, this.Score, FilePath);
                    var sortedHightScore = this.HighScore.LoadHighScore(FilePath);
                    ConsoleRenderer.DrawPlyerPositionInHighScore(sortedHightScore, playerName);
                    return;
                }
                else if (this.Logic.CheckForCollision(this.CurrentShape, this.PlayGround))
                {
                    this.Logic.PlaceShapeInPlayGround(this.CurrentShape, this.PlayGround);

                    var numberOfRemovedLines = this.Logic.CheckForWholeLines(this.PlayGround);

                    if (numberOfRemovedLines > 0)
                    {
                        this.Score = scorePerLines[numberOfRemovedLines - 1] * this.Level;
                    }

                    this.Level = (this.Score / 500) + 1;

                    this.CurrentShape = this.NextShape;
                    this.NextShape = shapeGenerator.GenerateShape().CloneShape();
                }

                this.Logic.MoveDown(this.CurrentShape, PlayGroundHeight);

                ConsoleRenderer.DrawInfoPanel(PlayGroundWidth, this.NextShape, InfoPanelWidth, this.Score, this.Level);
                ConsoleRenderer.DrawPlayGround(this.PlayGround);
                ConsoleRenderer.DrawBorders(FullGameWidth, FullGameHeight, PlayGroundWidth, InfoPanelWidth);
                ConsoleRenderer.DrawFigure(this.CurrentShape, this.CurrentShape.PositionX - 1, this.CurrentShape.PositionY);

                // Thread.Sleep(100);
                Thread.Sleep(speedOfGamePerLevel[Level - 1]);
                
            }
        }
    }
}
