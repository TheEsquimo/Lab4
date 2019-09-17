using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] charMap = new char[,]
            {
                {'K', '#', '#', '#', '#', '#' },
                {'#', '.', '#', 'E', '.', '#' },
                {'#', '.', '@', '#', 'D', '#' },
                {'#', '.', '.', '.', '.', '#' },
                {'#', '.', '.', '.', '.', '#' },
                {'#', '#', '#', '#', '#', '#' }
            };

            LevelMap level = new LevelMap();
            level.MapGeneration(charMap);

            RoomTile roomTile = (RoomTile)level.Map[0, 0];
            Console.WriteLine("Keys in room: " + roomTile.Keys);

            //Show map as object types
            for (int row = 0; row < level.Map.GetLength(0); row++)
            {
                for (int column = 0; column < level.Map.GetLength(1); column++)
                {
                    Console.Write(level.Map[row, column].GetType() + " ");
                }
                Console.WriteLine();
            }

            //Show map as chars
            for (int row = 0; row < charMap.GetLength(0); row++)
            {
                for (int column = 0; column < charMap.GetLength(1); column++)
                {
                    Console.Write(charMap[row, column]);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}