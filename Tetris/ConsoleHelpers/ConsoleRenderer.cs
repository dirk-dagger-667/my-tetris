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
            Console.Title = "My Tetris";
            Console.WindowWidth = fullGameWidth;
            Console.BufferWidth = fullGameWidth;
            Console.WindowHeight = fullGameHeight + 1;
            Console.BufferHeight = fullGameHeight + 1;
        }

        public static void DrawInfoPanel(int playGroundWidth, IFigure nextShape, int infoPanelWidth, int score, int level)
        {
            Console.ForegroundColor = ConsoleColor.White;

            DrawOnPosition(1, playGroundWidth + 4, "   Next:");

            for (int i = 2; i <= 5; i++)
            {
                DrawOnPosition(i, playGroundWidth + 2, "            ");
            }

            DrawFigure(nextShape, 2, playGroundWidth + 9);

            DrawOnPosition(9, playGroundWidth + 4, "   Score:");
            int scoreStartposition = ((infoPanelWidth / 2) - (score.ToString().Length - 1)) / 2;
            scoreStartposition = scoreStartposition + playGroundWidth + 2;
            DrawOnPosition(10, scoreStartposition - 1, score);

            DrawOnPosition(11, playGroundWidth + 4, "   Level:");
            DrawOnPosition(12, playGroundWidth + 10, level);

            DrawOnPosition(13, playGroundWidth + 3, "    Controls:");
            DrawOnPosition(14, playGroundWidth + 2, "  ^ - rotate right");
            DrawOnPosition(15, playGroundWidth + 2, "  < - move left");
            DrawOnPosition(16, playGroundWidth + 2, "  > - move right");
            DrawOnPosition(17, playGroundWidth + 2, "  v - move down");
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
            var gameOverString = string.Format(@"
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

            DrawOnPosition(
                1, 
                1, 
            gameOverString);
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
