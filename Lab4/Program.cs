using System;

namespace Lab4
{
    class Program
    {
        static char[,] charMap = new char[,]
        {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#',},
            {'#', 'k', '#', '$', '$', 'K', '#', '$', '$', '$', 'D', '$', '#', 'E', '#', '#',},
            {'#', '.', '.', '#', 'D', '#', '#', '#', '$', '$', '#', '$', 'T', 'T', 'T', '#',},
            {'#', 'M', '.', '@', '.', 'M', 'D', '.', 'D', 'W', '#', '$', 'T', 'S', 'T', '#',},
            {'#', '$', '#', 'W', '.', '.', '#', '.', '#', '#', '#', '.', 'T', '.', 'T', '#',},
            {'#', 'D', '#', '#', '#', '#', '#', '.', 'D', 'M', '#', '.', '.', '$', '.', '#',},
            {'#', '$', '$', '$', '.', '$', '.', '.', '#', '$', '#', '.', '.', '.', '.', '#',},
            {'#', 'S', 'T', '.', '$', '.', '$', 'k', '$', '#', '#', '#', 'D', '#', 'M', '#',},
            {'#', 'T', '#', '#', '#', '#', '#', '#', '$', '.', '.', 'D', '$', '#', '.', '#',},
            {'#', 'C', '$', '#', '$', 'W', '$', 'M', '$', '$', '$', '.', '#', '#', '$', '#',},
            {'#', '$', '$', 'D', 'M', '$', '.', 'M', '.', '.', '.', '.', 'M', '$', 'K', '#',},
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#',}
        };
       
        const int playerMoves = 300;
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
                else if (GameController.CurrentState == GameController.GameState.End)
                {
                    GameController.EndScreen(player);
                }
            }
        }
    }
}