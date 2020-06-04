using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TreasureIsland
{
    public interface LineParser
    {
        public List<Point> Parse(string line);
    }
}
