using menuTest;
using propelGameMain;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using static System.Console;

namespace Game1Main
{
    class Game1TestClass
    {
        public void startGame1()
        {
            testGame1();
        }
        

        public void setPlayerPos(int x,int y)
        {
            MenuUI.RenderBoard();
            SetCursorPosition(x, y);
            Write("@");
        }

        public void player(bool alive)
        {
            //int[] x = new int[50];
            //int[] y = new int[50];
            int x = 30;
            int y = 15;
            setPlayerPos(x, y);
            while(alive == true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.LeftArrow:
                        x--;
                        setPlayerPos(x, y);
                        break;

                    case ConsoleKey.RightArrow:
                        x++;
                        setPlayerPos(x, y);
                        break;

                    case ConsoleKey.UpArrow:
                        y--;
                        setPlayerPos(x, y);
                        break;

                    case ConsoleKey.DownArrow:
                        y++;
                        setPlayerPos(x, y);
                        break;

                    default:
                        break;
                }
            }
        }

        public void testGame1()
        {
            ArcadeMain game = new ArcadeMain();
            Clear();
            MenuUI.RenderBoard();
            player(true);
        }
    }
}
