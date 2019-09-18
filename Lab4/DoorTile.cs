namespace Lab4
{
    class DoorTile : MapTile
    {
        private char visualRepresentationSymbol = 'D';
        private bool enterable = false;
        override public bool Enterable
        {
            get { return enterable; }
            set { enterable = value; }
        }

        override public char VisualRepresentationSymbol
        {
            get
            {
                UpdateVisualRepresentationSymbol();
                return visualRepresentationSymbol;
            }
        }

        private void UpdateVisualRepresentationSymbol()
        {
            if (PlayerOnTile) { visualRepresentationSymbol = '@'; }
            else if (!enterable) { visualRepresentationSymbol = 'D'; }
            else { visualRepresentationSymbol = '.'; }
        }
    }
}