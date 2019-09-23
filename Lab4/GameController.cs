using System;

namespace Lab4
{
    public static class GameController
    {
        public enum GameState
        {
            Start,
            Play,
            End
        }
        static GameState currentState = GameState.Start;
        static string startMessage = "Hello and welcome to TrueGuy explorer of extre-meming" +
                                     "\nTrueGuy: You are going to lead me through a dungeon that has several obstacles." +
                                     "\nThe goal is to get me to the exit, you get more points if you get me there faster and with more gold" +
                                     "\nPress '1' to start the game. Press '2' to see how to play";
        static string tilesExplanationMessage = "Use WASD to move me around on the map, There are tiles on the map that represent different things.\n" +
                                            "\n'@': Das me dawg    '#': Wall    '.': Empty room     'D': Door" +
                                            "\n'K': Normal keys    'E': Exit    'K': Superkey       " +
                                            "\n'M': Monster        'T': Trap    'S': Switch         '$': Gold";
        static string obstaclesExplanationMessage = "\n\nI need a key to unlock doors, I can do this with a normal key or a Superkey(that has several charges)" +
                                                    "\nIf you walk me to a tile that has a Monster or trap then I will get a move penalty." +
                                                    "\nIf I have a weapon then I can defeat the monster without a penalty. " +
                                                    "\nIf there is a trap, then there is always a invisible switch nearby that deactivates it" +
                                                    "\n\nPress any key to go back to the main menu";
        static string loseMessage = "Wow, you are mega lose guy!" +
                                    "\nTry again!";
        static string winMessage = "Wow! I have become winner. It is very lucky for me for having won because I was bored in there and it is not best for me to be. Now I go home. Very cool!";
        public static GameState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
        public static void StartScreen()
        {
            System.Console.WriteLine(startMessage);
            char userInput = Console.ReadKey().KeyChar;
            Console.Clear();
            switch (userInput)
            {
                case '1':
                    currentState = GameState.Play;
                    break;

                case '2':
                    Console.WriteLine(tilesExplanationMessage + obstaclesExplanationMessage);
                    Console.ReadKey();
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                    Console.Clear();
                    StartScreen();
                    break;
            }
        }
        internal static void EndScreen(Player player)
        {
            Console.Clear();
            if (player.MovesLeft < 1)
            {
                Console.WriteLine(loseMessage);
            }
            else
            {
                Console.WriteLine(winMessage);
            }
            Console.ReadKey();
            currentState = GameState.Start;
            Console.Clear();
        }

    }
}