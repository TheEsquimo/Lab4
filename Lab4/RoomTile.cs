using System;

namespace Lab4
{
    class RoomTile : MapTile
    {
        private int keys = 0;
        private int gold = 0;
        private bool superKey = false;
        private bool monster = false;
        private bool trap = false;
        private bool trapSwitch = false;
        
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
                else if (trap) { visualRepresentationSymbol = 'T'; }
                else if (monster) { visualRepresentationSymbol = 'M'; }
                else if (superKey) { visualRepresentationSymbol = 'K'; }
                else if (keys > 0) { visualRepresentationSymbol = 'k'; }
                else if (gold > 0) { visualRepresentationSymbol = '$'; }
                else { visualRepresentationSymbol = '.'; }
        }

        public int Keys
        {
            get { return keys; }
            set { keys = value; }
        }

        public bool SuperKey
        {
            get { return superKey; }
            set { superKey = value; }
        }

        public int Gold
        {
            get { return gold; }
            set { gold = value; }
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

        public bool Trap
        {
            get { return trap;  }
            set { trap = value; }
        }

        public bool TrapSwitch
        {
            get { return trapSwitch; }
            set { trapSwitch = value; }
        }
    }
}