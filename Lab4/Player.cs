namespace Lab4
{
    class Player
    {
        int playerPositionX;
        int playerPositionY;
        //List<Item> inventory = new List<Item>(); //Can't make list right now

        public Player(int startPositionX, int startPositionY)
        {
            playerPositionX = startPositionX;
            playerPositionY = startPositionY;
        }

        public int PlayerPositionX
        {
            get { return playerPositionX; }
            set { playerPositionX = value; }
        }

        public int PlayerPositionY
        {
            get { return playerPositionY; }
            set { playerPositionY = value; }
        }
    }
}