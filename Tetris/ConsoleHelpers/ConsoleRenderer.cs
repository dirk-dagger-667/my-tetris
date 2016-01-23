namespace Tetris.ConsoleHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Xml.Linq;

    using Tetris.Blocks;
    using Tetris.Blocks.Contracts;
    using Tetris.Logic;
    using Tetris.Logic.Contracts;

    public static class ConsoleRenderer
    {
        private const char BorderSymbol = '\u2593';
        private const char ShapeSymbol = '\u2588';
        private const string GameName = "My Tetris";
        private const string NextString = "   Next:";
        private const string EmptySpaces = "             ";
        private const string ScoreString = "   Score:";
        private const string LevelString = "   Level:";
        private const string ControlsString = "    Controls:";
        private const string RotateRightString = "  ^ - rotate right";
        private const string MoveLeftString = "  < - move left";
        private const string MoveRightString = "  > - move right";
        private const string MoveDownString = "  v - move down";
        private const string GameOverString = string.Format(@"
      ___           ___           ___           ___     
     /  /\         /  /\         /__/\         /  /\    
    /  /:/_       /  /::\       |  |::\       /  /:/_   
   /  /:/ /\     /  /:/\:\      |  |:|:\     /  /:/ /\  
  /  /:/_/::\   /  /:/~/::\   __|__|:|\:\   /  /:/ /:/_ 
 /__/:/__\/\:\ /__/:/ /:/\:\ /__/::::| \:\ /__/:/ /:/ /\
 \  \:\ /~~/:/ \  \:\/:/__\/ \  \:\~~\__\/ \  \:\/:/ /:/
  \  \:\  /:/   \  \::/       \  \:\        \  \::/ /:/ 
   \  \:\/:/     \  \:\        \  \:\        \  \:\/:/  
    \  \::/       \  \:\        \  \:\        \  \::/   
     \__\/         \__\/         \__\/         \__\/    
      ___                        ___           ___     
     /  /\          ___         /  /\         /  /\    
    /  /::\        /__/\       /  /:/_       /  /::\   
   /  /:/\:\       \  \:\     /  /:/ /\     /  /:/\:\  
  /  /:/  \:\       \  \:\   /  /:/ /:/_   /  /:/~/:/  
 /__/:/ \__\:\  ___  \__\:\ /__/:/ /:/ /\ /__/:/ /:/___
 \  \:\ /  /:/ /__/\ |  |:| \  \:\/:/ /:/ \  \:\/:::::/
  \  \:\  /:/  \  \:\|  |:|  \  \::/ /:/   \  \::/~~~~ 
   \  \:\/:/    \  \:\__|:|   \  \:\/:/     \  \:\     
    \  \::/      \__\::::/     \  \::/       \  \:\    
     \__\/           ~~~~       \__\/         \__\/    

");
            
        public static void DrawOnPosition(int row, int col, object data)
        {
            Console.SetCursorPosition(col, row);
            Console.Write(data);
        }

        public static void DrawBorders(int fullGameWidth, int fullGameHeight, int playGroundWidth, int infoPanelWidth)
        {
            Console.ForegroundColor = ConsoleColor.White;

            for (int row = 0; row < fullGameHeight; row++)
            {
                DrawOnPosition(row, 0, BorderSymbol);
                DrawOnPosition(row, playGroundWidth + 1, BorderSymbol);
                DrawOnPosition(row, playGroundWidth + 1 + infoPanelWidth + 1, BorderSymbol);
            }

            for (int col = 0; col < fullGameWidth; col++)
            {
                DrawOnPosition(0, col, BorderSymbol);
                DrawOnPosition(fullGameHeight - 1, col, BorderSymbol);
            }
        }

        public static void DrawFigure(IFigure shape, int row, int col)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            for (int x = 0; x < shape.Blocks.GetLength(0); x++)
            {
                for (int y = 0; y < shape.Blocks.GetLength(1); y++)
                {
                    if (shape.Blocks[x, y] == 1)
                    {
                        DrawOnPosition(row + x, col + y, ShapeSymbol);
                    }
                }
            }
        }

        public static void ConsoleSettings(int fullGameWidth, int fullGameHeight)
        {
            Console.CursorVisible = false;
            Console.Title = GameName;
            Console.WindowWidth = fullGameWidth;
            Console.BufferWidth = fullGameWidth;
            Console.WindowHeight = fullGameHeight + 1;
            Console.BufferHeight = fullGameHeight + 1;
        }

        public static void DrawInfoPanel(int playGroundWidth, IFigure nextShape, int infoPanelWidth, int score, int level)
        {
            Console.ForegroundColor = ConsoleColor.White;

            DrawOnPosition(1, playGroundWidth + 4, NextString);

            for (int i = 2; i <= 5; i++)
            {
                DrawOnPosition(i, playGroundWidth + 2, EmptySpaces);
            }

            DrawFigure(nextShape, 2, playGroundWidth + 9);

            DrawOnPosition(9, playGroundWidth + 4, ScoreString);
            int scoreStartposition = ((infoPanelWidth / 2) - (score.ToString().Length - 1)) / 2;
            scoreStartposition = scoreStartposition + playGroundWidth + 2;
            DrawOnPosition(10, scoreStartposition - 1, score);

            DrawOnPosition(11, playGroundWidth + 4, LevelString);
            DrawOnPosition(12, playGroundWidth + 10, level);

            DrawOnPosition(13, playGroundWidth + 3, ControlsString);
            DrawOnPosition(14, playGroundWidth + 2, RotateRightString);
            DrawOnPosition(15, playGroundWidth + 2, MoveLeftString);
            DrawOnPosition(16, playGroundWidth + 2, MoveRightString);
            DrawOnPosition(17, playGroundWidth + 2, MoveDownString;
        }

        public static void DrawPlayGround(IPlayGround playGround)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            for (int row = 0; row < playGround.Grid.GetLength(0); row++)
            {
                for (int col = 0; col < playGround.Grid.GetLength(1); col++)
                {
                    if (playGround.Grid[row, col] == 0)
                    {
                        DrawOnPosition(row + 1, col + 1, ' ');
                    }
                    else
                    {
                        DrawOnPosition(row + 1, col + 1, ShapeSymbol);
                    }
                }
            }
        }

        public static void DrawGameOver()
        {
            Console.Clear();

            Console.WindowWidth = 60;
            Console.WindowHeight = 25;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            Console.ForegroundColor = ConsoleColor.Red;

            DrawOnPosition(1, 1, GameOverString);
        }

        public static void DrawPlyerPositionInHighScore(IDictionary<string, int> sortedHighScore, string playerName)
        {
            var sb = new StringBuilder();

            foreach (var player in sortedHighScore)
            {
                if (player.Key == playerName)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine("Player's Name : {0}   Player's Score: {1}", player.Key, player.Value);
            }
        }

        public static void PlaySound()
        {
            const int SoundLenght = 100;
            Console.Beep(1320, SoundLenght * 4);
            Console.Beep(990, SoundLenght * 2);
            Console.Beep(1056, SoundLenght * 2);
            Console.Beep(1188, SoundLenght * 2);
            Console.Beep(1320, SoundLenght);
            Console.Beep(1188, SoundLenght);
            Console.Beep(1056, SoundLenght * 2);
            Console.Beep(990, SoundLenght * 2);
            Console.Beep(880, SoundLenght * 4);
            Console.Beep(880, SoundLenght * 2);
            Console.Beep(1056, SoundLenght * 2);
            Console.Beep(1320, SoundLenght * 4);
            Console.Beep(1188, SoundLenght * 2);
            Console.Beep(1056, SoundLenght * 2);
            Console.Beep(990, SoundLenght * 6);
            Console.Beep(1056, SoundLenght * 2);
            Console.Beep(1188, SoundLenght * 4);
            Console.Beep(1320, SoundLenght * 4);
            Console.Beep(1056, SoundLenght * 4);
            Console.Beep(880, SoundLenght * 4);
            Console.Beep(880, SoundLenght * 4);
            Thread.Sleep(SoundLenght * 2);
            Console.Beep(1188, SoundLenght * 4);
            Console.Beep(1408, SoundLenght * 2);
            Console.Beep(1760, SoundLenght * 4);
            Console.Beep(1584, SoundLenght * 2);
            Console.Beep(1408, SoundLenght * 2);
            Console.Beep(1320, SoundLenght * 6);
            Console.Beep(1056, SoundLenght * 2);
            Console.Beep(1320, SoundLenght * 4);
            Console.Beep(1188, SoundLenght * 2);
            Console.Beep(1056, SoundLenght * 2);
            Console.Beep(990, SoundLenght * 4);
            Console.Beep(990, SoundLenght * 2);
            Console.Beep(1056, SoundLenght * 2);
            Console.Beep(1188, SoundLenght * 4);
            Console.Beep(1320, SoundLenght * 4);
            Console.Beep(1056, SoundLenght * 4);
            Console.Beep(880, SoundLenght * 4);
            Console.Beep(880, SoundLenght * 4);
            Thread.Sleep(SoundLenght * 4);
            Console.Beep(1320, SoundLenght * 4);
            Console.Beep(990, SoundLenght * 2);
            Console.Beep(1056, SoundLenght * 2);
            Console.Beep(1188, SoundLenght * 2);
            Console.Beep(1320, SoundLenght);
            Console.Beep(1188, SoundLenght);
            Console.Beep(1056, SoundLenght * 2);
            Console.Beep(990, SoundLenght * 2);
            Console.Beep(880, SoundLenght * 4);
            Console.Beep(880, SoundLenght * 2);
            Console.Beep(1056, SoundLenght * 2);
            Console.Beep(1320, SoundLenght * 4);
            Console.Beep(1188, SoundLenght * 2);
            Console.Beep(1056, SoundLenght * 2);
            Console.Beep(990, SoundLenght * 6);
            Console.Beep(1056, SoundLenght * 2);
            Console.Beep(1188, SoundLenght * 4);
            Console.Beep(1320, SoundLenght * 4);
            Console.Beep(1056, SoundLenght * 4);
            Console.Beep(880, SoundLenght * 4);
            Console.Beep(880, SoundLenght * 4);
            Thread.Sleep(SoundLenght * 2);
            Console.Beep(1188, SoundLenght * 4);
            Console.Beep(1408, SoundLenght * 2);
            Console.Beep(1760, SoundLenght * 4);
            Console.Beep(1584, SoundLenght * 2);
            Console.Beep(1408, SoundLenght * 2);
            Console.Beep(1320, SoundLenght * 6);
            Console.Beep(1056, SoundLenght * 2);
            Console.Beep(1320, SoundLenght * 4);
            Console.Beep(1188, SoundLenght * 2);
            Console.Beep(1056, SoundLenght * 2);
            Console.Beep(990, SoundLenght * 4);
            Console.Beep(990, SoundLenght * 2);
            Console.Beep(1056, SoundLenght * 2);
            Console.Beep(1188, SoundLenght * 4);
            Console.Beep(1320, SoundLenght * 4);
            Console.Beep(1056, SoundLenght * 4);
            Console.Beep(880, SoundLenght * 4);
            Console.Beep(880, SoundLenght * 4);
            Thread.Sleep(SoundLenght * 4);
            Console.Beep(660, SoundLenght * 8);
            Console.Beep(528, SoundLenght * 8);
            Console.Beep(594, SoundLenght * 8);
            Console.Beep(495, SoundLenght * 8);
            Console.Beep(528, SoundLenght * 8);
            Console.Beep(440, SoundLenght * 8);
            Console.Beep(419, SoundLenght * 8);
            Console.Beep(495, SoundLenght * 8);
            Console.Beep(660, SoundLenght * 8);
            Console.Beep(528, SoundLenght * 8);
            Console.Beep(594, SoundLenght * 8);
            Console.Beep(495, SoundLenght * 8);
            Console.Beep(528, SoundLenght * 4);
            Console.Beep(660, SoundLenght * 4);
            Console.Beep(880, SoundLenght * 8);
            Console.Beep(838, SoundLenght * 16);
            Console.Beep(660, SoundLenght * 8);
            Console.Beep(528, SoundLenght * 8);
            Console.Beep(594, SoundLenght * 8);
            Console.Beep(495, SoundLenght * 8);
            Console.Beep(528, SoundLenght * 8);
            Console.Beep(440, SoundLenght * 8);
            Console.Beep(419, SoundLenght * 8);
            Console.Beep(495, SoundLenght * 8);
            Console.Beep(660, SoundLenght * 8);
            Console.Beep(528, SoundLenght * 8);
            Console.Beep(594, SoundLenght * 8);
            Console.Beep(495, SoundLenght * 8);
            Console.Beep(528, SoundLenght * 4);
            Console.Beep(660, SoundLenght * 4);
            Console.Beep(880, SoundLenght * 8);
            Console.Beep(838, SoundLenght * 16);
        }
    }
}
