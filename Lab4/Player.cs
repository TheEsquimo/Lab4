namespace Lab4
{
    class Player
    {
        int playerPositionX;
        int playerPositionY;
        int movesLeft;
        int maxMoves;
        //List<Item> inventory = new List<Item>(); //Can't make list right now

        public Player(int moves)
        {
            maxMoves = moves;
            movesLeft = maxMoves;
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

        public void Move(string userInput)
        {
            if (CanMove(userInput))
            {

            }
        }

        private bool CanMove(string userInput)
        {
            return false;
        }
    }
}