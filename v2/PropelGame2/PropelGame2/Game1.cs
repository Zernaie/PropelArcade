using menuTest;
using System.Runtime.CompilerServices;
using System.Threading;
using static System.Console;

namespace Game1
{   
    class MapParser
    {
        public static string[,] ConvertToArray(string FileToConvert)
        {
            string[] lines = File.ReadAllLines(FileToConvert);
            string firstLine = lines[0];
            int Rows = lines.Length;
            int Collumns = firstLine.Length;
            string[,] grid = new string[Rows, Collumns];

            for (int y = 0; y < Rows; y++)
            {
                string line = lines[y];
                for (int x = 0; x < Collumns; x++)
                {
                    char currentChar = line[x];
                    grid[y, x] = currentChar.ToString();
                }       
            }
            return grid;        
        }   
    }
    class Game1Main
    {
        private Game1World MyWorld;
        private Game1Player CurrentPlayer;
        public void DrawBoard()
            // grid for creating the map and player movement
        {   
            string[,] grid = MapParser.ConvertToArray("Game1map.txt");
            MyWorld = new Game1World(grid);
            CurrentPlayer = new Game1Player(ConsoleColor.Blue, 30, 41);
            //  CurrentPlayer = new Game1Player(ConsoleColor.Red, 5, 5);
        }
        // redraw and update all the visuals
        private void DrawFrame()
        {
            //MenuUI.RenderBoard();
            MyWorld.draw();
            CurrentPlayer.draw();
        }

        private void PlayerControls(int plrNum)
        {   
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch(plrNum)
            {
                case 0:
                    switch (key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (MyWorld.CollDetect(CurrentPlayer.x - 1, CurrentPlayer.y))
                            {
                                CurrentPlayer.x -= 1;
                            }
                            break;

                        case ConsoleKey.RightArrow:
                            if (MyWorld.CollDetect(CurrentPlayer.x + 1, CurrentPlayer.y))
                            {
                                CurrentPlayer.x += 1;
                            }
                            break;

                        case ConsoleKey.UpArrow:
                            if (MyWorld.CollDetect(CurrentPlayer.x, CurrentPlayer.y - 1))
                            {
                                CurrentPlayer.y -= 1;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (MyWorld.CollDetect(CurrentPlayer.x, CurrentPlayer.y + 1))
                            {
                                CurrentPlayer.y += 1;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case 1:
                    break;
            }
        }

        // main game loop for running everything
        private void GameLoop()
        {
            while (true)
            {
                PlayerControls(0);
                DrawFrame();
            }
        }

        // start everything related to the game
        public void GameStart()
        {
            //ArcadeMain game = new ArcadeMain();
            MenuUI.RenderBoard();
            DrawBoard();
            DrawFrame();
            GameLoop();
        }
    }
    public class Game1World
    {
        // define variables to be used
        private string[,] Grid;
        public static int GridX;
        public static int GridY;
        private int Rows;
        private int Collumns;

        public Game1World(string[,] grid)
        {
            // assign variables values
            Grid = grid;    
            GridX = 3;
            GridY = 2;
            Rows = grid.GetLength(0);
            Collumns = grid.GetLength(1);
        }

        // use grid to draw the map
        public void draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Collumns; x++)
                    {
                    string GridChar = Grid[y, x];
                    SetCursorPosition(x+GridX, y+GridY);
                    Write(GridChar);
                }
            }
        }
        // method to detect collision for player movement
        public bool CollDetect(int x, int y)
        {
            // detects if outside the grid or if touching a grid character
            if (x < 0 || y < 0 || x >= Collumns || y >= Rows)
            {
                return false; 
            }
            return Grid[y, x] == " ";
        }
    }

    public class Game1Player
    {
        public int x { get; set; }
        public int y { get; set; }  
        private ConsoleColor PlayerColor;
        private string PlayerMarker;

        public Game1Player(ConsoleColor Color, int initialX, int initialY)
        {
            x = initialX;   
            y = initialY;
            PlayerMarker = "@";
            PlayerColor = Color;
        }

        public void draw()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(Game1World.GridX+x,Game1World.GridY+y);
            Write(PlayerMarker);
            ResetColor();
        }

    }
}
