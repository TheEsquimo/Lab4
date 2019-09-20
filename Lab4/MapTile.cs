namespace Lab4
{
    abstract class MapTile
    {
        protected char visualRepresentationSymbol;
        protected bool playerOnTile = false;
        protected bool enterable = false;
        protected bool visible = false;
        protected int keys = 0;

        virtual public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
        
        virtual public char VisualRepresentationSymbol
        {
            get
            {
                if (visible) { return visualRepresentationSymbol; }
                else { return ' '; }
            }
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