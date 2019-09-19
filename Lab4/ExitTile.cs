using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    class ExitTile : MapTile
    {
        
        ExitTile()
        {
            visible = true;
            enterable = true;
            visualRepresentationSymbol = 'E';
        }
    }
}
