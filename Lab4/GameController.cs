using System;

namespace Lab4
{
    public static class GameController
    {
        static string[] highScoreNames = new string[10];
        static int[] highScorePoints = new int[10];
        const int movesLeftValue = 2;

        public enum GameState
        {
            Start,
            Play,
            End
        }

        static GameState currentState = GameState.Start;
        const string startMessage = "=====TRUEGUY & THE ADVENTURE OF EFFORT=====" +
                                     "\nHello and welcome to TrueGuy & The Adventure of Effort" +
                                     "\nTrueGuy: You are going to lead me through a dungeon that has several obstacles." +
                                     "\nThe goal is to get me to the exit, and you get more points if you get me there with more gold and extra moves left" +
                                     "\nPress '1' to start the game. Press '2' to see how to play";

        const string tilesExplanationMessage = "Use WASD to move me around the map. There are tiles on the map that represent different things.\n" +
                                            "\n'@': Das me dawg    '#': Wall    '.': Empty room     'D': Door" +
                                            "\n'k': Normal key    'E': Exit    'K': Superkey       " +
                                            "\n'M': Monster        'T': Trap    'W': Sword         '$': Gold";

        const string obstaclesExplanationMessage = "\n\nI need a key to unlock doors, I can do this with a normal key or a Superkey (A key with several charges)" +
                                                    "\nIf you walk me to a tile that has a monster or trap on it, I will get a move penalty." +
                                                    "\nIf I have a sword, then I can defeat the monster without a penalty. " +
                                                    "\nIf you see a trap, there is always an invisible switch nearby that deactivates it";

        static string pointsExplanation = "\n\nTry to get on the highscore list!" +
                                          "\nScore is calculated by your moves left multiplied by " + movesLeftValue + ", plus your gold" +
                                          "\n\nPress any key to go back to the main menu";

        const string loseMessage = "Wow, you are mega lose guy!" +
                                    "\nBetter luck next time, dawg!";

        const string winMessage = "Wow! I have become winner. It is very lucky for me having won because I was bored in there and it is not best for me to be. Now I go home. Very cool!";

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
                    Console.WriteLine(tilesExplanationMessage + obstaclesExplanationMessage + pointsExplanation);
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
            HighScoreList(player);
            currentState = GameState.Start;
            Console.Clear();
        }

        private static void HighScoreList(Player player)
        {
            Console.Clear();

            int score = player.MovesLeft * movesLeftValue;
            score = score + player.Gold;
            int lastIndex = highScorePoints.Length - 1;
            string playerName;

            Console.WriteLine("Please enter your name: ");
            playerName = Console.ReadLine();

            if (score > highScorePoints[lastIndex])
            {
                highScorePoints[lastIndex] = score;
                highScoreNames[lastIndex] = playerName;
                BubbleSortHighscore(ref highScorePoints, ref highScoreNames);
            }

            Console.Clear();

            Console.WriteLine("=====HIGHSCORE=====");
            for (int i = 0; i < highScoreNames.Length; i++)
            {
                Console.WriteLine($"{i+1}: {highScoreNames[i]}  {highScorePoints[i]}");
            }

            Console.ReadKey();
        }

        private static void BubbleSortHighscore(ref int[] scoreArray, ref string[] nameArray)
        {
            for (int i = 0; i < scoreArray.Length - 1; i++)
            {
                for (int j = 0; j < scoreArray.Length - 1; j++)
                {
                    if (scoreArray[j] < scoreArray[j+1])
                    {
                        int tempScore = scoreArray[j];
                        string tempName = nameArray[j];
                        scoreArray[j] = scoreArray[j + 1];
                        nameArray[j] = nameArray[j + 1];
                        scoreArray[j + 1] = tempScore;
                        nameArray[j + 1] = tempName;
                    }
                }
            }
        }
    }
}