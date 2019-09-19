namespace Lab4
{
    class WallTile : MapTile
    {
        private char visualRepresentationSymbol = '#';
        private bool enterable = false;
        private bool visible = false;

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