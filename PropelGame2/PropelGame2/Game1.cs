using menuTest;
using propelGameMain;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
using System.Transactions;
using static System.Console;

namespace Game1
{
    class Game1Main
    {
        public void StartGame1()
        {
            testGame1();
        }
        
        public static void SetPlayerPos(int x,int y)
        {
            Clear();
            SetCursorPosition(x, y);
            Write("@");
        }
        public static void DrawBoard()
        {
            string[,] grid = {
            {"#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#",},
            {"#","","","","","","","","","","","","","","","","","","","","","#",},
            {"#","","","","","","","","","#","#","#","#","","","","","","","","","#",},
            {"#","","","","","","","","","#","#","","","","","","","","","","","#",},
            {"#","","","","","","","","","#","","","#","","","","","","","","","#",},
            {"#","","","","","","","","","","","#","#","","","","","","","","","#",},
            {"#","","","","","","","","","#","#","#","#","","","","","","","","","#",},
            {"#","","","","","","","","","","","","","","","","","","","","","#",},
            {"#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#",},
            };
            int rows = grid.GetLength(0);
            int collumns = grid.GetLength(1);
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < collumns; x++)
                {
                    string GridChar = grid[y, x];
                    SetCursorPosition(x+10, y+5);
                    Write(GridChar);
                }   
            }
        }
        
        public void Player(bool alive)
        {
            //int[] x = new int[50];
            //int[] y = new int[50];

            //setPlayerPos(x, y);
            while(alive == true)
            {
                
            }
        }

        public void testGame1()
        {
            //ArcadeMain game = new ArcadeMain();
            Clear();
            MenuUI.RenderBoard();
            DrawBoard();
            Player(true);
            ReadKey();
        }
    }
    class Game1World
    {

    }
}
