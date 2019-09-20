namespace Lab4
{
    class WallTile : MapTile
    {
        public WallTile()
        {
            visualRepresentationSymbol = '#';
        }
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

        override public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
    }
}