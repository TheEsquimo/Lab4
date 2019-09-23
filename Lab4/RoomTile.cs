﻿using System;

namespace Lab4
{
    class RoomTile : MapTile
    {
        private int keys = 0;
        private int superKeys = 0;
        private int gold = 0;
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
                else if (superKeys > 0) { visualRepresentationSymbol = 'S'; }
                else if (keys > 0) { visualRepresentationSymbol = 'K'; }
                else if (gold > 0) { visualRepresentationSymbol = '$'; }
                else { visualRepresentationSymbol = '.'; }
        }

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