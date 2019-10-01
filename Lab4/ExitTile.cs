using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    class ExitTile : MapTile
    {
        public ExitTile()
        {
            enterable = true;
            visualRepresentationSymbol = 'E';
        }
    }
}
