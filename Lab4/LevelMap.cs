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
                    //Switch that makes objects based on characters
                    switch (charMap[row, column])
                    {
                        case '#':

                            break;

                        case '.':

                            break;

                        case 'k':

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