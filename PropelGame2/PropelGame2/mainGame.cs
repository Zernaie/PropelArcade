using menuTest;
using System;
using System.Security.Cryptography.X509Certificates;
using static System.Console;

namespace propelGameMain 
{
    class startMainGame
    {
        public void StartGame()
        {
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            Clear();
            string prompt = "Select a option (arrows+enter)";
            string[] options = { "    Game 1    ", "    Test 1    ", "    Test 2    ", "     Exit     " };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.runMenu();

            SetCursorPosition(4, 12);
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
            WriteLine("there is no game yet.");
            ReadKey();
            RunMainMenu();
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
           
            Console.WindowWidth = 100;
            Console.WindowHeight = 30;
            Console.BufferWidth = 100;
            Console.BufferHeight = 30;

            startMainGame gameTest = new startMainGame();
            gameTest.StartGame();
        }
    }
}