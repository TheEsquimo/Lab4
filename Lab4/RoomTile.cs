using System;

namespace Lab4
{
    class RoomTile : MapTile
    {
        private int superKeys = 0;
        private bool monster = false;
        
        public RoomTile()
        {
            enterable = true;
        }
        override public char VisualRepresentationSymbol
        {
            get
            {
                UpdateVisualRepresentationSymbol();
                if (visible) { return visualRepresentationSymbol; }
                else { return ' '; }
            }
        }

        private void UpdateVisualRepresentationSymbol()
        {
                if (PlayerOnTile) { visualRepresentationSymbol = '@'; }
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

        override public bool Enterable
        {
            get { return enterable; }
        }

         override public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
    }
}