using World;
using Player;
using static System.Console;
using System.Threading;

namespace MainGame
{
    class MainClass
    {
        static void Main(string[] args)
        {
            SetWindowSize(100, 50);
            SetBufferSize(100, 50);
            StartGame();
        }

        static void StartGame()
        {
            CursorVisible = false;
            CreateWorld world = new CreateWorld();
            world.CreateWorldMap();
            PlayerClass player = new PlayerClass();
            player.CreatePlayer(10, 20, ConsoleColor.Cyan, 0);
            //player.CreatePlayer(19, 19, ConsoleColor.Red, 0);
            GameLoop();
            
        }
        static void GameLoop()
        {

        }
    }
}