namespace Lab4
{
    class RoomTile : MapTile
    {
        int keys = 0;
        int superKeys = 0;
        bool monster = false;
        bool exit = false;

        public int Keys
        {
            get { return keys; }
            set { keys = value; }
        }

        public int SuperKeys
        {
            get { return superKeys; }
            set { superKeys = value; }
        }

        public bool Monster
        {
            get { return monster; }
            set { monster = value; }
        }

        public bool Exit
        {
            get { return exit; }
            set { exit = value; }
        }
    }
}