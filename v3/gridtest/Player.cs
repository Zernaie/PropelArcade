using static System.Console;
using World;
using MainGame;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Player
{
    public class PlayerClass
    {
        public WorldClass MyWorld;
        public MapParser ParsedGrid;
        private int x  { get; set; }
        private int y  { get; set; }
        private int Lx { get; set; }
        private int Ly { get; set; }
        public string plrChar;
        public int Playerid;
        public ConsoleColor PlayerColor;
        public string[,] Grid;
        public bool isKeyPress = false;
        public string[,] grid = MapParser.ConvertToArray("testmap.txt");
        public PlayerClass()
        {
            plrChar = "@";
        }

        public void SetPlayerPos(int x, int y, ConsoleColor plrColor)
        {
            ForegroundColor = plrColor;
            SetCursorPosition(x + WorldClass.GridX, y + WorldClass.GridY);
            Write(plrChar);
            ResetColor();
        }

        public void DeleteLastPos(int Lx, int Ly, int Playerid)
        {
            SetCursorPosition(Lx + WorldClass.GridX, Ly + WorldClass.GridY);
            Write(" ");
        }

        // create a new player
        public void CreatePlayer(int startX, int StartY, ConsoleColor plrColor, int Playerid)
        {
            // set players initial starting position
            ResetColor();
            PlayerColor = plrColor;
            MyWorld = new WorldClass(grid);
            SetPlayerPos(startX, StartY, plrColor);
            x = startX;
            y = StartY;
            bool alive = true;

            while (alive == true)
            {
                PlayerControls(Playerid);
                //Write($"{x} {y}");
            }
        }

        public void DrawFrame()
        {
            /* removed because I added dellastpos
             MyWorld.CreateWorldGrid();*/
            SetPlayerPos(x, y, PlayerColor);
        }

        public void PosManipulate(int _x,int _y, int Playerid)
        {
            isKeyPress = true;
            if (MyWorld.CollDetect(x + _x, y + _y, Playerid))
            {
                Lx = x;
                Ly = y;

                x += _x;
                y += _y;
                DrawFrame();
                DeleteLastPos(Lx,Ly,Playerid);
            }
        }

        public void PlayerControls(int Playerid)
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;

            /*if (isKeyPress)
            {
                Thread.Sleep(20);
            }*/

            switch (Playerid)
            {
                case 0:
                    switch (key)
                    {
                        case ConsoleKey.LeftArrow:
                            PosManipulate(-1, 0, Playerid);
                            break;
                        case ConsoleKey.RightArrow:
                            PosManipulate(1, 0, Playerid);
                            break;

                        case ConsoleKey.UpArrow:
                            PosManipulate(0, -1, Playerid);
                            break; 

                        case ConsoleKey.DownArrow:
                            PosManipulate(0, +1, Playerid);
                            break;
                        default:
                            isKeyPress = false;
                            break;
                    }
                    break;
                case 1:
                    switch (key)
                    {
                        case ConsoleKey.A:
                            PosManipulate(-1, 0, Playerid);
                            break;
                        case ConsoleKey.D:
                            PosManipulate(1, 0, Playerid);
                            break;

                        case ConsoleKey.W:
                            PosManipulate(0, -1, Playerid);
                            break;

                        case ConsoleKey.S:
                            PosManipulate(0, +1, Playerid);
                            break;
                        default:
                            isKeyPress = false;
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
