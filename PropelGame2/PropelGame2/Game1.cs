using menuTest;
using propelGameMain;
using System;
using static System.Console;

namespace Game1Main
{
    class Game1TestClass
    {
        public void startGame1()
        {
            testGame1();
        }

        public void testGame1()
        {
            MainGame game = new MainGame();
            Clear();
            MenuUI.RenderBoard();
            bool started = true;
            while(started == true)
            {
                Write("test");
                Thread.Sleep(500);
            }
        }
    }
}
