namespace Lab4
{
    class WallTile : MapTile, IVisible
    {
        private char visualRepresentationSymbol = '#';
        private bool enterable = false;
        private bool visible = true;

        override public bool Enterable
        {
            get { return enterable; }
        }

        override public char VisualRepresentationSymbol
        {
            get
            {
                if (visible) { return visualRepresentationSymbol; }
                else { return ' '; }
            }
        }

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
    }
}