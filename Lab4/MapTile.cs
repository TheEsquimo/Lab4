namespace Lab4
{
    abstract class MapTile
    {
        private char visualRepresentationSymbol;
        private bool playerOnTile = false;
        private bool enterable = false;
        private int keys = 0;

        public bool visible = false;
        
        virtual public char VisualRepresentationSymbol
        {
            get { return visualRepresentationSymbol; }
        }

        public bool PlayerOnTile
        {
            get {return playerOnTile; }
            set { playerOnTile = value; }            
        }

        virtual public int Keys
        {
            get { return keys; }
            set { keys = value; }
        }

        virtual public bool Enterable
        {
            get { return enterable; }
            set { enterable = value; }
        }

        public MapTile()
        {
            visible = false;
        }
    }
}