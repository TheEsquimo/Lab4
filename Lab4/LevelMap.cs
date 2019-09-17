namespace Lab4
{
    class LevelMap
    {
        public static char[,] charMap = new char[,]
        {
                {'#', '#', '#', '#', '#', '#' },
                {'#', '.', '.', '.', '.', '#' },
                {'#', '.', '@', '#', '.', '#' },
                {'#', '.', '.', '.', '.', '#' },
                {'#', '#', '#', '#', '#', '.' },
        };

        public static MapTile[,] levelMap;

        public void MapGeneration(char[,] charMap)
        {
            int mapSizeX = charMap.GetLength(0);
            int mapSizeY = charMap.GetLength(1);
            levelMap = new MapTile[mapSizeX, mapSizeY];

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

                        case 'k':
                            generatedTile = new RoomTile();
                            generatedTile.Keys = 1; //Lös det här!
                            break;

                        case 'm':

                            break;

                        default:

                            break;
                    }
                }
            }
        }
    }
}