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
        public int x { get; set; }
        public int y { get; set; }
        public int Px { get; set; }
        public int Py { get; set; }
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
        public void DeleteLastPos(int Px, int Py)
        {
            SetCursorPosition(Px + WorldClass.GridX, Py + WorldClass.GridY);
            Write(" ");
        }
        // create a new player
        public void CreatePlayer(int startX, int StartY, ConsoleColor plrColor, int Playerid)
        {
            // set players initial starting position
            MyWorld = new WorldClass(grid);
            SetPlayerPos(startX, StartY, plrColor);
            x = startX;
            y = StartY;
            PlayerColor = plrColor;
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

        public void PosManipulate(int _x,int _y)
        {
            isKeyPress = true;
            if (MyWorld.CollDetect(x + _x, y + _y))
            {
                Px = x;
                Py = y;

                x += _x;
                y += _y;
                DrawFrame();
                DeleteLastPos(Px,Py);
            }
        }

        public void PlayerControls(int PlrId)
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;

            if (isKeyPress)
            {
                Thread.Sleep(20);
            }

            switch (PlrId)
            {
                case 0:
                    switch (key)
                    {
                        case ConsoleKey.LeftArrow:
                            PosManipulate(-1, 0);
                            break;
                        case ConsoleKey.RightArrow:
                            PosManipulate(1, 0);
                            break;

                        case ConsoleKey.UpArrow:
                            PosManipulate(0, -1);
                            break; 

                        case ConsoleKey.DownArrow:
                            PosManipulate(0, +1);
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
