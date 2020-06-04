using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TreasureIsland
{
    public interface Printer
    {        
        public void Print(List<Point> coordinates);
    }
}
