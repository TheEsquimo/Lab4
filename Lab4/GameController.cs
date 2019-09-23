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
                                     "\nThe goal is to get me to the exit, you get more points if you get me there faster and with more gold";
        static string tilesExplanationMessage = "Use WASD to move me around on the map, There are tiles on the map that represent different things.\n" +
                                            "\n'@': Das me dawg    '#': Wall    '.': Empty room     'D': Door" +
                                            "\n'K': Keys           'E': Exit    'K': Superkey       'k': Normal key" +
                                            "\n'M': Monster        'T': Trap    'S': Switch         '$': Gold";
        static string obstaclesExplanationMessage = "I need a key to unlock doors, I can do this with a normal key or a Superkey(that has several charges)" +
                                                    "If you walk me to a tile that has a Monster or trap then I will get a move penalty." +
                                                    "\nIf I have a weapon then I can defeat the monster without a penalty. " +
                                                    "\nIf there is a trap, then there is always a invisible switch nearby that deactivates it";
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
        public static string TilesExplanationMessage
        {
            get { return tilesExplanationMessage; }
        }
    }
}