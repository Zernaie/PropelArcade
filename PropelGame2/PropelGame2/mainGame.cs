using Game1Main;
using menuTest;
using System;
using System.Security.Cryptography.X509Certificates;
using static System.Console;

namespace propelGameMain 
{
    class ArcadeMain
    {
        public void StartGame()
        {
            RunMainMenu();
        }

        public void RunMainMenu()
        {
            Clear();
            string prompt = "Select a option (arrows+enter)";
            string[] options = {"    Game 1    ", "    Test 1    ", "    Test 2    ", "     Exit     "};
            MenuUI mainMenu = new MenuUI(prompt, options);
            int selectedIndex = mainMenu.runMenu();

            SetCursorPosition(30, 15);

            switch (selectedIndex)
            {
                case 0:
                    Game1();    
                    break;
                case 1:
                    Game2();
                    break;
                case 2:
                    Game3();
                    break;
                case 3:
                    ExitMenu();
                    break;
                default:
                    RunMainMenu();
                    break;
            }
        }

        private void Game1()
        {
            Game1TestClass game1TestClass = new Game1TestClass();
            game1TestClass.startGame1();
        }
        private void Game2()
        {
            WriteLine("there is no game yet.");
            ReadKey();
            RunMainMenu();
        }
        private void Game3()
        {
            WriteLine("there is no game yet.");
            ReadKey();
            RunMainMenu();
        }

        private void ExitMenu()
        {
            Environment.Exit(0);
        }

    }

    class main
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 70;
            Console.WindowHeight = 30;
            Console.BufferWidth = 70;
            Console.BufferHeight = 30;
            Clear();
            SetCursorPosition(0, 0);
            ArcadeMain game = new ArcadeMain();
            game.StartGame();
        }
    }
}