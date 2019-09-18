using System;

namespace Lab4
{
    class RoomTile : MapTile
    {
        private int keys = 0;
        private int superKeys = 0;
        private bool monster = false;
        private bool exit = false;
        private bool enterable = true;
        private char visualRepresentationSymbol;

        override public char VisualRepresentationSymbol
        {
            get
            {
                UpdateVisualRepresentationSymbol();
                return visualRepresentationSymbol;
            }
        }

        private void UpdateVisualRepresentationSymbol()
        {
            if (PlayerOnTile) { visualRepresentationSymbol = '@'; }
            else if (exit) { visualRepresentationSymbol = 'E'; }
            else if (monster) { visualRepresentationSymbol = 'M'; }
            else if (superKeys > 0) { visualRepresentationSymbol = 'S'; }
            else if (keys > 0) { visualRepresentationSymbol = 'K'; }
            else { visualRepresentationSymbol = '.'; }
        }

        override public int Keys
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

        override public bool Enterable
        {
            get { return enterable; }
        }
    }
}