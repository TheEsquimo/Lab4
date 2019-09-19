namespace Lab4
{
    class WallTile : MapTile
    {
        WallTile()
        {
            visualRepresentationSymbol = '#';
            enterable = false;
            visible = true;
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