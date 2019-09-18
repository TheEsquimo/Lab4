namespace Lab4
{
    abstract class MapTile
    {
        private char visualRepresentationSymbol;
        private bool playerOnTile = false;

        public bool visible;
        
        virtual public char VisualRepresentationSymbol
        {
            get { return visualRepresentationSymbol; }
        }

        public bool PlayerOnTile
        {
            get {return playerOnTile; }
            set { playerOnTile = value; }            
        }

        public MapTile()
        {
            visible = false;
        }
    }
}