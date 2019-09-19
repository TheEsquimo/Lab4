namespace Lab4
{
    class Player
    {
        int playerPositionHorizontally;
        int playerPositionVertically;
        int movesLeft;
        int maxMoves;
        int keys = 0;

        public Player(int moves)
        {
            maxMoves = moves;
            movesLeft = maxMoves;
        }

        public int MovesLeft
        {
            get { return movesLeft; }
            set { movesLeft = value; }
        }

        public int PlayerPositionHorizontally
        {
            get { return playerPositionHorizontally; }
            set { playerPositionHorizontally = value; }
        }

        public int PlayerPositionVertically
        {
            get { return playerPositionVertically; }
            set { playerPositionVertically = value; }
        }

        public void Move(char userInput, LevelMap level)
        {
            // 1 = right/down 
            // -1 = left/up
            int horizontalDirection = 0;
            int verticalDirection = 0;

            switch (userInput)
            {
                case 'w':
                    verticalDirection = -1;
                    break;

                case 's':
                    verticalDirection = 1;
                    break;

                case 'a':
                    horizontalDirection = -1;
                    break;

                case 'd':
                    horizontalDirection = 1;
                    break;
            }

            if (CanMove(horizontalDirection, verticalDirection, level))
            {
                level.Map[playerPositionVertically, playerPositionHorizontally].PlayerOnTile = false;
                playerPositionHorizontally += horizontalDirection;
                playerPositionVertically += verticalDirection;
                MapTile currentTile = level.Map[playerPositionVertically, playerPositionHorizontally];
                currentTile.PlayerOnTile = true;
                movesLeft --;
                if(currentTile is RoomTile)
                {
                    RoomTile roomTile = (RoomTile)currentTile;
                    if(roomTile.Monster)
                    {
                        movesLeft--;
                        roomTile.Monster = false;
                    }
                }

                keys += currentTile.Keys;
                currentTile.Keys = 0;
                
                if (currentTile is DoorTile)
                {
                    if (keys > 0 && !currentTile.Enterable)
                    {
                        keys--;
                        currentTile.Enterable = true;
                    }
                }
            }
        }

        private bool CanMove(int horizontalDirection, int verticalDirection, LevelMap level)
        {
            MapTile tileToCheck = level.Map[playerPositionVertically + verticalDirection, playerPositionHorizontally + horizontalDirection];
            if (tileToCheck.Enterable)
            {
                return true;
            }
            else if (tileToCheck is DoorTile)
            {
                if (keys > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void DisplayStats()
        {
            System.Console.WriteLine("\nMoves left: " + movesLeft + 
                                     "\nKeys left: " + keys);
        }
    }
}