namespace Lab4
{
    class WallTile : MapTile
    {
        private char visualRepresentationSymbol = '#';

        override public char VisualRepresentationSymbol
        {
            get { return visualRepresentationSymbol; }
        }
    }
}