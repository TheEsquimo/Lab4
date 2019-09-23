using System;

namespace Lab4
{
    class Program
    {
        static char[,] charMap = new char[,]
        {
            {'#', '#', '#', '#', '#', '#', '#' },
            {'#', 'K', '#', 'E', '.', '$', '#' },
            {'#', '.', '.', '#', 'D', '#', '#' },
            {'#', 'k', '@', 'T', '.', '$', '#' },
            {'#', '.', 'S', '$', 'K', '$', '#' },
            {'#', '#', '#', '#', '#', '#', '#' }
        };
       
        const int playerMoves = 30;
        static LevelMap level = new LevelMap();

        static void Main(string[] args)
        {
            Player player = new Player(playerMoves);
            while (true)
            {
                if (GameController.CurrentState == GameController.GameState.Start)
                {
                    player = new Player(playerMoves);
                    level.MapGeneration(charMap, player);
                    player.UpdateVision(level);
                    GameController.StartScreen();
                }
                else if (GameController.CurrentState == GameController.GameState.Play)
                {
                    level.PrintMap();
                    player.DisplayStats();
                    char userInput = Console.ReadKey().KeyChar;
                    player.Move(userInput, level);
                    Console.Clear();
                    if (player.MovesLeft < 1) { GameController.CurrentState = GameController.GameState.End; }
                }
                else
                {
                    GameController.EndScreen(player);
                }
            }
        }
    }
}