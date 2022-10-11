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
            Thread player1 = new Thread(() => player.CreatePlayer(10,20, ConsoleColor.Cyan,0));
            player1.Start();
            Thread player2 = new Thread(() => player.CreatePlayer(11, 20, ConsoleColor.Red, 1));
            player2.Start();

            //player.CreatePlayer(20, 10, ConsoleColor.Red, 1);
            //player.CreatePlayer(19, 19, ConsoleColor.Red, 0);
            GameLoop();
            
        }
        static void GameLoop()
        {

        }
    }
}