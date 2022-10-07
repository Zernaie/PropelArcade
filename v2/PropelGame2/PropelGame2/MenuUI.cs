using System;
using System.Net.NetworkInformation;
using System.Text;
using static System.Console;
namespace menuTest
{   
    class MenuUI
    {
        private int selectedIndex;
        private string[] Options;
        private string Prompt;

        public MenuUI(string prompt, string[] options)
        {
            selectedIndex = 0;
            Options = options;
            Prompt = prompt;
        }

        public static void RenderBoard()
        {
            int width = (Console.BufferWidth - 3);
            int height = (Console.BufferHeight - 3);
 
            for (int i = 1; i <= (width + 2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("#");
            }
            for (int i = 1; i <= (width + 2); i++)
            {
                Console.SetCursorPosition(i, (height + 2));
                Console.Write("#");
            }
            for (int i = 1; i <= (height + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("#");
            }
            for (int i = 1; i <= (height + 1); i++)
            {
                Console.SetCursorPosition((width + 2), i);
                Console.Write("#");
            }
            Console.CursorVisible = false;
        }

        private void DisplayOptions()
        {
            int baseLeft = 6;
            //int baseTop = 4;
            for(int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                if (i == selectedIndex)
                {
                    prefix = ">";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                SetCursorPosition(baseLeft, 5 + (i*4));
                WriteLine("   /                \\ ");
                SetCursorPosition(baseLeft, 6 + (i*4));
                WriteLine($" {prefix} | {currentOption} | ");
                SetCursorPosition(baseLeft, 7 + (i*4));
                WriteLine("   \\                / ");
                SetCursorPosition(baseLeft, 8 + (i*4));
            }   
            ResetColor();
            WriteLine("                      ");
        }

        public int runMenu()
        {
            ConsoleKey keyPressed;
            do
            {
                SetCursorPosition(0, 0);
                RenderBoard();
                DisplayOptions();
                SetCursorPosition(4, 3);
                WriteLine(Prompt);

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--; 
                    if(selectedIndex == -1)
                    {
                        selectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == Options.Length)
                    {
                        selectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);
            return selectedIndex;
        }
    }
}