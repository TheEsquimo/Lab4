using System;

namespace Lab4
{
    class LevelMap
    {
        private MapTile[,] map;

        public MapTile[,] Map
        {
            get { return map; }
        }

        public void MapGeneration(char[,] charMap, Player player)
        {
            //Creates MapTile objects and stores them in 2D array based on chars in parameter 2D array
            int mapSizeY = charMap.GetLength(0);
            int mapSizeX = charMap.GetLength(1);
            map = new MapTile[mapSizeY, mapSizeX];

            for (int row = 0; row < mapSizeY; row++)
            {
                for (int column = 0; column < mapSizeX; column++)
                {
                    MapTile generatedTile;
                    switch (charMap[row, column])
                    {
                        case '#':
                            generatedTile = new WallTile();
                            break;

                        case '.':
                            generatedTile = new RoomTile();
                            break;

                        case '@':
                            generatedTile = new RoomTile();
                            generatedTile.PlayerOnTile = true;
                            player.PlayerPositionHorizontally = column;
                            player.PlayerPositionVertically = row;
                            break;

                        case 'D':
                            generatedTile = new DoorTile();
                            break;

                        case 'E':
                            RoomTile roomExit = new RoomTile();
                            roomExit.Exit = true;
                            generatedTile = roomExit;
                            break;

                        case 'K':
                            RoomTile roomWithKey = new RoomTile();
                            roomWithKey.Keys = 1;
                            generatedTile = roomWithKey;
                            break;

                        case 'M':
                            RoomTile roomWithMonster = new RoomTile();
                            roomWithMonster.Monster = true;
                            generatedTile = roomWithMonster;
                            break;

                        default:
                            generatedTile = new RoomTile();
                            break;
                    }

                    map[row, column] = generatedTile;
                }
            }
        }

        public void PrintMap()
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int column = 0; column < map.GetLength(1); column++)
                {
                     Console.Write(map[row, column].VisualRepresentationSymbol);
                }
                Console.WriteLine();
            }
        }
    }
}