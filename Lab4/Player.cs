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
            // 1 = right/up 
            // -1 = left/down
            int checkHorizontal = 0;
            int checkVertical = 0;

            switch (userInput)
            {
                case "w":
                    checkVertical = 1;
                    break;

                case "s":
                    checkVertical = -1;
                    break;

                case "a":
                    checkHorizontal = -1;
                    break;

                case "d":
                    checkHorizontal = 1;
                    break;
            }

            if (CanMove(checkHorizontal, checkVertical))
            {

            }
        }

        private bool CanMove(int horizontalDirection, int verticalDirection)
        {

            return false;
        }
    }
}