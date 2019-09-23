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
        int gold = 0;

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
                movesLeft--;

                //Checks current tile to resolve effects
                if (currentTile is RoomTile)
                {
                    RoomTile roomTile = (RoomTile)currentTile;
                    gold += roomTile.Gold;
                    roomTile.Gold = 0;
                    keys += roomTile.Keys;
                    roomTile.Keys = 0;
                    RoomTileEvents(roomTile, level);
                }
                else if (currentTile is DoorTile)
                {
                    if (!currentTile.Enterable)
                    {
                        DoorTileEvents(currentTile, level);
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

        private void RoomTileEvents(RoomTile roomTile, LevelMap level)
        {
            if (roomTile.Monster)
            {
                roomTile.Monster = false;

                bool hasWeapon = false;
                foreach (Item item in inventory)
                {
                    if (item is Sword)
                    {
                        hasWeapon = true;
                        Sword thisSword = (Sword)item;
                        thisSword.Use(inventory);
                        Console.WriteLine($"\n{name}: 'I fought a monster, and defeated him with my dank sword!'");
                        Console.ReadKey();
                        break;
                    }
                }

                if (!hasWeapon)
                {
                    movesLeft--;
                    Console.WriteLine($"\n{name}: 'I fought a monster, and now I lose a move. Very pain within me...'");
                    Console.ReadKey();
                }
            }
            else if (roomTile.Trap)
            {
                Console.WriteLine($"\n{name}: 'Uh-oh, I have walked upon a spooky trap! It costs me 1 extra move! Silly willy...'");
                movesLeft--;
                Console.ReadKey();
            }
            else if (roomTile.TrapSwitch)
            {
                DestroyTraps(level);
            }
            else if (roomTile.SuperKey)
            {
                foreach (Item item in inventory)
                {
                    if (item is Superkey)
                    {
                        Superkey thisSuperKey = (Superkey)item;
                        thisSuperKey.CurrentCharges = 0;
                        thisSuperKey.Use(inventory);
                        break;
                    }
                }
                Superkey newSuperKey = new Superkey();
                inventory.Add(newSuperKey);
                roomTile.SuperKey = false;
            }
            else if (roomTile.Weapon)
            {
                Sword sword = new Sword();
                inventory.Add(sword);
                roomTile.Weapon = false;
            }
        }

        private void DoorTileEvents(MapTile currentTile, LevelMap level)
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
            System.Console.WriteLine("\n=====INVENTORY=====" +
                                     "\nMoves left: " + movesLeft +
                                     "\nKeys left: " + keys +
                                     "\nGold: " + gold);

            foreach(Item item in inventory)
            {
                if (item is IUsable)
                {
                    IUsable currentItem = (IUsable)item;
                    Console.WriteLine($"{currentItem.ItemName} ({currentItem.CurrentCharges} charges left)");
                }
            }
        }
    }
}