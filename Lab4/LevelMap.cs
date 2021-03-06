﻿using System;

namespace Lab4
{
    class LevelMap
    {
        private MapTile[,] map;

        public MapTile[,] Map
        {
            get { return map; }
        }

        public void MapGeneration(char[,] charMap, Player player)
        {
            //Creates MapTile objects and stores them in 2D array based on chars in parameter 2D array
            int mapSizeY = charMap.GetLength(0);
            int mapSizeX = charMap.GetLength(1);
            map = new MapTile[mapSizeY, mapSizeX];


            for (int row = 0; row < mapSizeY; row++)
            {
                for (int column = 0; column < mapSizeX; column++)
                {
                    MapTile generatedTile;
                    switch (charMap[row, column])
                    {
                        case '#':
                            generatedTile = new WallTile();
                            if (row == 0 
                            || row == mapSizeY - 1
                            || column == 0 
                            || column == mapSizeX - 1)
                            {
                                generatedTile.Visible = true;
                            }
                            break;

                        case '.':
                            generatedTile = new RoomTile();
                            break;

                        case '@':
                            generatedTile = new RoomTile();
                            generatedTile.PlayerOnTile = true;
                            player.PlayerPositionHorizontally = column;
                            player.PlayerPositionVertically = row;
                            break;

                        case 'C':
                            RoomTile roomWithCompass = new RoomTile();
                            roomWithCompass.Compass = true;
                            generatedTile = roomWithCompass;
                            break;

                        case 'D':
                            generatedTile = new DoorTile();
                            break;

                        case 'E':
                            ExitTile roomExit = new ExitTile();
                            generatedTile = roomExit;
                            break;

                        case '$':
                            RoomTile roomWithGold = new RoomTile();
                            roomWithGold.Gold = 10;
                            generatedTile = roomWithGold;
                            break;

                        case 'k':
                            RoomTile roomWithKey = new RoomTile();
                            roomWithKey.Keys = 1;
                            generatedTile = roomWithKey;
                            break;

                        case 'K':
                            RoomTile roomWithSuperKey = new RoomTile();
                            roomWithSuperKey.SuperKey = true;
                            generatedTile = roomWithSuperKey;
                            break;

                        case 'M':
                            RoomTile roomWithMonster = new RoomTile();
                            roomWithMonster.Monster = true;
                            generatedTile = roomWithMonster;
                            break;

                        case 'T':
                            RoomTile roomWithTrap = new RoomTile();
                            roomWithTrap.Trap = true;
                            generatedTile = roomWithTrap;
                            break;

                        case 'S':
                            RoomTile roomWithTrapSwitch = new RoomTile();
                            roomWithTrapSwitch.TrapSwitch = true;
                            generatedTile = roomWithTrapSwitch;
                            break;

                        case 'W':
                            RoomTile roomWithWeapon = new RoomTile();
                            roomWithWeapon.Weapon = true;
                            generatedTile = roomWithWeapon;
                            break;

                        default:
                            generatedTile = new RoomTile();
                            break;
                    }
                    map[row, column] = generatedTile;
                }
            }
        }

        public void PrintMap()
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int column = 0; column < map.GetLength(1); column++)
                {
                     Console.Write(map[row, column].VisualRepresentationSymbol);
                }
                Console.WriteLine();
            }
        }
    }
}