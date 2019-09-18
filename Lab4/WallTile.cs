namespace Lab4
{
    class WallTile : MapTile
    {
        private char visualRepresentationSymbol = '#';
        private bool enterable = false;

        override public bool Enterable
        {
            get { return enterable; }
        }

        override public char VisualRepresentationSymbol
        {
            get { return visualRepresentationSymbol; }
        }
    }
}