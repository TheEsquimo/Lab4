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

        }
    }
}