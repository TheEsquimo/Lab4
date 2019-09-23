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

        const string name = "TrueGuy";
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
                    Console.WriteLine($"\n{name}: Yo, my dude. You need to press the right keys and stuff...");
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
                        roomTile.Monster = false;
                        movesLeft--;
                        Console.ReadKey();
                    }
                    else if(roomTile.Trap)
                    {
                        Console.WriteLine($"\n{name}: 'Uh-oh, I have walked upon a spooky trap! It costs me 1 extra move! Silly willy...'");
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
                if (keys > 0)
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
            Console.WriteLine($"{name}: Wow! I make complete destroy of many traps within my reach. Extreme cool!");
            Console.ReadKey();
        }


        public void DisplayStats()
        {
            System.Console.WriteLine("\nMoves left: " + movesLeft + 
                                     "\nKeys left: " + keys);
        }
    }
}