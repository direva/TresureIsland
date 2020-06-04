using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TreasureIsland
{
    public abstract class MapEntity
    {
        public LineParser parser;
        public Printer printer;
        public string type;

        public MapEntity()
        {
            
        }

        public void Print(List<Point> coordinates)
        {
            printer.Print(coordinates);
        }

        public List<Point> Parse(string line)
        {
            return parser.Parse(line);
        }
    }
}
