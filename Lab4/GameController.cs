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
                                     "\nThe goal is to get to the exit!";
        static string instructionsMessage = "Use WASD to move me around on the map, There are tiles on the map that represent different things." +
            "\n'@': Das me dawg , '#': Wall , '.': Empty room , 'D': Door" +
            "\n'K': Keys , 'E': Exit,";
        static string endMessage = ("Wow, you are mega lose guy!" +
                                    "\nTry again!");

        static int currentScore = 0;
        static int highScore;
        public static string EndMessage
        {
            get { return endMessage; }
        }
        public static string StartMessage
        {
            get { return startMessage; }
        }
        public static int CurrentScore
        {
            get { return currentScore; }
            set { currentScore = value; }
        }
        public static GameState CurrentState
        {
            get { return currentState; }
        }
    }
}