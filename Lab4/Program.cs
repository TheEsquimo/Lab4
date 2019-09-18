using System;

namespace Lab4
{
    class Program
    {
        static char[,] charMap = new char[,]
        {
            {'#', '#', '#', '#', '#', '#', '#' },
            {'#', 'K', '#', 'E', '.', '.', '#' },
            {'#', '.', '@', '#', 'D', '#', '#' },
            {'#', '.', '.', '.', '.', '.', '#' },
            {'#', '.', '.', '.', '.', '.', '#' },
            {'#', '#', '#', '#', '#', '#', '#' }
        };

        const int playerMoves = 10;
        static Player player = new Player(playerMoves);
        static LevelMap level = new LevelMap();

        static void Main(string[] args)
        {
            level.MapGeneration(charMap, player);

            //Checks that MapGeneration works correctly
            RoomTile roomTile = (RoomTile)level.Map[1, 1];
            Console.WriteLine("Keys in room: " + roomTile.Keys);

            //Print map as object types
            for (int row = 0; row < level.Map.GetLength(0); row++)
            {
                for (int column = 0; column < level.Map.GetLength(1); column++)
                {
                    Console.Write(level.Map[row, column].GetType() + " ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();

            while (true)
            {
                Console.Clear();
                level.PrintMap();

                char userInput = Console.ReadKey().KeyChar;
                player.Move(userInput, level);
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