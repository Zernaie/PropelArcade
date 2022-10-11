using static System.Console;
using MainGame;
using Player;
using System;

namespace World
{
    public class MapParser
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
    public class WorldClass 
    {
        // define variables to be used
        public string[,] Grid;
        public static int GridX;
        public static int GridY;
        public int Rows;
        public int Columns;
        public WorldClass(string[,] grid)
        {
            // assign variables values
            Grid = grid;
            GridX = 15;
            GridY = 1;
            Rows = grid.GetLength(0);
            Columns = grid.GetLength(1);
        }
        // MAKE THIS run once and put in a string idk how   
        public void CreateWorldGrid()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    string GridChar = Grid[y, x];
                    SetCursorPosition(x + GridX, y + GridY);
                    Write(GridChar);
                }
            }
        }
        public bool CollDetect(int x, int y, int PlrId)
        {
            // detects if outside the grid or if touching a grid character
            if (x < 0 || y < 0 || x >= Columns || y >= Rows)
            {
                return false;
            }
            return Grid[y, x] == " ";
        }
    }
    public class CreateWorld
    {
        public void CreateWorldMap()
        {
            string[,] grid = MapParser.ConvertToArray("testmap.txt");
            WorldClass world = new WorldClass(grid);
            world.CreateWorldGrid();
        }
    }
}
