using System;

namespace Lab4
{
    class Player
    {
        int playerPositionHorizontally;
        int playerPositionVertically;
        int movesLeft;
        int maxMoves;
        int keys = 0;
        const string name = "TrueGuy";

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

                keys += currentTile.Keys;
                currentTile.Keys = 0;

                if (currentTile is RoomTile)
                {
                    RoomTile roomTile = (RoomTile)currentTile;
                    if(roomTile.Monster)
                    {
                        roomTile.Monster = false;
                        movesLeft--;
                        Console.ReadKey();
                    }
                    else if(roomTile.Trap)
                    {
                        Console.WriteLine($"\n{name}: 'You're making me me walk on a trap, it costs me 1 extra move! Silly willy...'");
                        movesLeft--;
                        Console.ReadKey();
                    }
                    else if (roomTile.TrapSwitch)
                    {
                        DestroyTraps(level);
                    }
                }
                
                if (currentTile is DoorTile)
                {
                    if (keys > 0 && !currentTile.Enterable)
                    {
                        keys--;
                        currentTile.Enterable = true;
                    }
                }

                UpdateVision(level);
            }
        }

        public void UpdateVision(LevelMap level)
        {
            //Reveals tiles on and around player's current position

            for (int column = playerPositionVertically - 1; column <= playerPositionVertically + 1; column++)
            {
                for(int row = playerPositionHorizontally - 1; row <= playerPositionHorizontally + 1; row++)
                {
                    level.Map[column, row].Visible = true;
                }
            }
        }

        public void DestroyTraps(LevelMap level)
        {
            for (int column = playerPositionVertically - 1; column <= playerPositionVertically + 1; column++)
            {
                for (int row = playerPositionHorizontally - 1; row <= playerPositionHorizontally + 1; row++)
                {
                    if (level.Map[column, row] is RoomTile)
                    {
                        RoomTile roomTile = (RoomTile)level.Map[column, row];
                        roomTile.Trap = false;
                    }
                }
            }
            RoomTile currentRoomTile = (RoomTile)level.Map[playerPositionVertically, playerPositionHorizontally];
            currentRoomTile.TrapSwitch = false;
            Console.WriteLine($"{name}: I've destroyed all the nearby traps with this hidden switch that I just found");
            Console.ReadKey();
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