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
            //Game Loop
            while (true)
            {
                Player player = new Player(playerMoves);
                level.MapGeneration(charMap, player);
                player.UpdateVision(level);

                /*
                //Print map as object types
                for (int row = 0; row < level.Map.GetLength(0); row++)
                {
                    for (int column = 0; column < level.Map.GetLength(1); column++)
                    {
                        Console.Write(level.Map[row, column].GetType() + " ");
                    }
                    Console.WriteLine();
                }
                */

                while (player.MovesLeft > 0)
                {
                    Console.WriteLine(GameController.TilesExplanationMessage);
                    level.PrintMap();
                    player.DisplayStats();

                    char userInput = Console.ReadKey().KeyChar;
                    player.Move(userInput, level);
                    Console.Clear();
                }

                Console.Clear();

                Console.WriteLine(GameController.EndMessage);
                Console.ReadKey();
            }

            /*
            //Print map as chars
            for (int row = 0; row < charMap.GetLength(0); row++)
            {
                for (int column = 0; column < charMap.GetLength(1); column++)
                {
                    Console.Write(charMap[row, column]);
                }
                Console.WriteLine();
            }
            */
        }
    }
}