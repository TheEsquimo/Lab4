using System;

namespace Lab4
{
    class Program
    {
        /*
        public static int playerPosX = 2;
        public static int playerPosY = 2;

        public static char[,] worldMap = new char[,]
        {
                {'#', '#', '#', '#', '#', '#' },
                {'#', '.', '.', '.', '.', '#' },
                {'#', '.', '@', '#', '.', '#' },
                {'#', '.', '.', '.', '.', '#' },
                {'#', '#', '#', '#', '#', '.' },
        };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine($"X: {playerPosX}");
                Console.WriteLine($"Y: {playerPosY}");

                //Display map
                for (int row = 0; row < worldMap.GetLength(0); row++)
                {
                    for (int column = 0; column < worldMap.GetLength(1); column++)
                    {
                        Console.Write(worldMap[row, column]);
                    }
                    Console.WriteLine();
                }

                //Player movement
                TryPlayerMove();
            }
        }

        private static void MovePlayer(string input)
        {
            worldMap[playerPosY, playerPosX] = '.';

            switch (input)
            {
                case "w":
                    --playerPosY;
                    break;

                case "a":
                    --playerPosX;
                    break;

                case "s":
                    ++playerPosY;
                    break;

                case "d":
                    ++playerPosX;
                    break;

                default:
                    Console.WriteLine("Invalid input. How did it pass the TryPlayerMove?");
                    break;
            }

            worldMap[playerPosY, playerPosX] = '@';
        }

        private static void TryPlayerMove()
        {
            string userInput = "";
            userInput = Console.ReadLine();
            userInput = userInput.ToLower();
            switch (userInput)
            {
                case "w":
                    if (worldMap[playerPosY, playerPosX - 1] == '#') { return; }
                    else { MovePlayer(userInput); }
                    break;

                case "a":
                    if (worldMap[playerPosY - 1, playerPosX] == '#') { return; }
                    else { MovePlayer(userInput); }
                    break;

                case "s":
                    if (worldMap[playerPosY, playerPosX + 1] == '#') { return; }
                    else { MovePlayer(userInput); }
                    break;

                case "d":
                    if (worldMap[playerPosY + 1, playerPosX] == '#') { return; }
                    else { MovePlayer(userInput); }
                    break;

                default:
                    Console.WriteLine("Invalid input, try again");
                    TryPlayerMove();
                    break;
            }
        }
        */
    }
}