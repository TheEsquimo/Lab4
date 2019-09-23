using System;
using System.Collections.Generic;

namespace Lab4
{
    class Player
    {
        int playerPositionHorizontally;
        int playerPositionVertically;
        int movesLeft;
        int maxMoves;
        int keys = 0;
        public List<Item> inventory = new List<Item>();

        public Player(int moves = 1000)
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

                default:
                    Console.WriteLine("\nInvalid input");
                    Console.ReadKey();
                    return;
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
                        movesLeft--;
                        roomTile.Monster = false;
                    }
                }
                
                if (currentTile is DoorTile)
                {
                    if (!currentTile.Enterable)
                    {
                        //Chooses superkey over regular key if available in inventory
                        bool superKeyFound = false;
                        foreach (Item item in inventory)
                        {
                            if (item is Superkey)
                            {
                                superKeyFound = true;
                                IUsable superKey = (IUsable)item;
                                superKey.Use(inventory);
                                currentTile.Enterable = true;
                                break;
                            }
                        }
                        if (!superKeyFound && keys > 0)
                        {
                            keys--;
                            currentTile.Enterable = true;
                        }
                    }
                }

                UpdateVision(level);
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
                if (keys > 0) //CHANGE THIS TO NON-LINQ METHOD
                {
                    return true;
                }

                foreach (Item item in inventory)
                {
                    if (item is Superkey)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void UpdateVision(LevelMap level)
        {
            //Reveals tiles on and around player's current position
            level.Map[playerPositionVertically, playerPositionHorizontally].Visible = true;
            level.Map[playerPositionVertically - 1, playerPositionHorizontally].Visible = true;
            level.Map[playerPositionVertically + 1, playerPositionHorizontally].Visible = true;
            level.Map[playerPositionVertically, playerPositionHorizontally - 1].Visible = true;
            level.Map[playerPositionVertically, playerPositionHorizontally + 1].Visible = true;
            level.Map[playerPositionVertically - 1, playerPositionHorizontally - 1].Visible = true;
            level.Map[playerPositionVertically - 1, playerPositionHorizontally + 1].Visible = true;
            level.Map[playerPositionVertically + 1, playerPositionHorizontally - 1].Visible = true;
            level.Map[playerPositionVertically + 1, playerPositionHorizontally + 1].Visible = true;
        }

        public void DisplayStats()
        {
            System.Console.WriteLine("\nMoves left: " + movesLeft + 
                                     "\nKeys left: " + keys);
        }
    }
}