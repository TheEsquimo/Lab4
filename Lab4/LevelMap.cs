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
        }
    }
}