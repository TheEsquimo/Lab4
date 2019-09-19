namespace Lab4
{
    class DoorTile : MapTile
    {
        private char visualRepresentationSymbol = 'D';
        private bool enterable = false;
        private bool visible = true;

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
                if (visible) { return visualRepresentationSymbol; }
                else { return ' '; }
            }
        }

        private void UpdateVisualRepresentationSymbol()
        {
            if (PlayerOnTile) { visualRepresentationSymbol = '@'; }
            else if (!enterable) { visualRepresentationSymbol = 'D'; }
            else { visualRepresentationSymbol = '.'; }
        }

        override public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
    }
}